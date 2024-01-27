using AutoMapper;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch> where T : class where TDb : class  where TSearch : BaseSearchObject
    {
        public DostavaContext context;
        public IMapper mapper;

        public BaseService(DostavaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
         
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = context.Set<TDb>().AsQueryable();

            entity = AddFilter(entity, search);
            entity = AddInclude(entity, search);

            if (search.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = entity.ToList();
            return mapper.Map<IEnumerable<T>>(list);

        }



        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;

        }

        public virtual T GetById(int id)
        {
            var set = context.Set<TDb>();

            var entity = set.Find(id);
            return mapper.Map<T>(entity);

        }
    }
}
