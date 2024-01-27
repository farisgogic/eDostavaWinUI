using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Services.Restoran
{
    public interface IRestoranService : ICRUDService<eDostava.Model.Restoran, RestoranSearchObject, RestoranInsertRequest, RestoranUpdateRequest>
    {
    }
}