using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace ItiGrades.Nav_Buttons
{
    public partial class InstructorSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Instructor"] != null)
            {
                Instructor instructor = (Instructor)Session["Instructor"];

                Class classes = new Class();
                Department department = new Department();

                lblTitle.Text = "Welcome " + instructor.FirstName + " " + instructor.LastName;


                btnAddStudents.Visible = false;
                btnSetupClass.Visible = true;
                btnSaveClass.Visible = false;
                lblFirstName1.Visible = false;
                lblLastName1.Visible = false;
                lblFirstName2.Visible = false;
                lblLastName2.Visible = false;
                lblFirstName3.Visible = false;
                lblLastName3.Visible = false;
                txtFirstName1.Visible = false;
                txtLastName1.Visible = false;
                txtFirstName2.Visible = false;
                txtLastName2.Visible = false;
                txtFirstName3.Visible = false;
                txtLastName3.Visible = false;
                ddlDepartment.Visible = false;
                ddlSelectClass.Visible = false;
                ddlSections.Visible = false;
            }
        }

        protected void btnSetupClass_Click(object sender, EventArgs e)
        {

            Instructor instructor = (Instructor)Session["Instructor"]; //Initialize BusinessObjects         
            DepartmentList dList = new DepartmentList();
            SectionList sList = new SectionList();

            sList = sList.GetAll(); // Get all sections
            dList = dList.GetAll(); //Get all Departments

            ddlSections.DataSource = sList.List;
            ddlSections.DataBind();
            ddlSections.Visible = true;


            ddlDepartment.DataSource = dList.List; //Add all Departments to DropDownList
            ddlDepartment.DataBind();
            ddlDepartment.Visible = true; //Show DropDownList for Departments 
        }

        private void LoadClasses(Guid departmentValue)
        {
            ClassList cList = new ClassList();
            ddlDepartment.Visible = true;

            if (ddlDepartment.SelectedValue != null)
            {
                cList = cList.GetClassesByDepartmentId(departmentValue);//Get Department Id By Department Name selected
                ddlSelectClass.DataSource = cList.List;
                ddlSelectClass.DataBind();
                ddlSelectClass.Visible = true;
            }
            btnAddStudents.Visible = true;
        }

        private void AddStudents()
        {

        }

        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            lblFirstName1.Visible = true;
            lblLastName1.Visible = true;
            lblFirstName2.Visible = true;
            lblLastName2.Visible = true;
            lblFirstName3.Visible = true;
            lblLastName3.Visible = true;
            txtFirstName1.Visible = true;
            txtLastName1.Visible = true;
            txtFirstName2.Visible = true;
            txtLastName2.Visible = true;
            txtFirstName3.Visible = true;
            txtLastName3.Visible = true;
            btnSaveClass.Visible = true;

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSections.Visible = true;
            Guid departmentValue = new Guid(ddlDepartment.SelectedValue);
            LoadClasses(departmentValue);
        }

        protected void btnSaveClass_Click(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            Class classes = new Class();

            List<Student> studentList = new List<Student>();
            List<TermClass> tClassList = new List<TermClass>();

            Guid departmentId = new Guid(ddlDepartment.SelectedValue);
            Guid classId = new Guid(ddlSelectClass.SelectedValue);
            Guid sectionId = new Guid(ddlSections.SelectedValue);


            if (ddlDepartment != null && ddlSelectClass != null)
            {
                if (txtFirstName1 != null && txtLastName1 != null)
                {
                    Student student = new Student();
                    student.FirstName = txtFirstName1.Text;
                    student.LastName = txtLastName1.Text;
                    student.DepartmentId = departmentId;
                    student.Save();
                    studentList.Add(student);

                }
                if (txtFirstName2 != null && txtLastName2 != null)
                {
                    Student student = new Student();
                    student.FirstName = txtFirstName2.Text;
                    student.LastName = txtLastName2.Text;
                    student.DepartmentId = departmentId;
                    student.Save();
                    studentList.Add(student);
                }
                if (txtFirstName3 != null && txtLastName3 != null)
                {
                    Student student = new Student();
                    student.FirstName = txtFirstName3.Text;
                    student.LastName = txtLastName3.Text;
                    student.DepartmentId = departmentId;
                    student.Save();
                    studentList.Add(student);
                }
                foreach (Student students in studentList)
                {
                    TermClass termclass = new TermClass();


                    termclass.ClassId = classId;
                    termclass.InstructorId = instructor.Id;
                    termclass.StudentId = students.Id;
                    termclass.SectionId = sectionId;

                    termclass.Save();
                    tClassList.Add(termclass);
                }  // Next time I get on... method not crashing but only saving one of the three students entered
            }
            lblFirstName1.Text = "Class Successfully saved!";
            lblFirstName1.Visible = true;
            lblLastName1.Text = "Here's a preview of your class..";
            lblLastName1.Visible = true;

            ShowTable(tClassList);
        }




        private void ShowTable(List<TermClass> tClassList)
        {
            Class clas = new Class();
            Instructor instructor = (Instructor)Session["Instructor"];
            Student student = new Student();
            Section section = new Section();

            DataTable dt = new DataTable();

            dt.Columns.Add("Class Name");
            dt.Columns.Add("Instructor Name");
            dt.Columns.Add("Student Name");
            dt.Columns.Add("Section Name");
            foreach (TermClass tc in  tClassList)
            {
                clas = clas.GetById(tc.ClassId);
                student = student.GetById(tc.StudentId);
                section = section.GetById(tc.SectionId);

                string className = clas.Name;
                string instructorName = instructor.FirstName + " " + instructor.LastName;
                string studentName = student.FirstName + " " + student.LastName;
                string sectionName = section.Name;

                dt.Rows.Add(className, instructorName, studentName, sectionName);                               
            }

            dgGridView.DataSource = dt;
            dgGridView.DataBind();
        }

    }
    
}