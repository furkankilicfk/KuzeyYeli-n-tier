using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuzeyYeli.ORM.Entity;

namespace KuzeyYeli.ORM.Facade
{
    public class Kategoriler
    {
        public static DataTable Select() //bağlantı için instance'a gerek yok. Metot static. dolayısıyla içeridekilerin de static olması lazım. Tools'a statik verdik.
        {
            SqlDataAdapter adp = new SqlDataAdapter("KategoriListele", Tools.Baglanti);  //adaptör tanımladık, ürünlistele prosedürünü çalıştır. bunun bir procedure old söyledik tools sınıfındaki bağlantıyı çektik
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //Kategorideki kolonları tanımını almamız bir yerden çekmemiz lazım. İçine paratmetre vererek sonra yerini söyleyerek almak istemiyoruz çünkü her parametre için ram'de yeni bir değişken üretilecek, sırayla vermek zor, 50 tane kolon da olabilir ve bu devasa bir karışıklığa ve yer işgaline sebep olacaktır. Entity elemanlarımız var
        //kategori sınıfından instance alınır, adı verilir tanımı verilir, daha sonra kategoriler sınıfındaki insert vs metoduna direkt bu kategori sınıfı gönderilir. insert metodu da gelen kategori sınıfından adı ve tanımı alıp sorguya gönderir.
        // bool göndermemizin sebebi kayıt eklenirse işlem başarılı göndersin değilse tersi. kullanıcıya bilgi.
        public static bool Insert(Kategori k)
        {
            SqlCommand cmd = new SqlCommand("KategoriEkle", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adi", k.KategoriAdi);
            cmd.Parameters.AddWithValue("@tanim", k.Tanimi);

            //    if (cmd.Connection.State != ConnectionState.Open)
            //    {
            //        cmd.Connection.Open();
            //    }
            //    int etk = cmd.ExecuteNonQuery();
            //    if (cmd.Connection.State != ConnectionState.Closed)
            //    {
            //        cmd.Connection.Close();
            //    }
            //    //if( etk > 0 )
            //    //{
            //    //    return true;
            //    //}

            //    return etk > 0 ? true : false;
            //}

            return Tools.ExecuteNonQueryM(cmd);  //Bu method içeride SqlCommand parametresi istedği için (Tools'ta) buradaki sqlcommandimizi veriyoruz.
        }
    }
}
