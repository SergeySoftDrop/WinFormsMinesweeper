using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using сапёр3.Controllers;

namespace сапёр3
{
    public partial class Form1 : Form
    {
        private static Settings setingsForm;
        public Form1()
        {
            InitializeComponent();
            setingsForm = new Settings();
            setingsForm.FormClosing += new FormClosingEventHandler(SetingsForm_FormClosed);

            MainController.InitApp(this, setingsForm);
        }

        private void SetingsForm_FormClosed(object sender, FormClosingEventArgs e)
        {
            Settings formSetings = sender as Settings;
            e.Cancel = true;

            formSetings.Hide();

            if (SetingsFormController.Change)
            {
                SetingsFormController.Change = false;
                MainController.NewSetings(this);   
            }
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            MainController.ReastartApp();
        }

        private void SetingsBtn_Click(object sender, EventArgs e)
        {
            setingsForm.Show();
        }
    }
}
