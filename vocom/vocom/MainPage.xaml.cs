using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace vocom
{
    public partial class MainPage : ContentPage
    {
        Tone[] DTMFMap = 
            { Tone.Dtmf0
            , Tone.Dtmf1
            , Tone.Dtmf2
            , Tone.Dtmf3
            , Tone.Dtmf4
            , Tone.Dtmf5
            , Tone.Dtmf6
            , Tone.Dtmf7
            , Tone.Dtmf8
            , Tone.Dtmf9
            , Tone.DtmfA
            , Tone.DtmfB
            , Tone.DtmfC
            , Tone.DtmfD
            , Tone.DtmfP
            , Tone.DtmfS
            };

        public void PlayText(string Text)
        {
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(Text);
            ToneGenerator tg = new ToneGenerator(Stream.Music, 100);

            List<Tone> toneList = new List<Tone>();

            foreach(byte b in byteArray)
            {
                toneList.Add(DTMFMap[b & 0x0F]);
                toneList.Add(DTMFMap[(b & 0xF0)>>4]);

            }

            foreach (Tone tone in toneList)
            {
                tg.StartTone(tone, 1000);
                Task.Delay(1000).Wait();
            }
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажато!";
            button.BackgroundColor = Color.Red;
            PlayText("Hello World!");
        }

        public MainPage()
        {
            InitializeComponent();
           
        }
    }
}
