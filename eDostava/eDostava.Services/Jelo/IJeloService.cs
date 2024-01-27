using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Jelo
{
    public interface IJeloService : ICRUDService<Model.Jelo, JeloSearchObject, JeloUpsertRequest, JeloUpsertRequest>
    {
        List<Model.Jelo> GetRecommendedJela(int kupacId, int restoranId);
        
        List<Model.Jelo> GetJeloByKategorijaId(int id);
    }
}
