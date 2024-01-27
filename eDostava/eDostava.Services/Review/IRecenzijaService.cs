using eDostava.Model.Request;
using eDostava.Model.SearchObjects;

namespace eDostava.Services.Review
{
    public interface IRecenzijaService : ICRUDService<Model.Recenzija, RecenzijaSearchObject, RecenzijaUpsertRequest, RecenzijaUpsertRequest>
    {
    }
}
