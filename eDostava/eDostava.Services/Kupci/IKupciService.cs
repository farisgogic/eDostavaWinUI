using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Kupci
{
    public interface IKupciService : ICRUDService<Model.Kupci, KupciSearchObject, KupciInsertRequest, KupciUpdateRequest>
    {
        Model.Kupci Login(string username, string password);
    }
}
