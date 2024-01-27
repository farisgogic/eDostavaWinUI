using System.Collections.Generic;

namespace eDostava.Model.Request
{
    public class JeloUpsertRequest
    {
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public byte[]? Slika { get; set; }

        public List<int> KategorijaId { get; set; } = new List<int> { };

        public int RestoranId { get; set; }
    }
}
