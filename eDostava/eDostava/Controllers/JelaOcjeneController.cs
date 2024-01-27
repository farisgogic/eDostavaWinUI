using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Database;
using eDostava.Services.JelaOcjene;
using eDostava.Services.Jelo;
using eDostava.Services.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eDostava.Controllers
{
    [AllowAnonymous]
    public class JelaOcjeneController : BaseCRUDController<Model.JelaOcjene, JelaOcjeneSearchObject, JelaOcjeneUpsertRequest, JelaOcjeneUpsertRequest>
    {
        public IJelaOcjeneService JelaOcjeneService { get; set; }
        public JelaOcjeneController(IJelaOcjeneService jelaOcjeneService) : base(jelaOcjeneService)
        {
            JelaOcjeneService = jelaOcjeneService;
        }
    }
}
