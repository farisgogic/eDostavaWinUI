using AutoMapper;
using eDostava.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<KorisniciInsertRequest, Database.Korisnik>();
            CreateMap<KorisniciUpdateRequest, Database.Korisnik>();

            CreateMap<Database.Uloga, Model.Uloga>();
            CreateMap<UlogaUpsertRequest, Database.Uloga>();

            CreateMap<Database.KorisnikUloga, Model.KorisnikUloga>();


            CreateMap<Database.Restoran, Model.Restoran>();
            CreateMap<RestoranInsertRequest, Database.Restoran>();
            CreateMap<RestoranUpdateRequest, Database.Restoran>();

            CreateMap<Database.Kategorija, Model.Kategorija>();
            CreateMap<KategorijaUpsertRequest, Database.Kategorija>();

            CreateMap<Database.Jelo, Model.Jelo>();
            CreateMap<JeloUpsertRequest, Database.Jelo>();

            CreateMap<Database.JeloKategorija, Model.JeloKategorija>();


            CreateMap<Database.Kupci, Model.Kupci>();
            CreateMap<KupciInsertRequest, Database.Kupci>();
            CreateMap<KupciUpdateRequest, Database.Kupci>();

            CreateMap<Database.Favoriti, Model.Favoriti>();
            CreateMap<OmiljeniUpsertRequest, Database.Favoriti>();

            CreateMap<Database.NarudzbaStavke, Model.NarudzbaStavka>();
            CreateMap<Database.Narudzba, Model.Narudzba>()
                .ForMember(dest => dest.NarudzbaStavke, opt => opt.MapFrom(src => src.NarudzbaStavke));

            CreateMap<NarudzbaInsertRequest, Database.Narudzba>();
            CreateMap<NarudzbaUpdateRequest, Database.Narudzba>();


            CreateMap<Database.Dostavljac, Model.Dostavljac>();
            CreateMap<DostavljacInsertRequest, Database.Dostavljac>();
            CreateMap<DostavljacUpdateRequest, Database.Dostavljac>();

            CreateMap<Database.Recenzija, Model.Recenzija>();
            CreateMap<RecenzijaUpsertRequest, Database.Recenzija>();

            CreateMap<Database.JelaOcjene, Model.JelaOcjene>();
            CreateMap<JelaOcjeneUpsertRequest, Database.JelaOcjene>();
        }
    }
}
