using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Hash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofdFile = new OpenFileDialog();

        private void Form1_Load_1(object sender, EventArgs e)
        {
           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdFile.FileName = txtFile.Text;
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofdFile.FileName;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }

       
        private MD5 Md5 = MD5.Create();
        private byte[] CalcMD5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }

        private SHA1 Sha1 = SHA1.Create();
        private byte[] CalcSha1(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha1.ComputeHash(stream);
            }
        }

        private SHA256 Sha256 = SHA256.Create();
        private byte[] CalcSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        private SHA384 Sha384 = SHA384.Create();
        private byte[] CalcSha384(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha384.ComputeHash(stream);
            }
        }

        private SHA512 Sha512 = SHA512.Create();
        private byte[] CalcSha512(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha512.ComputeHash(stream);
            }
        }

        private RIPEMD160 RipMid160 = RIPEMD160.Create();
        private byte[] CalcRipMid160(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return RipMid160.ComputeHash(stream);
            }
        }


        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        private void btnHash_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = BytesToString(CalcMD5(txtFile.Text));
            textBox2.Text = BytesToString(CalcSha1(txtFile.Text));
            textBox3.Text = BytesToString(CalcSha256(txtFile.Text));
            textBox4.Text = BytesToString(CalcSha384(txtFile.Text));
            textBox5.Text = BytesToString(CalcSha512(txtFile.Text));
            textBox6.Text = BytesToString(CalcRipMid160(txtFile.Text));
        }
    }
}
