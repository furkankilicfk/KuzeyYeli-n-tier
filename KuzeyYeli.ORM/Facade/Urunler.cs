using KuzeyYeli.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM.Facade
{
    public class Urunler
    {
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("UrunListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool Insert(Urun u)
        {
            SqlCommand komut = new SqlCommand("UrunEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@urunAdi", u.UrunAdi);
            komut.Parameters.AddWithValue("@fiyat", u.Fiyat);
            komut.Parameters.AddWithValue("@stok", u.Stok);
            komut.Parameters.AddWithValue("@kId", u.KategoriID);
            komut.Parameters.AddWithValue("@tId", u.TedarikciID);

            //if (cmd.Connection.State != ConnectionState.Open)   //Bu satır ve aşağıdaki kodları her yerde ve tüm komutlarda yazacağım. Neden bir yerde tanımlayıp oradan çekmiyorum?
            //    cmd.Connection.Open();
            //int etk = cmd.ExecuteNonQuery();
            //if (cmd.Connection.State != ConnectionState.Closed)
            //    cmd.Connection.Close();

            //return etk > 0 ? true : false;

            return Tools.ExecuteNonQueryM(komut); //Bu method içeride SqlCommand parametresi istedği için (Tools'ta) buradaki sqlcommandimizi veriyoruz. //komut taşınıyor :')
        }
    }
}
