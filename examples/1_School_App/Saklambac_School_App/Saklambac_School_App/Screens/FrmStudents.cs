using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saklambac_School_App.Models;
using Saklambac.NetFramework.Database;

namespace Saklambac_School_App.Screens
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
        }

        SaklambacDb<Student> studentDb = new SaklambacDb<Student>();

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShowAllStudents();
            ShowStatistics();
            ShowTeachers();
        }



        /* The task of this method is to list all students */
        void ShowAllStudents()
        {
            dataGridView1.DataSource = studentDb.GetAll();
        }



        /* The task of this method is to show statistics */
        void ShowStatistics()
        {
            int studentCount = studentDb.GetAll().Count;
            lblStudentsCount.Text = "Student Count : " + studentCount;

            double studentGradeAverage = studentDb.GetAll().Average(x => x.Grade);
            lblStudentGradeAverage.Text = "Students Grade Average : " + studentGradeAverage;
        }



        void ShowTeachers()
        {
            SaklambacDb<Teacher> teacherDb = new SaklambacDb<Teacher>();
            List<Teacher> teachers = teacherDb.GetAll();
            foreach (var teacher in teachers)
            {
                cmbTeacherName.Items.Add(teacher.TeacherName);
            }
            cmbTeacherName.SelectedIndex = 0;
        }



        /* The task of this method is to add new student */
        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to add this student ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Student student = new Student();
                student.NameSurname = txtNameSurname.Text;
                student.Number = txtNumber.Text;
                student.Class = Convert.ToInt16(txtClass.Value);
                student.Grade = Convert.ToInt16(txtGrade.Text);
                student.TeacherName = cmbTeacherName.Text;

                studentDb.Add(student);
                MessageBox.Show("Added New Student.");

                ShowAllStudents();
                ShowStatistics();
            }
        }



        /* The task of this method is to update student by Id */
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to update this student ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtId.Text.Length > 0)
                {
                    Student findStudent = studentDb.GetOneById(txtId.Text);

                    Student student = new Student();
                    student.NameSurname = txtNameSurname.Text;
                    student.Number = txtNumber.Text;
                    student.Class = Convert.ToInt16(txtClass.Value);
                    student.Grade = Convert.ToInt16(txtGrade.Text);
                    student.TeacherName = cmbTeacherName.Text;

                    studentDb.Update(findStudent, student);
                    MessageBox.Show("Updated This Student.");

                    ShowAllStudents();
                    ShowStatistics();
                }
                else
                {
                    MessageBox.Show("Please, select a student.");
                }
            }
        }



        /* The task of this method is to delete student by Id */
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete this student ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtId.Text.Length > 0)
                {
                    studentDb.DeleteWithId(txtId.Text);
                    MessageBox.Show("Deleted This Student.");

                    ShowAllStudents();
                    ShowStatistics();
                }
            }
        }



        /* The task of this method is to clear inputs */
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNameSurname.Text = "";
            txtNumber.Text = "";
            txtClass.Text = "";
            txtGrade.Text = "";
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
                txtNameSurname.Text = dataGridView1.Rows[e.RowIndex].Cells["NameSurname"].Value.ToString();
                txtNumber.Text = dataGridView1.Rows[e.RowIndex].Cells["Number"].Value.ToString();
                txtClass.Text = dataGridView1.Rows[e.RowIndex].Cells["Class"].Value.ToString();
                txtGrade.Text = dataGridView1.Rows[e.RowIndex].Cells["Grade"].Value.ToString();
                cmbTeacherName.Text = dataGridView1.Rows[e.RowIndex].Cells["TeacherName"].Value.ToString();
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
