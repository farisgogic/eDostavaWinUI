using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using eDostava.Services.Uloga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Uloga
{
    public class UlogaService : BaseCRUDService<Model.Uloga, Database.Uloga, UlogaSearchObject, UlogaUpsertRequest, UlogaUpsertRequest>, IUlogaService
    {
        public UlogaService(DostavaContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<Database.Uloga> AddFilter(IQueryable<Database.Uloga> query, UlogaSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.Id.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.UlogaId == search.Id);
            }

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x=>x.Naziv.Contains(search.Naziv));
            }

            return filteredQuery;
        }


    }
}
