using System;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFile.FileName;
               // StreamReader sr = File.OpenText(openFile.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            httpRequest hR = new httpRequest();
            string token_Access = hR.getStrAccess(hR.API_key, hR.API_secret_key);
            string token_Text = hR.getStrText(hR.API_id,token_Access,"zh",textBox2.Text,"pcm","8000");
            textBox1.Text = token_Text;
        }

        private recordSound recorder = new recordSound();

        //测试github
        //版本控制测试，需要留下评论 
        private WaveFormat createWaveFormat()
        {
            WaveFormat wformat = new WaveFormat();
            wformat.FormatTag = WaveFormatTag.Pcm;
            wformat.SamplesPerSecond = Int32.Parse(comboBox3.SelectedText);
            wformat.BitsPerSample = short.Parse(comboBox4.SelectedText);
            wformat.Channels = short.Parse(comboBox5.SelectedText);
            wformat.BlockAlign = (short)(wformat.Channels * (wformat.BitsPerSample / 8));
            wformat.AverageBytesPerSecond = wformat.BlockAlign * wformat.SamplesPerSecond;
            return wformat;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            recorder.mWavFormat = createWaveFormat();
            string wavFile = null;
            //wavFil
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string wavFile = null;
        }
    }
}
