using AutoMapper;
using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Services.Korisnik
{
    public class KorisnikService : BaseCRUDService<Model.Korisnik, Database.Korisnik, KorisnikSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisnikService
    {
        public KorisnikService(DostavaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.Korisnik Update(int id, KorisniciUpdateRequest update)
        {
            var korisnik = context.Korisnik.Find(id);

            if (korisnik == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(update.Lozinka) && update.Lozinka != update.LozinkaPotvrda)
            {
                throw new UserException("Lozinke se ne poklapaju!");
            }

            if (update.Lozinka == update.LozinkaPotvrda && !string.IsNullOrEmpty(update.Lozinka))
            {
                var salt = GenerateSalt();
                korisnik.LozinkaSalt = salt;
                korisnik.LozinkaHash = GenerateHash(salt, update.Lozinka);
            }

            mapper.Map(update, korisnik);
            context.SaveChanges();

            return mapper.Map<Model.Korisnik>(korisnik);
        }



        public override Model.Korisnik Insert(KorisniciInsertRequest insert)
        {
            if (insert.Lozinka != insert.LozinkaPotvrda)
            {
                throw new UserException("Lozinke se ne poklapaju!");
            }
            var entity = base.Insert(insert);

            foreach (var ulogId in insert.UlogeIdList)
            {
                Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga();
                korisnikUloga.UlogaId = ulogId;
                korisnikUloga.KorisnikId = entity.KorisnikId;
                korisnikUloga.DatumPromjene = DateTime.Now;

                context.KorisnikUloga.Add(korisnikUloga);
            }

            Database.Restoran restoran = new Database.Restoran()
            {
                Naziv = insert.KorisnickoIme,
                KorisnikId = entity.KorisnikId,
                Adresa = " ",
                Ocjena = 0,
                Opis = " ",
                RadnoVrijeme = " ",
                Slika = null,
                Telefon = "",
            };

            context.Restoran.Add(restoran);

            insert.RestoranId = restoran.RestoranId;

            context.SaveChanges();
            return entity;
        }

        public override void BeforeInsert(KorisniciInsertRequest insert, Database.Korisnik entity)
        {
            var salt = GenerateSalt();
            entity.LozinkaSalt = salt;
            entity.LozinkaHash = GenerateHash(salt, insert.Lozinka);
            base.BeforeInsert(insert, entity);
        }

        public override IQueryable<Database.Korisnik> AddInclude(IQueryable<Database.Korisnik> query, KorisnikSearchObject search = null)
        {
            if(search?.IncludeRoles == true)
            {
                query = query.Include("KorisnikUloga.Uloga");
            }
            return query;
        }

        public override IQueryable<Database.Korisnik> AddFilter(IQueryable<Database.Korisnik> query, KorisnikSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrEmpty(search?.korisnickoIme))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme.StartsWith(search.korisnickoIme));
            }

            return filteredQuery;
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            try
            {
                byte[] src = Convert.FromBase64String(salt);
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] dst = new byte[src.Length + bytes.Length];

                System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
                System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

                HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
                byte[] inArray = algorithm.ComputeHash(dst);
                return Convert.ToBase64String(inArray);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; 
            }
        }

        

        public Model.Korisnik Login(string username, string password)
        {
            var entity = context.Korisnik.Include("KorisnikUloga.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);
            if(entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);
            if(hash != entity.LozinkaHash)
            {
                return null;
            }

            return mapper.Map<Model.Korisnik>(entity);
        }
    }
}
