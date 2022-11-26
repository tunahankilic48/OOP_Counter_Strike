using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    public abstract class Silahlar
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public MenzilTipi MenzilTipi { get; set; }
        public double Agirlik { get; set; }
        public string Picture { get; set; }
        public abstract byte Hasar { get; protected set; }

        public void Oldurme()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = "death.wav";
            sound.Play();
        }
        public void Yaralama()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = "scream.wav";
            sound.Play();

        }

    }
}
