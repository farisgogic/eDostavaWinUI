using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Services.Restoran
{
    public class RestoranService : BaseCRUDService<Model.Restoran, Database.Restoran, RestoranSearchObject, RestoranInsertRequest, RestoranUpdateRequest>, IRestoranService
    {
        public RestoranService(DostavaContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<Database.Restoran> AddFilter(IQueryable<Database.Restoran> query, RestoranSearchObject search = null)
        {
            var filteredQuery =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.Naziv));
            }

            
              
            return filteredQuery;
        }
    }
}
