using AutoMapper;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eDostava.Services.Narudzba
{
    public class NarudzbeService : BaseCRUDService<Model.Narudzba, Database.Narudzba, NarudzbaSearchObject, NarudzbaInsertRequest, NarudzbaUpdateRequest>, INarudzbaService
    {
        public NarudzbeService(DostavaContext context, IMapper mapper) : base(context, mapper)
        { }


        public override IQueryable<Database.Narudzba> AddFilter(IQueryable<Database.Narudzba> query, NarudzbaSearchObject search = null)
        {
            if (search?.stanje != null)
            {
                StanjeNarudzbe stanjeEnum = (StanjeNarudzbe)search.stanje.Value;
                query = query.Where(j => j.Stanje == stanjeEnum);
            }
            if (search?.RestoranId != null)
            {
                query = query.Where(j => j.RestoranId == search.RestoranId);
            }
            if (!string.IsNullOrEmpty(search?.BrojNarudzbe))
            {
                query = query.Where(x => x.BrojNarudzbe.StartsWith(search.BrojNarudzbe));
            }
            if (search?.kupacId != null)
            {
                query = query.Where(j => j.KupacId == search.kupacId);
            }
            return query;
        }

        public override void BeforeInsert(NarudzbaInsertRequest insert, Database.Narudzba entity)
        {
            entity.Datum = DateTime.Now;
            entity.BrojNarudzbe = (context.Narudzba.Count() + 1).ToString();
            entity.Stanje = Database.StanjeNarudzbe.NaCekanju;
            base.BeforeInsert(insert, entity);
        }

        public override Model.Narudzba Insert(NarudzbaInsertRequest insert)
        {
            var result = base.Insert(insert);
            foreach (var item in insert.Items)
            {
                Database.NarudzbaStavke dbItem = new NarudzbaStavke();
                dbItem.NarudzbaId = result.NarudzbaId;
                dbItem.JeloId = item.JeloId;
                dbItem.Kolicina = item.Kolicina;
                

                context.NarudzbaStavke.Add(dbItem);
            }

            context.SaveChanges();
            return result; 
        }
        public override Model.Narudzba GetById(int id)
        {
            var dbNarudzba = context.Narudzba
                .Include(n => n.NarudzbaStavke)
                .ThenInclude(s=>s.Jelo)
                .SingleOrDefault(n => n.NarudzbaId == id);

            var modelNarudzba = mapper.Map<Model.Narudzba>(dbNarudzba);

            foreach (var stavka in modelNarudzba.NarudzbaStavke)
            {
                var jelo = context.Jelo.Find(stavka.JeloId);
                stavka.Naziv = jelo.Naziv;
                stavka.Cijena = jelo.Cijena;
                stavka.IzracunajCijenu();
            }

            return modelNarudzba;
        }

        public override IEnumerable<Model.Narudzba> Get(NarudzbaSearchObject search = null)
        {
            var entity = context.Narudzba
                .Include(n => n.NarudzbaStavke)
                .ThenInclude(s => s.Jelo)
                .AsQueryable();

            entity = AddFilter(entity, search);
            entity = AddInclude(entity, search);

            if (search.Page.HasValue && search.PageSize.HasValue)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = mapper.Map<IEnumerable<Model.Narudzba>>(entity).ToList();

            foreach (var narudzba in list)
            {
                foreach (var stavka in narudzba.NarudzbaStavke)
                {
                    var jelo = context.Jelo.Find(stavka.JeloId);
                    stavka.Naziv = jelo.Naziv;
                    stavka.Cijena = jelo.Cijena;
                    stavka.IzracunajCijenu();
                }
            }

            return list;
        }

        public override Model.Narudzba Update(int id, NarudzbaUpdateRequest update)
        {
            var entity = context.Narudzba.Find(id);
            entity.Stanje = (StanjeNarudzbe)update.StatusNarudzbeId;
            entity.DostavljacId = update.DostavljacId;

            context.SaveChanges();
            return mapper.Map<Model.Narudzba>(entity);
        }

    }
}
