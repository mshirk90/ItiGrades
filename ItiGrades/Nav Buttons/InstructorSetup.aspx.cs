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

                btnAddStudents.Visible = false;
                btnAddClass.Visible = true;
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
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            
            Instructor instructor = (Instructor)Session["Instructor"]; //Initialize BusinessObjects         
            DepartmentList dList = new DepartmentList();                                

            dList = dList.GetAll(); //Get all Departments


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
            Guid departmentValue = new Guid(ddlDepartment.SelectedValue);
            LoadClasses(departmentValue);
        }

        protected void btnSaveClass_Click(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            Class classes = new Class();
            Student student = new Student();
            Guid departmentID = new Guid(ddlDepartment.SelectedValue);
            Guid classID = new Guid(ddlSelectClass.SelectedValue);
            List<Student> studentList = new List<Student>();


            if (ddlDepartment != null && ddlSelectClass != null)
            {
                if(txtFirstName1 != null && txtLastName1 != null)
                {
                    student.FirstName = txtFirstName1.Text;
                    student.LastName = txtLastName1.Text;
                    student.Save();
                    studentList.Add(student);

                }
                if (txtFirstName2 != null && txtLastName2 != null)
                {
                    student.FirstName = txtFirstName1.Text;
                    student.LastName = txtLastName1.Text;
                    student.Save();
                    studentList.Add(student);
                }
                if (txtFirstName3 != null && txtLastName3 != null)
                {
                    student.FirstName = txtFirstName1.Text;
                    student.LastName = txtLastName1.Text;
                    student.Save();
                    studentList.Add(student);
                }
                foreach(Student students in studentList)
                {

                    classes.Save();
                }
            }
        }
    }
}