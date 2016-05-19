using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartMenu
{
    public interface IMenuForm
    {
        void ShowForm();
        void SkipForm();
        void CloseFrom();
        event EventHandler GoToMainForm;
        event EventHandler GoToOpenKeyForm;
        event EventHandler GoToGenerateKeysWindow;
    }
    public partial class MenuForm : Form, IMenuForm
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GoToMainForm != null)
                GoToMainForm(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (GoToOpenKeyForm != null)
                GoToOpenKeyForm(this, EventArgs.Empty);
        }
        #region IMenuForm
        public void ShowForm()
        {
            Visible = true;
        }
        public void SkipForm()
        {
            Visible = false;
        }
        public event EventHandler GoToMainForm;
        public event EventHandler GoToOpenKeyForm;
        public event EventHandler GoToGenerateKeysWindow;
        #endregion

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGenKeys_Click(object sender, EventArgs e)
        {
            if (GoToGenerateKeysWindow != null)
                GoToGenerateKeysWindow(this, EventArgs.Empty);
        }

        public void CloseFrom()
        {
            this.Close();
        }
    }
}
