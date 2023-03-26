using KuzeyYeli.ORM.Entity;
using KuzeyYeli.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuzeyYeli.WinFormUI
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            cmbKategori.DisplayMember = "KategoriAdi";          //string olarak değer iste. Gelen tablo üzerinden sana hangi kolonu göstereyim? -- Bana bir kolon ismi ver string olarak
            cmbKategori.ValueMember = "KategoriID";             //kullanıcının seçmiş olduğu kategorinin id'sini tutmam lazım. Çünkü her isme bağlı bir id var ve tablodaki yansıması da id.  value namber sayesinde. görünen alan adı olsun,  değer alanı da id'si olsun diyorum. daha sonra selectedvalue dediğim zaman da Seçili adın id sine ulaşabiliryorum.
            cmbKategori.DataSource = Kategoriler.Select();      //Kategori comboboxına kategorilerdeki select metodunu atıyoruz ki seçeneklerde kategorilerin kolonları çıksın. Select() geriye datatable gönderiyor. Ama bu şekilde de datatable'ın nesneleri çıkıyor, datatable sınıfı içindeki stringi de override edemem. Listeleme işlemini yapmadan önce yukarıya bakalım.

            cmbTedarikci.DisplayMember = "SirketAdi";
            cmbTedarikci.ValueMember = "TedarikciID";
            cmbTedarikci.DataSource = Tedarikciler.Select(); 

            dataGridView1.DataSource = Urunler.Select();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urun u = new Urun();
            u.UrunAdi = txtUrunAdi.Text;
            u.Fiyat = nudFiyat.Value;
            u.Stok = Convert.ToInt16(nudStok.Value);
            u.KategoriID = (int)cmbKategori.SelectedValue;      //Seçilen değerin ID'si
            u.TedarikciID = (int)cmbTedarikci.SelectedValue;
            bool sonuc = Urunler.Insert(u);
            if (sonuc)
            {
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklenmiştir");
                dataGridView1.DataSource = Urunler.Select();  // dataGridView1'in DataSource'una Urunler'in Select metodunu atıyoruz onu göstersin sonrasında diye
            }
            else MessageBox.Show("Kayıt eklenirken hata oluştu");


            //combobox'a veri tabanını listeye çekip nasıl bağlarız, kullanıcıya istediğimiz kolonu nasıl gösteriririz, arka planda değeri nasıl tutarız
        }
    }
}
