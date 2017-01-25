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

                btnAddDepartment.Visible = false;
                btnAddStudent.Visible = false;
                btnAddClass.Visible = false;
                btnOne.Visible = false;
                btnTwo.Visible = false;
                btnThree.Visible = false;
                lblOne.Visible = false;
                lblTwo.Visible = false;
                lblThree.Visible = false;
                txtOne.Visible = false;
                txtTwo.Visible = false;
                txtThree.Visible = false;
                ddlDepartment.Visible = false;

                if (classes.InstructorId == null && classes.DepartmentId == null)
                {
                    btnAddDepartment.Visible = true;
                    ddlDepartment.Visible = true;                    
                    DepartmentList dList = new DepartmentList();
                    dList = dList.GetAll();

                    foreach (Department name in dList.List)
                    {
                        ddlDepartment.Items.Add(name.ToString());
                    }

                    btnOne.Visible = true;
                    btnOne.Text = "Add Department";
                }
                if (classes.InstructorId == null && classes.DepartmentId == department.Id)
                {
                    btnAddClass.Visible = true;
                }
                if (classes.InstructorId == instructor.Id && classes.DepartmentId == department.Id)
                {
                    btnAddStudent.Visible = true;
                }                
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {

            Department department = new Department();
            Instructor instructor = (Instructor)Session["Instructor"];
            string departmentValue = ddlDepartment.SelectedValue;
            department.Name = departmentValue;

            department.Save(instructor.Id, department.Name(departmentValue))    
            

        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {

        }

        protected void btnOne_Click(object sender, EventArgs e)
        {

        }

        protected void btnTwo_Click(object sender, EventArgs e)
        {

        }

        protected void btnThree_Click(object sender, EventArgs e)
        {

        }
    }
}