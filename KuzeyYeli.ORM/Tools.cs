using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM
{
    public class Tools
    { 
        private static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);   //diğer yerlerden almak için sürekli instance almak yerine tool.baglanti diyerek basitçe almak için static yaptık
                                                                //App.config'e git oradaki connectionstringlerden ismi Baglanti olan elemanın ConnectionString'ini al

        public static SqlConnection Baglanti 
        { 
            get { return baglanti; }        //Set metodu yok çünkü bağlantı hiçbir zaman değişmeyecek. Burada hangi değer varsa o okunacak.
        } 

        public static bool ExecuteNonQueryM(SqlCommand cmd)
        {
            //Hata oluştuğunda program patlamasın! Çalışmaya devam etsin.

            try
            {
                if(cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch (Exception) 
            {
                return false;
            }
            finally
            {
                //Bağlantıyı her halükarda kapatmamız lazım. Sadece try a koyarsak ve kod catch'e düşerse bağlantı devam ediyor olacak
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

        }
    }
}
