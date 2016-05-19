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

namespace Rabin_Window
{
    interface IMainForm
    {
        string FilePath { get; }
        string SecretkeyPath { get; set; }
        string Content { get; set; }
        BigInteger SecretKeyOne { get; set; }
        BigInteger SecretKeyTwo { get; set; }

        void SetSymbolCount(int count);
        void SetByteCount(int count);
        void ShowForm();
        void SkipForm();
        void FormGoToWorkMode();
        void FormGoToReadyMode();

        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
        event EventHandler GoToMenuClick;
        event EventHandler FileSaveAsClick;
        event EventHandler SecretKeyClick;
        event EventHandler CloseForm;

    }

    public partial class MainForm : Form, IMainForm
    {
        #region IMainForm
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

        public string FilePath
        {
            get
            {
                return tbtFilePath.Text;
            }
        }
        public string SecretkeyPath { get; set; }

        public BigInteger SecretKeyOne
        {
            get
            {
                return BigInteger.Parse(tbtSecretKey1.Text);
            }

            set
            {
                tbtSecretKey1.Text = value + "";
            }
        }

        public BigInteger SecretKeyTwo
        {
            get
            {
                return BigInteger.Parse(tbtSecretKey2.Text);
            }

            set
            {
                tbtSecretKey2.Text = value + "";
            }
        }

        public event EventHandler ContentChanged;
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler GoToMenuClick;
        public event EventHandler FileSaveAsClick;
        public event EventHandler SecretKeyClick;
        public event EventHandler CloseForm;

        public void SetSymbolCount(int count)
        {
            lblNuberCount.Text = count + "";
        }
        public void SetByteCount(int count)
        {
            lblbyteCountNumber.Text = count + "";
        }
        public void ShowForm()
        {
            Visible = true;
        }
        public void SkipForm()
        {
            Visible = false;
        }
        #endregion

        public MainForm()
        {

            InitializeComponent();


        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Подпись Рабина|*.rabinsignature";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbtFilePath.Text = openFileDialog.FileName;


                if (FileOpenClick != null)
                    FileOpenClick(this, EventArgs.Empty);

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null)
                FileOpenClick(this, EventArgs.Empty);

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null)
                FileSaveClick(this, EventArgs.Empty);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (GoToMenuClick != null)
                GoToMenuClick(this, EventArgs.Empty);


        }

        private void tbtContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
                ContentChanged(this, EventArgs.Empty);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblKeyByteCount.Text = RabinLib.Rabin.CalcylateByteSize(SecretKeyOne * SecretKeyTwo) + "";

            this.FormClosed += (object Sender, FormClosedEventArgs ex) =>
            {
                if (CloseForm != null)
                    CloseForm(this, EventArgs.Empty);
            };
            BigInteger p = SecretKeyOne, q = SecretKeyTwo, f, h;


            tbtSecretKey1.TextChanged += (object Sender, EventArgs E) =>
            {

                try
                {
                    bool flag = BigInteger.TryParse(tbtSecretKey1.Text, out f);
                    if (!flag)
                    {
                        tbtSecretKey1.Text = p + "";
                        throw new Exception("Ключ должен состоять из цифр");
                    }
                    else if (!RabinLib.Rabin.Miller_Rabin_Test(f))
                    {
                        tbtSecretKey1.Text = p + "";
                        throw new Exception("Ключ должен быть простым");
                    }
                    else
                    {
                        p = SecretKeyOne;
                    }
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lblKeyByteCount.Text = RabinLib.Rabin.CalcylateByteSize(p * q) + "";
                }
            };
            tbtSecretKey2.TextChanged += (object Sender, EventArgs E) =>
            {

                try
                {
                    bool flag = BigInteger.TryParse(tbtSecretKey2.Text, out h);
                    if (!flag)
                    {
                        tbtSecretKey2.Text = q + "";
                        throw new Exception("Ключ должен состоять из цифр");
                    }
                    else if (!RabinLib.Rabin.Miller_Rabin_Test(h))
                    {
                        tbtSecretKey2.Text = q + "";
                        throw new Exception("Ключ должен быть простым");
                    }
                    else
                    {
                        q = SecretKeyTwo;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lblKeyByteCount.Text = RabinLib.Rabin.CalcylateByteSize(p * q) + "";
                }
            };
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Подпись Рабина|*.rabinsignature";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbtFilePath.Text = saveFileDialog.FileName;

                if (FileSaveAsClick != null)
                    FileSaveAsClick(this, EventArgs.Empty);
            }

        }

        public void FormGoToWorkMode()
        {


            btnCancle.Enabled = false;
            btnChoose.Enabled = false;
            btnOpen.Enabled = false;
            btnSaveAs.Enabled = false;
            butSave.Enabled = false;

            tbtFilePath.Enabled = false;
            tbtSecretKey1.Enabled = false;
            tbtSecretKey2.Enabled = false;
            tbtContent.Enabled = false;


        }

        public void FormGoToReadyMode()
        {

            btnCancle.Enabled = true;
            btnChoose.Enabled = true;
            btnOpen.Enabled = true;
            btnSaveAs.Enabled = true;
            butSave.Enabled = true;

            tbtFilePath.Enabled = true;
            tbtSecretKey1.Enabled = true;
            tbtSecretKey2.Enabled = true;
            tbtContent.Enabled = true;
        }

        private void btnLoadKeyFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Секретный ключ|*.secretkey";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SecretkeyPath = openFileDialog.FileName;


                if (SecretKeyClick != null)
                    SecretKeyClick(this, EventArgs.Empty);

            }
        }
    }
}
