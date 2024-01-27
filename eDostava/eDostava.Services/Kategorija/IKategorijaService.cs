using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Kategorija
{
    public interface IKategorijaService : ICRUDService<Model.Kategorija, KategorijaSearchObject, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
    }
}
