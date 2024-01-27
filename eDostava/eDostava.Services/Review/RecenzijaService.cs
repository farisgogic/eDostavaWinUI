using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Review
{
    public class RecenzijaService : BaseCRUDService<Model.Recenzija, Database.Recenzija, RecenzijaSearchObject, RecenzijaUpsertRequest, RecenzijaUpsertRequest>, IRecenzijaService
    {
        public RecenzijaService(DostavaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.Recenzija Insert(RecenzijaUpsertRequest insert)
        {
            var result = base.Insert(insert);

            UpdateRestoranOcjena(insert.RestoranId);

            return result;
        }

        public override Model.Recenzija Update(int id, RecenzijaUpsertRequest update)
        {
            var result = base.Update(id, update);

            UpdateRestoranOcjena(update.RestoranId);

            return result;
        }

        private void UpdateRestoranOcjena(int restoranId)
        {
            var restoran = context.Restoran.Find(restoranId);
            if (restoran != null)
            {
                var reviews = context.Recenzija.Where(r => r.RestoranId == restoranId);
                decimal? averageRating = reviews.Average(r => (decimal?)r.Ocjena);
                restoran.Ocjena = averageRating;
                context.SaveChanges();
            }
        }

        public override IQueryable<Recenzija> AddFilter(IQueryable<Recenzija> query, RecenzijaSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.restoranId != null)
            {
                filteredQuery = filteredQuery.Where(j => j.RestoranId == search.restoranId);
            }
            if (search?.kupacId != null)
            {
                filteredQuery = filteredQuery.Where(j => j.KupacId == search.kupacId);
            }

            return filteredQuery;
        }
    }
}
