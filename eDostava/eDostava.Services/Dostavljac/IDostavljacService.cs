using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Dostavljac
{
    public interface IDostavljacService : ICRUDService<Model.Dostavljac, DostavljacSearchObject, DostavljacInsertRequest, DostavljacUpdateRequest>
    {
        Model.Dostavljac Login(string username, string password);
    }
}
