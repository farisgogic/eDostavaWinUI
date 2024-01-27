using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Database;
using eDostava.Services.Jelo;
using eDostava.Services.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eDostava.Controllers
{
    [AllowAnonymous]
    public class RecenzijaController : BaseCRUDController<Model.Recenzija, RecenzijaSearchObject, RecenzijaUpsertRequest, RecenzijaUpsertRequest>
    {
        public IRecenzijaService ReviewService { get; set; }
        public RecenzijaController(IRecenzijaService reviewService) : base(reviewService)
        {
            ReviewService = reviewService;
        }
    }
}
