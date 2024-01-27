using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.JelaOcjene
{
    public class JelaOcjeneService : BaseCRUDService<Model.JelaOcjene, Database.JelaOcjene, JelaOcjeneSearchObject, JelaOcjeneUpsertRequest, JelaOcjeneUpsertRequest>, IJelaOcjeneService
    {
        public JelaOcjeneService(DostavaContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override Model.JelaOcjene Insert(JelaOcjeneUpsertRequest insert)
        {
            var result = base.Insert(insert);

            UpdateJeloOcjena(insert.JeloId);

            return result;
        }

        public override Model.JelaOcjene Update(int id, JelaOcjeneUpsertRequest update)
        {
            var result = base.Update(id, update);

            UpdateJeloOcjena(update.JeloId);

            return result;
        }

        private void UpdateJeloOcjena(int jeloId)
        {
            var jelo = context.Jelo.Find(jeloId);
            if (jelo != null)
            {
                var reviews = context.JelaOcjene.Where(r => r.JeloId == jeloId);
                decimal? averageRating = reviews.Average(r => (decimal?)r.Ocjena);
                jelo.Ocjena = averageRating;
                context.SaveChanges();
            }
        }

        public override IQueryable<Database.JelaOcjene> AddFilter(IQueryable<Database.JelaOcjene> query, JelaOcjeneSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.jeloId != null)
            {
                filteredQuery = filteredQuery.Where(j => j.JeloId == search.jeloId);
            }
            if (search?.kupacId != null)
            {
                filteredQuery = filteredQuery.Where(j => j.KupacId == search.kupacId);
            }

            return filteredQuery; 
        }
    }
}
