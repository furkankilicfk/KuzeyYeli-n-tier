using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM.Entity
{
    public class Kategori  //İsim yönelimliliği devam ediyor. Entity tekil nesne old için.. Facade'da Kategoriler  (Çok işlem)
    {
        public string KategoriID { get; set; }

        public string KategoriAdi { get; set; }

        public string Tanimi { get; set; }
    }
}
