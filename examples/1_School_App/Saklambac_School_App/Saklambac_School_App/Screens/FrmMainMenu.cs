using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saklambac_School_App.Screens
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            FrmTeachers frmTeachers = new FrmTeachers();
            frmTeachers.Show();
            this.Hide();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            FrmStudents frmStudents = new FrmStudents();
            frmStudents.Show();
            this.Hide();
        }

    }
}
