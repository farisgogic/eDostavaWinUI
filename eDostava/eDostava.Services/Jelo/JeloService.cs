using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Jelo
{
    public class JeloService : BaseCRUDService<Model.Jelo, Database.Jelo, JeloSearchObject, JeloUpsertRequest, JeloUpsertRequest>, IJeloService
    {

        public JeloService(DostavaContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override Model.Jelo Insert(JeloUpsertRequest insert)
        {
            var entity = base.Insert(insert);

            entity.RestoranId = insert.RestoranId;

            foreach(var kategorijaId in insert.KategorijaId)
            {
                Database.JeloKategorija jeloKategorija = new Database.JeloKategorija();
                jeloKategorija.JeloId = entity.JeloId;
                jeloKategorija.KategorijaId = kategorijaId;

                context.JeloKategorija.Add(jeloKategorija);
            }
            context.SaveChanges();

            return entity;
        }

        public override Model.Jelo Update(int id, JeloUpsertRequest update)
        {
            var jelo = context.Jelo.Find(id);

            if (jelo != null)
            {
                jelo.Naziv = update.Naziv;
                jelo.Cijena = update.Cijena;
                jelo.Opis = update.Opis;
                jelo.Slika = update.Slika;

                var existingKategorije = context.JeloKategorija.Where(jk => jk.JeloId == jelo.JeloId).ToList();
                var kategorijeToRemove = existingKategorije.Where(jk => !update.KategorijaId.Contains(jk.KategorijaId)).ToList();

                foreach (var jeloKategorija in kategorijeToRemove)
                {
                    context.JeloKategorija.Remove(jeloKategorija);
                }

                foreach (var kategorijaId in update.KategorijaId)
                {
                    if (!existingKategorije.Any(jk => jk.KategorijaId == kategorijaId))
                    {
                        var jeloKategorija = new Database.JeloKategorija();
                        jeloKategorija.JeloId = jelo.JeloId;
                        jeloKategorija.KategorijaId = kategorijaId;
                        context.JeloKategorija.Add(jeloKategorija);
                    }
                }

                context.SaveChanges();

                return GetById(id);
            }

            return null;
        }

        public override IQueryable<Database.Jelo> AddFilter(IQueryable<Database.Jelo> query, JeloSearchObject search = null)
        {
            if (search?.KategorijaId != null)
            {
                query = query.Where(j => j.JeloKategorijas.Any(jk => jk.KategorijaId == search!.KategorijaId));
            }
            if (search?.RestoranId != null)
            {
                query = query.Where(j => j.RestoranId == search!.RestoranId);
            }
            if (search?.IncludeKategorija == true)
            {
                query = query.Include("JeloKategorijas.Kategorija");
            }
            return query;  
        }

        public override IQueryable<Database.Jelo> AddInclude(IQueryable<Database.Jelo> query, JeloSearchObject search = null)
        {
            var filteredQuery = base.AddInclude(query, search);

            if (!string.IsNullOrEmpty(search?.NazivGT))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.NazivGT));
            }

            return filteredQuery;
        }

        public List<Model.Jelo> GetJeloByKategorijaId(int kategorijaId)
        {
            var query = from jelo in context.Jelo
                        join jeloKategorija in context.JeloKategorija
                            on jelo.JeloId equals jeloKategorija.JeloId
                        where jeloKategorija.KategorijaId == kategorijaId
                        select mapper.Map<Model.Jelo>(jelo);

            return query.ToList();
        }

        public List<Model.Jelo> GetRecommendedJela(int KupacId, int RestoranId)
        {
            var jela = context.Jelo.Where(x => x.RestoranId == RestoranId).ToList();

            var preporucenaJela = new List<Model.Jelo>();

            foreach (var jelo in jela)
            {
                var ocjeneJela = context.JelaOcjene.Where(x => x.JeloId == jelo.JeloId).ToList();
                if (ocjeneJela.Any())
                {
                    var prosjecnaOcjena = ocjeneJela.Average(x => x.Ocjena);
                    if (prosjecnaOcjena > 3)
                    {
                        preporucenaJela.Add(mapper.Map<Database.Jelo, Model.Jelo>(jelo));
                    }
                }
            }

            return preporucenaJela.OrderByDescending(x => x.Ocjena).ToList();
        }

    }
}
