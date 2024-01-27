using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Omiljeni
{
    public interface IOmiljeniService : ICRUDService<Model.Favoriti, OmiljeniSearchObject, OmiljeniUpsertRequest, OmiljeniUpsertRequest>
    {
        bool RemoveJeloFromOmiljeniList(int kupacId, int jeloId, int restoranId);
    }
}
