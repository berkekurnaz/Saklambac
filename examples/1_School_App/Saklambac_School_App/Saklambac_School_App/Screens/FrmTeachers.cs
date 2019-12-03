using Saklambac.NetFramework.Database;
using Saklambac_School_App.Models;
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
    public partial class FrmTeachers : Form
    {
        public FrmTeachers()
        {
            InitializeComponent();
        }

        SaklambacDb<Teacher> teacherDb = new SaklambacDb<Teacher>();

        private void FrmTeachers_Load(object sender, EventArgs e)
        {
            ShowAllTeachers();
            ShowStatistics();
        }



        /* The task of this method is to list all students */
        void ShowAllTeachers()
        {
            dataGridView1.DataSource = teacherDb.GetAll();
        }



        /* The task of this method is to show statistics */
        void ShowStatistics()
        {
            int teacherCount = teacherDb.GetAll().Count;
            lblTeacherCount.Text = "Teacher Count : " + teacherCount;
        }



        /* The task of this method is to add new teacher */
        private void btnNewTeacher_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to add this teacher ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Teacher teacher = new Teacher();
                teacher.TeacherName = txtNameSurname.Text;
                teacher.Class = Convert.ToInt16(txtClass.Text);

                teacherDb.Add(teacher);
                MessageBox.Show("Added New Teacher.");

                ShowAllTeachers();
                ShowStatistics();
            }
        }



        /* The task of this method is to update teacher by Id */
        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to update this teacher ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtId.Text.Length > 0)
                {
                    Teacher findTeacher = teacherDb.GetOneById(txtId.Text);

                    Teacher teacher = new Teacher();
                    teacher.TeacherName = txtNameSurname.Text;
                    teacher.Class = Convert.ToInt16(txtClass.Text);

                    teacherDb.Update(findTeacher, teacher);
                    MessageBox.Show("Updated This Teacher.");

                    ShowAllTeachers();
                    ShowStatistics();
                }
                else
                {
                    MessageBox.Show("Please, select a teacher.");
                }
            }
        }



        /* The task of this method is to delete teacher by Id */
        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete this teacher ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtId.Text.Length > 0)
                {
                    teacherDb.DeleteWithId(txtId.Text);
                    MessageBox.Show("Deleted This Teacher.");

                    ShowAllTeachers();
                    ShowStatistics();
                }
            }
        }



        /* The task of this method is to clear inputs */
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNameSurname.Text = "";
            txtClass.Text = "";
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNameSurname.Text = dataGridView1.Rows[e.RowIndex].Cells["TeacherName"].Value.ToString();
                txtClass.Text = dataGridView1.Rows[e.RowIndex].Cells["Class"].Value.ToString();
            }
            catch
            {

            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu();
            frmMainMenu.Show();
            this.Hide();
        }

    }
}
