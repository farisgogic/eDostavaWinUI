using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDostava.Services.Database
{
    partial class DostavaContext
    {
        partial void onModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dostavljac>().HasData(new Dostavljac
            {
                DostavljacId = 1,
                Ime = "Dostavljac",
                Prezime = "Dostavljac",
                Email = "dostavljac@hotmail.com",
                KorisnickoIme = "dostavljac",
                LozinkaHash = "GoHUPIYBIlWs7SF/iDWMqQ5BWMM=",
                LozinkaSalt = "LMh/1SLj+w3S/UxxyvjXbw==",
            });

            modelBuilder.Entity<Dostavljac>().HasData(new Dostavljac
            {
                DostavljacId = 2,
                Ime = "Test",
                Prezime = "Test",
                Email = "test@hotmail.com",
                KorisnickoIme = "test",
                LozinkaHash = "9zKE4sm+fWv/GfDttsoGvAHbSy4=",
                LozinkaSalt = "aferApxOqW8POEu+KDJTdw==",
            });

            var slika = Convert.FromBase64String("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");

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 1,
                Naziv = "Sendvic",
                Cijena = 8,
                Ocjena = null,
                Opis = "Sendvic sa suhim mesom i dimljenim sirom",
                Slika = slika,
                RestoranId = 1,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 2,
                Naziv = "Pizza Margarita",
                Cijena = 10,
                Ocjena = null,
                Opis = "Mozzarella sir, sos",
                Slika = slika,
                RestoranId = 1,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 3,
                Naziv = "Coca-Cola",
                Cijena = 3,
                Ocjena = null,
                Opis = "Gazirani sok",
                Slika = slika,
                RestoranId = 1,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 4,
                Naziv = "Pileci sendvic",
                Cijena = 12,
                Ocjena = null,
                Opis = "Sendvic sa komadicima piletine i sosom",
                Slika = slika,
                RestoranId = 1,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 5,
                Naziv = "American Classic Burger",
                Cijena = 10,
                Ocjena = null,
                Opis = "Burger 100% juneće meso, umak, sir, zelena salata, paradajz",
                Slika = slika,
                RestoranId = 2,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 6,
                Naziv = "Pizza Tuna",
                Cijena = 13,
                Ocjena = null,
                Opis = "Pizza tuna",
                Slika = slika,
                RestoranId = 2,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 7,
                Naziv = "Palačinke Nutella",
                Cijena = 6,
                Ocjena = null,
                Opis = "Palačinke Nutella",
                Slika = slika,
                RestoranId = 2,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 8,
                Naziv = "Pileća salata",
                Cijena = 8.50,
                Ocjena = null,
                Opis = "Salata",
                Slika = slika,
                RestoranId = 3,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 9,
                Naziv = "Čokoladna torta",
                Cijena = 4,
                Ocjena = null,
                Opis = "Torta sa 4 vrste čokolada",
                Slika = slika,
                RestoranId = 3,
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo
            {
                JeloId = 10,
                Naziv = "Fanta",
                Cijena = 10,
                Ocjena = null,
                Opis = "Gazirani sok",
                Slika = slika,
                RestoranId = 3,
            });


            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 1,
                Naziv = "Sendvici",
                RestoranId = 1,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 2,
                Naziv = "Pizza",
                RestoranId = 1,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 3,
                Naziv = "Sokovi",
                RestoranId = 1,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 4,
                Naziv = "Hamburger",
                RestoranId = 2,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 5,
                Naziv = "Pizza",
                RestoranId = 2,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 6,
                Naziv = "Desert",
                RestoranId = 2,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 7,
                Naziv = "Salate",
                RestoranId = 3,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 8,
                Naziv = "Desert",
                RestoranId = 3,
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija
            {
                KategorijaId = 9,
                Naziv = "Sokovi",
                RestoranId = 3,
            });



            modelBuilder.Entity<Restoran>().HasData(new Restoran
            {
                RestoranId = 1,
                Naziv = "Intermezzo",
                Telefon = "062-292-888",
                Adresa = "Maršala Tita 81",
                Opis = "Restoran Intermezzo",
                Slika = slika,
                RadnoVrijeme = "07-23",
                Ocjena = null,
                KorisnikId = 1
            });
            modelBuilder.Entity<Restoran>().HasData(new Restoran
            {
                RestoranId = 2,
                Naziv = "Divan",
                Telefon = "062-111-456",
                Adresa = "Maršala Tita 72",
                Opis = "Restoran Divan",
                Slika = slika,
                RadnoVrijeme = "07-23",
                Ocjena = null,
                KorisnikId = 2
            });
            modelBuilder.Entity<Restoran>().HasData(new Restoran
            {
                RestoranId = 3,
                Naziv = "Novalića Kula",
                Telefon = "036 727-170",
                Adresa = "Maršala Tita, Konjic 88400",
                Opis = "Restoran Novalic Kula",
                Slika = slika,
                RadnoVrijeme = "07-23",
                Ocjena = null,
                KorisnikId = 3
            });



            modelBuilder.Entity<Korisnik>().HasData(new Korisnik
            {
                KorisnikId = 1,
                Ime = "Intermezzo",
                Prezime = "Intermezzo",
                Email = "Intermezzo@gmail.com",
                KorisnickoIme = "Intermezzo",
                Telefon = "062-292-888",
                LozinkaHash = "+FO/is4OjPBLWAcvN4SawphwYpI=",
                LozinkaSalt = "WcHsEkaYI2W7Phpf1FQa0A==",
                Status = true,
            });
            modelBuilder.Entity<Korisnik>().HasData(new Korisnik
            {
                KorisnikId = 2,
                Ime = "Divan",
                Prezime = "Divan",
                Email = "Divan@gmail.com",
                KorisnickoIme = "Divan",
                Telefon = "",
                LozinkaHash = "YBM81rjRS3HIMNGNuszjTgKcurs=",
                LozinkaSalt = "WDOOidZZRYX/GGdfbuzTXg==",
                Status = true,
            });
            modelBuilder.Entity<Korisnik>().HasData(new Korisnik
            {
                KorisnikId = 3,
                Ime = "Novalic",
                Prezime = "Kula",
                Email = "novalic.kula@gmail.com",
                KorisnickoIme = "Kula",
                Telefon = "036-727-170",
                LozinkaHash = "vFRRokMLs2ajN0zht2BqcxnQSjQ=",
                LozinkaSalt = "eqgQrwIZIWs5gARX/TLRQA==",
                Status = true,
            });


            modelBuilder.Entity<Kupci>().HasData(new Kupci
            {
                KupacId = 1,
                Ime = "kupac",
                Prezime = "kupac",
                Email = "kupac@hotmail.com",
                Adresa = "Kolonija bb",
                KorisnickoIme = "kupac",
                LozinkaHash = "IsyISvRuO3jEEFrR/3/Ns8KK3u8=",
                LozinkaSalt = "A/3a7cg854MykgnM3Ux+Xw==",
            });
            modelBuilder.Entity<Kupci>().HasData(new Kupci
            {
                KupacId = 2,
                Ime = "proba",
                Prezime = "proba",
                Email = "proba@hotmail.com",
                Adresa = "Negdje bb",
                KorisnickoIme = "proba",
                LozinkaHash = "sND9siqFrfU/4SEVbY1h03lWypQ=",
                LozinkaSalt = "ZvEFTFuSI1lcou96iwQHVg==",
            });

            modelBuilder.Entity<Uloga>().HasData(new Uloga { UlogaId = 1, Naziv = "korisnik", Opis = "korisnik" });
            modelBuilder.Entity<Uloga>().HasData(new Uloga { UlogaId = 2, Naziv = "dostavljac", Opis = "dostavljac" });
            modelBuilder.Entity<Uloga>().HasData(new Uloga { UlogaId = 3, Naziv = "uposlenik", Opis = "uposlenik" });
            modelBuilder.Entity<Uloga>().HasData(new Uloga { UlogaId = 4, Naziv = "admin", Opis = "admin" });

            modelBuilder.Entity<Favoriti>().HasData(new Favoriti
            {
                FavoritId = 1,
                KupacId = 1,
                JeloId = 1,
                RestoranId = 1,
                
            });
            modelBuilder.Entity<Favoriti>().HasData(new Favoriti
            {
                FavoritId = 2,
                KupacId = 1,
                JeloId = 7,
                RestoranId = 2,
            });


            modelBuilder.Entity<JelaOcjene>().HasData(new JelaOcjene
            {
                JelaOcjeneId = 1,
                Ocjena = 4,
                Komentar = "vrlo dobro jelo",
                KupacId = 1,
                JeloId = 1,
            });

            modelBuilder.Entity<JelaOcjene>().HasData(new JelaOcjene
            {
                JelaOcjeneId = 2,
                Ocjena = 5,
                Komentar = "veoma ukusno",
                KupacId = 1,
                JeloId = 2,
            });

            modelBuilder.Entity<JelaOcjene>().HasData(new JelaOcjene
            {
                JelaOcjeneId = 3,
                Ocjena = 3,
                Komentar = "okej",
                KupacId = 2,
                JeloId = 1,
            });


            modelBuilder.Entity<JelaOcjene>().HasData(new JelaOcjene
            {
                JelaOcjeneId = 5,
                Ocjena = 5,
                Komentar = "savrseno",
                KupacId = 2,
                JeloId = 2,
            });


            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 1,
                JeloId = 1,
                KategorijaId = 1,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 2,
                JeloId = 2,
                KategorijaId = 2,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 3,
                JeloId = 3,
                KategorijaId = 3,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 4,
                JeloId = 4,
                KategorijaId = 1,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 5,
                JeloId = 5,
                KategorijaId = 4,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 6,
                JeloId = 6,
                KategorijaId = 5,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 7,
                JeloId = 7,
                KategorijaId = 6,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 8,
                JeloId = 8,
                KategorijaId = 7,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 9,
                JeloId = 9,
                KategorijaId = 8,
            });
            modelBuilder.Entity<JeloKategorija>().HasData(new JeloKategorija
            {
                JeloKategorijaId = 10,
                JeloId = 10,
                KategorijaId = 9,
            });


            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 1,
                UlogaId = 2,
                KorisnikId = null,
                KupciId = null,
                DostavljacId = 1,
                DatumPromjene = DateTime.UtcNow,
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 2,
                UlogaId = 2,
                KorisnikId = null,
                KupciId = null,
                DostavljacId = 2,
                DatumPromjene = DateTime.UtcNow,
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 3,
                UlogaId = 3,
                KorisnikId = 1,
                KupciId = null,
                DostavljacId = null,
                DatumPromjene = DateTime.UtcNow,
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 4,
                UlogaId = 3,
                KorisnikId = 2,
                KupciId = null,
                DostavljacId = null,
                DatumPromjene = DateTime.UtcNow,
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 5,
                UlogaId = 3,
                KorisnikId = 3,
                KupciId = null,
                DostavljacId = null,
                DatumPromjene = DateTime.UtcNow,
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 6,
                UlogaId = 1,
                KorisnikId = null,
                KupciId = 1,
                DostavljacId = null,
                DatumPromjene = DateTime.UtcNow,
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                KorisnikUlogaId = 7,
                UlogaId = 1,
                KorisnikId = null,
                KupciId = 2,
                DostavljacId = null,
                DatumPromjene = DateTime.UtcNow,
            });


            modelBuilder.Entity<Recenzija>().HasData(new Recenzija
            {
                RecenzijaId = 1,
                KupacId = 1,
                RestoranId = 1,
                Ocjena = 4,
                Datum = DateTime.UtcNow,
                Komentar = "Vrlo lijep restoran",
            });
            modelBuilder.Entity<Recenzija>().HasData(new Recenzija
            {
                RecenzijaId = 2,
                KupacId = 1,
                RestoranId = 2,
                Ocjena = 5,
                Datum = DateTime.UtcNow,
                Komentar = "Odlican",
            });
            modelBuilder.Entity<Recenzija>().HasData(new Recenzija
            {
                RecenzijaId = 3,
                KupacId = 2,
                RestoranId = 2,
                Ocjena = 4,
                Datum = DateTime.UtcNow,
                Komentar = "Ugodan ambijent",
            });
            modelBuilder.Entity<Recenzija>().HasData(new Recenzija
            {
                RecenzijaId = 4,
                KupacId = 2,
                RestoranId = 3,
                Ocjena = 5,
                Datum = DateTime.UtcNow,
                Komentar = "Odlicno mjesto za uzivanje",
            });


            modelBuilder.Entity<Narudzba>().HasData(new Narudzba
            {
                NarudzbaId = 1,
                BrojNarudzbe = "1",
                Datum = DateTime.UtcNow,
                KupacId = 1,
                RestoranId = 1,
                Stanje = StanjeNarudzbe.NaCekanju,
                Otkazano = false,
                DostavljacId = null,
            });
            modelBuilder.Entity<Narudzba>().HasData(new Narudzba
            {
                NarudzbaId = 2,
                BrojNarudzbe = "2",
                Datum = DateTime.UtcNow,
                KupacId = 1,
                RestoranId = 2,
                Stanje = StanjeNarudzbe.Spremna,
                Otkazano = false,
                DostavljacId = null,
            });
            modelBuilder.Entity<Narudzba>().HasData(new Narudzba
            {
                NarudzbaId = 3,
                BrojNarudzbe = "3",
                Datum = DateTime.UtcNow,
                KupacId = 2,
                RestoranId = 1,
                Stanje = StanjeNarudzbe.NaCekanju,
                Otkazano = false,
                DostavljacId = null,
            });


            modelBuilder.Entity<NarudzbaStavke>().HasData(new NarudzbaStavke
            {
                NarudzbaStavkeId = 1,
                NarudzbaId = 1,
                Kolicina = 2,
                JeloId = 2,
            });
            modelBuilder.Entity<NarudzbaStavke>().HasData(new NarudzbaStavke
            {
                NarudzbaStavkeId = 2,
                NarudzbaId = 2,
                Kolicina = 1,
                JeloId = 5,
            });
            modelBuilder.Entity<NarudzbaStavke>().HasData(new NarudzbaStavke
            {
                NarudzbaStavkeId = 3,
                NarudzbaId = 3,
                Kolicina = 3,
                JeloId = 1,
            });
        }
    }
}
