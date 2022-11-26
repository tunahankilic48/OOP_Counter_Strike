using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Counter_Strike
{
    public partial class frmOyun : Form
    {
        private Silahlar[] _secilenSilahlar;
        private byte _verilenHasar;
        private int _mesafe;

        public frmOyun()
        {
            InitializeComponent();
        }
        public frmOyun(Silahlar[] secilenSilahlar)
        {
            InitializeComponent();
            _secilenSilahlar = secilenSilahlar;
        }
        private void frmOyun_Load(object sender, EventArgs e)
        {
            SilahOzellikleriniYansit();
            ScopeProperties();
            _mesafe = MesafeHesapla();
            lblMesafeYansit.Text = _mesafe.ToString() + " Metre";
            btnDusmanTuru.Enabled = false;

        }
        private void btnSarjorDoldurOyuncu_Click(object sender, EventArgs e)
        {
            foreach (Control control in grbOyuncu.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = false;
            }
            if (_secilenSilahlar[0] is AtesliSilahlar)
            {
                ((AtesliSilahlar)_secilenSilahlar[0]).SarjorDoldurma();
                lblKalanMermiOyuncu.Text = ((AtesliSilahlar)_secilenSilahlar[0]).MermiSayisi.ToString();
                btnDusmanTuru.Enabled = true;
                lsbBilgiAkisi.Items.Add("Oyuncu Şarjör Değiştirdi.");
            }
            else
            {
                ((Bicak)_secilenSilahlar[0]).Bileyle();
                btnDusmanTuru.Enabled = true;
                lsbBilgiAkisi.Items.Add("Oyuncu Bıçağını bileyledi.");

            }

        }
        private void btnAtesEtOyuncu_Click(object sender, EventArgs e)
        {
            if (lblKalanMermiOyuncu.Text != "0")
            {

                if (_secilenSilahlar[0] is AtesliSilahlar)
                {
                    ((AtesliSilahlar)_secilenSilahlar[0]).AtesEtme();
                    Thread.Sleep(500);
                    lblKalanMermiOyuncu.Text = ((AtesliSilahlar)_secilenSilahlar[0]).MermiSayisi.ToString();

                    if (((AtesliSilahlar)_secilenSilahlar[0]).IsabetliMi())
                    {
                        if ((prbCanDusman.Value - _secilenSilahlar[0].Hasar) > 0)
                        {
                            _verilenHasar = _secilenSilahlar[0].Hasar;
                            prbCanDusman.Value -= _verilenHasar;
                            _secilenSilahlar[0].Yaralama();
                            lsbBilgiAkisi.Items.Add($"Oyuncu {_secilenSilahlar[0].Marka} ile {_verilenHasar} hasar verdi.");
                        }
                        else
                        {
                            prbCanDusman.Value = 0;
                            _secilenSilahlar[0].Oldurme();
                            MessageBox.Show("Oyuncu kazandı!");
                        }
                    }
                    else
                    {
                        lsbBilgiAkisi.Items.Add("Oyuncunun atışı isabetli değil!");
                    }
                }
                else
                {
                    if (_mesafe <= 25)
                    {
                        ((Bicak)_secilenSilahlar[0]).Kes();
                        Thread.Sleep(500);
                        if ((prbCanDusman.Value - _secilenSilahlar[0].Hasar) > 0)
                        {
                            _verilenHasar = _secilenSilahlar[0].Hasar;
                            prbCanDusman.Value -= _verilenHasar;
                            _secilenSilahlar[0].Yaralama();
                            lsbBilgiAkisi.Items.Add($"Oyuncu {_secilenSilahlar[0].Marka} ile {_verilenHasar} hasar verdi.");
                        }
                        else
                        {
                            prbCanDusman.Value = 0;
                            _secilenSilahlar[0].Oldurme();
                            MessageBox.Show("Oyuncu kazandı!");
                        }
                    }
                    else
                    {
                        lsbBilgiAkisi.Items.Add("Düşman çok uzakta!!");
                    }
                }

                foreach (Control control in grbOyuncu.Controls)
                {
                    if (control is Button)
                        ((Button)control).Enabled = false;
                }
                Thread.Sleep(500);
                btnDusmanTuru.Enabled = true;
                if (_secilenSilahlar[0] is Tufek)
                {
                    ((Tufek)_secilenSilahlar[0]).EskiDegerlereDon();
                }
                else if (_secilenSilahlar[0] is RoketAtar)
                {
                    ((RoketAtar)_secilenSilahlar[0]).EskiDegerlereDon();
                }

            }
            else
            {
                SoundPlayer sound = new SoundPlayer();

                sound.SoundLocation = "GunEmpty.wav";
                sound.Play();
            }

        }
        private void btnDusmanTuru_Click(object sender, EventArgs e)
        {
            if (lblKalanMermiDusman.Text != "0")
            {
                if (_secilenSilahlar[1] is AtesliSilahlar)
                {
                    ((AtesliSilahlar)_secilenSilahlar[1]).AtesEtme();
                    Thread.Sleep(1000);
                    lblKalanMermiDusman.Text = ((AtesliSilahlar)_secilenSilahlar[1]).MermiSayisi.ToString();

                    if (((AtesliSilahlar)_secilenSilahlar[1]).IsabetliMi())
                    {
                        if ((prbCanOyuncu.Value - _secilenSilahlar[1].Hasar) > 0)
                        {
                            _verilenHasar = _secilenSilahlar[1].Hasar;
                            prbCanOyuncu.Value -= _verilenHasar;
                            _secilenSilahlar[1].Yaralama();
                            lsbBilgiAkisi.Items.Add($"Düşman {_secilenSilahlar[1].Marka} silah ile {_verilenHasar} hasar verdi.");
                        }
                        else
                        {
                            prbCanOyuncu.Value = 0;
                            _secilenSilahlar[1].Oldurme();
                            MessageBox.Show("Düşman kazandı!");
                        }

                    }
                    else
                    {
                        lsbBilgiAkisi.Items.Add("Düşmanın atışı isabetli değil!");
                    }
                }
                else
                {
                    if (_mesafe <= 25)
                    {
                        ((Bicak)_secilenSilahlar[1]).Kes();
                        Thread.Sleep(1000);
                        if ((prbCanOyuncu.Value - _secilenSilahlar[1].Hasar) > 0)
                        {

                            _verilenHasar = _secilenSilahlar[1].Hasar;
                            prbCanOyuncu.Value -= _verilenHasar;
                            _secilenSilahlar[1].Yaralama();
                            lsbBilgiAkisi.Items.Add($"Düşman {_secilenSilahlar[1].Marka} silah ile {_verilenHasar} hasar verdi.");
                        }
                        else
                        {
                            prbCanOyuncu.Value = 0;
                            _secilenSilahlar[1].Oldurme();
                            MessageBox.Show("Düşman kazandı!");
                        }
                    }
                    else
                    {
                        ((Bicak)_secilenSilahlar[1]).Bileyle();
                        lsbBilgiAkisi.Items.Add("Dusman Bıçağını bileyledi.");
                    }
                }

            }
            else
            {
                SoundPlayer sound = new SoundPlayer();
                sound.SoundLocation = "GunEmpty.wav";
                sound.Play();

                ((AtesliSilahlar)_secilenSilahlar[1]).SarjorDoldurma();
                lblKalanMermiDusman.Text = ((AtesliSilahlar)_secilenSilahlar[1]).MermiSayisi.ToString();
                btnDusmanTuru.Enabled = false;
                lsbBilgiAkisi.Items.Add("Düşman Şarjör Değiştirdi.");
            }
            btnDusmanTuru.Enabled = false;
            System.Threading.Thread.Sleep(500);
            foreach (Control control in grbOyuncu.Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = true;
            }
            btnYakinlastirmaYokOyuncu.Enabled = false;
            _mesafe = MesafeHesapla();
            lblMesafeYansit.Text = _mesafe.ToString();

        }
        private void btnYakinlastirmaYokOyuncu_Click(object sender, EventArgs e)
        {
            btnYakinlastirmaYokOyuncu.Enabled = false;
            btnYakinlastir2xOyuncu.Enabled = true;
            btnYakinlastir4xOyuncu.Enabled = true;
            if (_secilenSilahlar[0] is Tufek)
            {
                ((Tufek)_secilenSilahlar[0]).Uzaklastirma();
            }
            else if (_secilenSilahlar[0] is RoketAtar)
            {
                ((RoketAtar)_secilenSilahlar[0]).Uzaklastirma();
            }
        }
        private void btnYakinlastir2xOyuncu_Click(object sender, EventArgs e)
        {
            btnYakinlastirmaYokOyuncu.Enabled = true;
            btnYakinlastir2xOyuncu.Enabled = false;
            btnYakinlastir4xOyuncu.Enabled = true;
            if (_secilenSilahlar[0] is Tufek)
            {
                ((Tufek)_secilenSilahlar[0]).Yakinlastirma();
            }
            else if (_secilenSilahlar[0] is RoketAtar)
            {
                ((RoketAtar)_secilenSilahlar[0]).Yakinlastirma();
            }
        }
        private void btnYakinlastir4xOyuncu_Click(object sender, EventArgs e)
        {
            btnYakinlastirmaYokOyuncu.Enabled = true;
            btnYakinlastir2xOyuncu.Enabled = true;
            btnYakinlastir4xOyuncu.Enabled = false;
            if (_secilenSilahlar[0] is TaramaliTufek)
            {
                ((TaramaliTufek)_secilenSilahlar[0]).Yakinlastirma();
            }
        }



        void SilahOzellikleriniYansit()
        {
            lblSilahOzellikleriOyuncu.Text = SilahOzellikleriniGoster(_secilenSilahlar[0]);
            lblSilahOzellikleriDusman.Text = SilahOzellikleriniGoster(_secilenSilahlar[1]);
            pcbSilahResmiOyuncu.Image = Image.FromFile(_secilenSilahlar[0].Picture);
            pcbSilahResmiDusman.Image = Image.FromFile(_secilenSilahlar[1].Picture);
            if (_secilenSilahlar[0] is AtesliSilahlar)
                lblKalanMermiOyuncu.Text = ((AtesliSilahlar)_secilenSilahlar[0]).MermiSayisi.ToString();
            else
                lblKalanMermiOyuncu.Visible = lblMermiSayisiOyuncu.Visible = false;
            if (_secilenSilahlar[1] is AtesliSilahlar)
                lblKalanMermiDusman.Text = ((AtesliSilahlar)_secilenSilahlar[1]).MermiSayisi.ToString();
            else
                lblKalanMermiDusman.Visible = lblMermiSayisiDusman.Visible = false;
        }
        int MesafeHesapla()
        {
            Random rnd = new Random();
            int mesafe = rnd.Next(1, 101);
            return mesafe;
        }
        void ScopeProperties()
        {
            if (_secilenSilahlar[0] is Tabanca)
            {
                btnYakinlastirmaYokOyuncu.Visible = false;
                btnYakinlastir4xOyuncu.Visible = false;
                btnYakinlastir2xOyuncu.Visible = false;
            }
            else if (_secilenSilahlar[0] is Bicak)
            {
                btnSarjorDoldurOyuncu.Text = "Bileyle";
                btnAtesEtOyuncu.Text = "Kes";
                btnYakinlastirmaYokOyuncu.Visible = false;
                btnYakinlastir2xOyuncu.Visible = false;
                btnYakinlastir4xOyuncu.Visible = false;
            }
            else if (_secilenSilahlar[0] is PompaliTufek)
            {
                btnYakinlastirmaYokOyuncu.Enabled = false;
                btnYakinlastir4xOyuncu.Visible = false;
            }
            else if (_secilenSilahlar[0] is RoketAtar)
            {
                btnYakinlastirmaYokOyuncu.Visible = false;
                btnYakinlastir2xOyuncu.Visible = false;
                btnYakinlastir4xOyuncu.Visible = false;
            }
            else if (_secilenSilahlar[0] is TaramaliTufek)
            {
                btnYakinlastirmaYokOyuncu.Enabled = false;
                btnYakinlastir2xOyuncu.Visible = false;
            }
        }
        string SilahOzellikleriniGoster(Silahlar silah)
        {
            return $"Marka: {silah.Marka}\nModel: {silah.Model}\nAğırlık: {silah.Agirlik}\nMenzil Tipi: {silah.MenzilTipi}";
        }

    }
}
