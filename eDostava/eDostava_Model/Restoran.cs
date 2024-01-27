namespace eDostava.Model
{
    public partial class Restoran
    {
        public int RestoranId { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string RadnoVrijeme { get; set; }
        public string Opis { get; set; } 
        public decimal? Ocjena { get; set; }
        public byte[] Slika { get; set; }
        public int KorisnikId { get; set; }

    }
}
