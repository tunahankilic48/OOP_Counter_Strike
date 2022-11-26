using Counter_Strike.Properties;
using Microsoft.VisualBasic.ApplicationServices;

namespace Counter_Strike
{
    public partial class frmSilahSecimi : Form
    {
        public frmSilahSecimi()
        {
            InitializeComponent();
        }

        Silahlar[] secilenSilahlar = new Silahlar[2];
        private void Form1_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        #region Silahlar
        Tabanca tabanca1 = new Tabanca("Desert Eagle", "Cor-bon 50 AE", MenzilTipi.UzakMesafe, 45, 1.766, "Tabanca.wav", "silah1.wav", "DesertEagle_50AE.jpg");

        Tabanca tabanca2 = new Tabanca("Beretta 92", "92serisi -9x19mm Parabellum", MenzilTipi.UzakMesafe, 40, 1.701, "Tabanca.wav", "silah1.wav", "Beretta_92_FS.gif");

        PompaliTufek pompali1 = new PompaliTufek("BENELLÝ", "Nova Black", MenzilTipi.YakýnMesafe, 12, 3.355, "Pompali.wav", "PompaliSarjor.wav", "nova.jpg");

        PompaliTufek pompali2 = new PompaliTufek("MAG-7M1", "Techno Arms PTY", MenzilTipi.YakýnMesafe, 12, 3.542, "Pompali.wav", "PompaliSarjor.wav", "MAGGG7.png");

        TaramaliTufek taramali1 = new TaramaliTufek("AUG", "Horst Wesp", MenzilTipi.UzakMesafe, 45, 3.605, "Taramali.wav", "silah1.wav", "AUG_A1_508mm_04.jpg");

        TaramaliTufek taramali2 = new TaramaliTufek("G3SG1", "Heckler & Koch", MenzilTipi.UzakMesafe, 7.62, 4.401, "Taramali.wav", "silah1.wav", "Heckler.jpg");

        Bicak bicak = new Bicak("kordak", 0.315, MenzilTipi.YakýnMesafe, "Komando Býçaðý", "StabKnife.wav", "SharpenKnife.wav", "Býçakkkkk.jpg");

        RoketAtar roketatar = new RoketAtar("RPG-7", "Bazalt", MenzilTipi.UzakMesafe, 40, 6.301, "TopAtis.wav", "Silah2.wav", "ROKETATAR.jpg");

        #endregion


        #region SilahSecim

        private void btnTabanca1_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(tabanca1);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(tabanca1);
            secilenSilahlar[0] = tabanca1;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnTabanca2_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(tabanca2);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(tabanca2);
            secilenSilahlar[0] = tabanca2;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnTaramali1_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(taramali1);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(taramali1);
            secilenSilahlar[0] = taramali1;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnTaramali2_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(taramali2);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(taramali2);
            secilenSilahlar[0] = taramali2;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnPompali1_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(pompali1);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(pompali1);
            secilenSilahlar[0] = pompali1;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnPompali2_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(pompali2);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(pompali2);
            secilenSilahlar[0] = pompali2;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnBicak_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(bicak);
            secilenSilahlar[0] = bicak;
            btnBuSilahlaDevamEt.Enabled = true;
        }

        private void btnRoketatar_Click(object sender, EventArgs e)
        {
            lblSilahSecildi.Text = GenelOzelliklerSilahSecim(roketatar);
            lblAtesliSilahOzellikleri.Text = OzelOzelliklerSilahSecim(roketatar);
            secilenSilahlar[0] = roketatar;
            btnBuSilahlaDevamEt.Enabled = true;
        }
        private void btnBuSilahlaDevamEt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seçilen Silah: " + secilenSilahlar[0].Marka);
            do
            {
                secilenSilahlar[1] = RastgeleSilahSecimi();
                if (secilenSilahlar[0] != secilenSilahlar[1])
                    break;
            } while (true);
            frmOyun _frmOyun = new frmOyun(secilenSilahlar);
            _frmOyun.Show();
            this.Hide();

        }


        #endregion


        #region Methods
        private void FillForm()
        {
            pcbDesert.Image = Image.FromFile(tabanca1.Picture);
            pcbBeretta.Image = Image.FromFile(tabanca2.Picture);
            pcbNova.Image = Image.FromFile(pompali1.Picture);
            pcbMag7.Image = Image.FromFile(pompali2.Picture);
            pcbAug.Image = Image.FromFile(taramali1.Picture);
            pcbG3sg1.Image = Image.FromFile(taramali2.Picture);
            pcbRoketatar.Image = Image.FromFile(roketatar.Picture);
            pcbBicak.Image = Image.FromFile(bicak.Picture);
            btnBuSilahlaDevamEt.Enabled = false;
        }
        public string GenelOzelliklerSilahSecim(Silahlar silah)
        {
            return $"Marka: {silah.Marka}\nModel: {silah.Model}\nAðýrlýk: {silah.Agirlik}gram\nMermi Sayýsý: {silah.Hasar}";
        }
        string OzelOzelliklerSilahSecim(AtesliSilahlar silah)
        {
            return $"Þarjör Kapasitesi: {silah.MermiKapasitesi}\nÝsabet Olasýlýðý: %{silah.IsabetOlasiligi * 10}";
        }
        Silahlar RastgeleSilahSecimi()
        {
            Random rnd = new Random();
            int secim = rnd.Next(1, 9);
            switch (secim)
            {
                case 1: return tabanca1;
                case 2: return tabanca2;
                case 3: return pompali1;
                case 4: return pompali2;
                case 5: return taramali1;
                case 6: return taramali2;
                case 7: return bicak;
                case 8: return roketatar;
                default: return tabanca1;
            }
        }


        #endregion

    }
}