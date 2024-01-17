using System;
using System.Windows.Forms;

namespace UyeGirisPaneli
{
    public partial class LoginForm : Form
    {
        // Örnek kullanıcı bilgileri
        private const string DogruKullaniciAdi = "kullanici";
        private const string DogruSifre = "sifre";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            if (GirisKontrolu(kullaniciAdi, sifre))
            {
                MessageBox.Show("Giriş başarılı!");
                // Giriş başarılıysa yapılacak işlemler buraya eklenir
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre. Lütfen tekrar deneyin.");
            }
        }

        private bool GirisKontrolu(string kullaniciAdi, string sifre)
        {
            // Gerçek bir uygulamada, kullanıcı adı ve şifre veritabanından kontrol edilmelidir.
            return kullaniciAdi == DogruKullaniciAdi && sifre == DogruSifre;
        }
    }
}
