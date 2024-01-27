using AutoMapper;
using eDostava.Model;
using eDostava.Model.Request;
using eDostava.Model.SearchObjects;
using eDostava.Services;
using eDostava.Services.Database;
using eDostava.Services.Narudzba;
using eDostava.Services.Omiljeni;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace eDostava.Controllers
{
    [AllowAnonymous]
    public class NarudzbaController : BaseCRUDController<Model.Narudzba, NarudzbaSearchObject, NarudzbaInsertRequest, NarudzbaUpdateRequest>
    {
        private readonly INarudzbaService service;

        public NarudzbaController(INarudzbaService service, DostavaContext context)
            : base(service)
        {
            this.service = service;
        }

    }
}
