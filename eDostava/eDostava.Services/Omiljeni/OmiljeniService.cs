using AutoMapper;
using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Omiljeni
{
    public class OmiljeniService : BaseCRUDService<Model.Favoriti, Database.Favoriti, OmiljeniSearchObject, OmiljeniUpsertRequest, OmiljeniUpsertRequest>, IOmiljeniService
    {
        public OmiljeniService(DostavaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Favoriti> AddFilter(IQueryable<Database.Favoriti> query, OmiljeniSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.RestoranId != null)
            {
                filteredQuery = filteredQuery.Where(o => o.RestoranId == search.RestoranId);
            }
            if (search?.KupacId != null)
            {
                filteredQuery = filteredQuery.Where(o => o.KupacId == search.KupacId);
            }

            return filteredQuery;
        }

        public override Model.Favoriti Insert(OmiljeniUpsertRequest insert)
        {
            var kupac = context.Kupci.FirstOrDefault(k => k.KupacId == insert.KupacId);
            var jelo = context.Jelo.FirstOrDefault(j => j.JeloId == insert.JeloId);
            var restoran = context.Restoran.FirstOrDefault(r => r.RestoranId == insert.RestoranId);

            if (kupac == null)
            {
                throw new Exception($"Kupac sa id {insert.KupacId} nije pronadjen.");
            }

            if (jelo == null)
            {
                throw new Exception($"Jelo sa id {insert.JeloId} nije pronadjen.");
            }

            if (restoran == null)
            {
                throw new Exception($"Jelo sa id {insert.RestoranId} nije pronadjen.");
            }

            var existingOmiljeni = context.Favoriti.FirstOrDefault(o => o.KupacId == insert.KupacId && o.JeloId == insert.JeloId && o.RestoranId == insert.RestoranId);

            if (existingOmiljeni != null)
            {
                throw new Exception($"Jelo sa id {insert.JeloId} se vec nalazi u Favoritima kupca sa id {insert.KupacId}.");
            }

            var omiljeni = new Database.Favoriti
            {
                KupacId = insert.KupacId,
                JeloId = insert.JeloId,
                RestoranId = insert.RestoranId
            };
            if (omiljeni.RestoranId != jelo.RestoranId)
            {
                throw new Exception($"Restoran id {insert.RestoranId} ne sadrzi jelo id {insert.JeloId}");
            }
            context.Favoriti.Add(omiljeni);
            context.SaveChanges();

            return mapper.Map<Model.Favoriti>(omiljeni);
        }



        public bool RemoveJeloFromOmiljeniList(int kupacId, int jeloId, int restoranId)
        {
            var omiljeni = context.Favoriti
                .FirstOrDefault(x => x.KupacId == kupacId && x.JeloId == jeloId && x.RestoranId == restoranId);

            if (omiljeni == null)
            {
                return false;
            }

            context.Favoriti.Remove(omiljeni);

            context.SaveChanges();

            return true;
        }

    }
}
