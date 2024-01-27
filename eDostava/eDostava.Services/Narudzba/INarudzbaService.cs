using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Narudzba
{
    public interface INarudzbaService: ICRUDService<Model.Narudzba, NarudzbaSearchObject, NarudzbaInsertRequest, NarudzbaUpdateRequest>
    {
    }
}
