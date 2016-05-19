using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateKeyWindow
{

    public interface IGenerateKeyWindow
    {
        string Key1 { get; set; }
        string Key2 { get; set; }
        String pathOpenKey { get; set; }
        String pathSecretkey { get; set; }

        void ShowForm();
        void SkipFrom();
     



        event EventHandler PressOk;
        event EventHandler GoHome;
        event EventHandler CloseForm;
    }
    public partial class Form1 : Form, IGenerateKeyWindow
    {

        int saveconst1 = 0, saveconst2 = 0;

        public String pathOpenKey { get; set; }

        public String pathSecretkey { get; set; }

        public string Key1
        {
            get
            {
                return tbtKeyLength1.Text;
            }
            set
            {
                tbtKeyLength1.Text = value;
            }
        }

        public string Key2
        {
            get
            {
                return tbtkeylength2.Text;
            }
            set
            {
                tbtkeylength2.Text = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            saveconst1 = int.Parse(Key1);
            saveconst2 = int.Parse(Key2);
        }

        public event EventHandler PressOk;
        public event EventHandler GoHome;
        public event EventHandler CloseForm;

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Cекретный ключ|*.secretkey";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathSecretkey = saveFileDialog.FileName;
            }
            SaveFileDialog saveFileDialog2 = new SaveFileDialog();

            saveFileDialog2.Filter = "Открытый ключ|*.openkey";

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pathOpenKey = saveFileDialog2.FileName;
                if (PressOk != null)
                {
                    PressOk(this, EventArgs.Empty);
                }
            }
        }

        private void tbtkeylength2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(Key2) > 50 || int.Parse(Key2) < 3)
                {
                    Key2 = saveconst2+ "";
                    MessageBox.Show("Слишком большое количество симовов в ключе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (int.Parse(Key2) < 3)
                {

                    Key2 = saveconst2 + "";
                    MessageBox.Show("Слишком маленькое количество симовов в ключе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    saveconst2 = int.Parse(Key2);
                }
            }
            catch (Exception ex)
            {
                Key2 = saveconst2 + "";
                MessageBox.Show("В это текстовое поле следует вводить число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tbtKeyLength1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Key1) > 50)
                {
                    Key1 =saveconst1 + "";
                    MessageBox.Show("Слишком большое количество симовов в ключе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (int.Parse(Key1) < 3)
                {

                    Key1 =saveconst1 + "";
                    MessageBox.Show("Слишком маленькое количество симовов в ключе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    saveconst1 = int.Parse(Key1);
                }
            }
            catch (Exception ex)
            {
                Key1 = saveconst1 + "";
                MessageBox.Show("В это текстовое поле следует вводить число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void ShowForm()
        {
            Visible = true;
            Key1 =saveconst1 + "";
            Key2 = saveconst2 + "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (GoHome != null)
                GoHome(this, EventArgs.Empty);
        }

        public void SkipFrom()
        {
            Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosed += (object Sender, FormClosedEventArgs ex) =>
              {
                  if (CloseForm != null)
                      CloseForm(this, EventArgs.Empty);
              };
        }

    }
}
