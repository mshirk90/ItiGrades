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

                if (classes.InstructorId == null && classes.DepartmentId == null)
                {
                    btnAddDepartment.Visible = true;
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
            DataTable dt = new DataTable();
            DataRow dr;

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("Class Name", typeof(Int32)));
            dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
            dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));

            dgGridView.DataSource = dt;
            dgGridView.DataBind();

        }
    }
}