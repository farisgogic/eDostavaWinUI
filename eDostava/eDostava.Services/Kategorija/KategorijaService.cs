using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using eDostava.Services.Services.Restoran;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Kategorija
{
    public class KategorijaService : BaseCRUDService<Model.Kategorija, Database.Kategorija, KategorijaSearchObject, KategorijaUpsertRequest, KategorijaUpsertRequest>, IKategorijaService 
    {
        public KategorijaService(DostavaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Kategorija> AddFilter(IQueryable<Database.Kategorija> query, KategorijaSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search?.RestoranId != null)
            {
                filteredQuery = filteredQuery.Where(j => j.RestoranId == search.RestoranId);
            }

            if (!string.IsNullOrEmpty(search?.NazivGT))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.StartsWith(search.NazivGT));
            }

            return filteredQuery;
        }
    }
}
