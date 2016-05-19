using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using RabinLib;

namespace OpenkeyWindow
{
    public interface IOpenKeyForm
    {
        string path { get; set; }
        string pathToOpenKey { get; set; }
        string Content { get; set; }
        BigInteger OpenKey { get; set; }

        void SetSymbolCount(int count);
        void SetByteCount(int count);
        void ShowForm();
        void SkipForm();

        event EventHandler FileСheckSignature;
        event EventHandler GoToMenuClick;
        event EventHandler LoadOpneKeyFormFile;
        event EventHandler Close;
    }

    public partial class OpenKeyForm : Form, IOpenKeyForm
    {
        #region IOpenKeyForm

        public string Content
        {
            get
            {
                return tbtContent.Text;
            }

            set
            {
                tbtContent.Text = value;
            }
        }

        public BigInteger OpenKey
        {
            get
            {
                return BigInteger.Parse(tbtOpenKey.Text);
            }

            set
            {
                tbtOpenKey.Text = value + "";
            }
        }

        public string path
        {
            get;

            set;
        }

        public string pathToOpenKey
        {
            get;
            set;
        }

        public void SetSymbolCount(int count)
        {
            lblSymbolCount.Text = count + "";
        }

        public void SetByteCount(int count)
        {
            lblByte.Text = count + "";

        }
        public void ShowForm()
        {
            Visible = true;
        }

        public void SkipForm()
        {
            Visible = false;
        }


        public event EventHandler FileСheckSignature;
        public event EventHandler GoToMenuClick;
        public event EventHandler LoadOpneKeyFormFile;
        public event EventHandler Close;

        #endregion

        public OpenKeyForm()
        {

            InitializeComponent();

            BigInteger n = OpenKey, f;

            FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                if (Close != null)
                    Close(this, EventArgs.Empty);
            };

            tbtContent.TextChanged += (object sender, EventArgs e) =>
            {
                lblSymbolCount.Text = Content.Length + "";
                lblByte.Text = Encoding.UTF8.GetBytes(Content).Length + " ";
            };

            tbtOpenKey.TextChanged += (object sender, EventArgs e) =>
            {

                try
                {
                    bool flag = BigInteger.TryParse(tbtOpenKey.Text, out f);
                    if (!flag)
                    {
                        OpenKey = n;
                        throw new Exception("Ключ должен состоять из цифр");
                    }
                    else
                        n = OpenKey;

                    lblKeyByteCount.Text = Rabin.ModifSignByteSize(OpenKey) + "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };


        }

        private void lblOpenkey_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblKeyByteCount.Text = Rabin.CalcylateByteSize(OpenKey) + "";
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Модифицированная подпись Рабина|*.rabinmodifsignature";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;


                if (FileСheckSignature != null)
                    FileСheckSignature(this, EventArgs.Empty);

            }
        }

        private void btnGoToMenu_Click(object sender, EventArgs e)
        {
            if (GoToMenuClick != null)
                GoToMenuClick(this, EventArgs.Empty);
        }

        private void btnLoadOpneKeyFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Открытый ключ|*.modifsignatureopenkey";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToOpenKey = openFileDialog.FileName;


                if (LoadOpneKeyFormFile != null)
                    LoadOpneKeyFormFile(this, EventArgs.Empty);

            }
        }
    }
}
