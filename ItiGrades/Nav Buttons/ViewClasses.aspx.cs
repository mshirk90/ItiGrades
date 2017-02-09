using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Data;

namespace ItiGrades.Nav_Buttons
{
    public partial class ViewClasses : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Instructor"] != null)
            {
                Instructor instructor = (Instructor)Session["Instructor"];

                lblTitle.Text = "Welcome " + instructor.FirstName + " " + instructor.LastName;
            }
        }

        protected void btnViewClasses_Click(object sender, EventArgs e)
        {
            SectionList sList = new SectionList();

            sList = sList.GetAll(); // Get all sections

            ddlSections.DataSource = sList.List;
            ddlSections.DataBind();
            ddlSections.Items.Add("Choose Class Time");
            ddlSections.SelectedValue = "Choose Class Time";
            ddlSections.Visible = true;
        }

        
        protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            TermClass termclass = new TermClass();
            Student student = new Student();
            Section section = new Section();
            Class clas = new Class();
   
            TermClassList tClassList = new TermClassList();
            DataTable dt = new DataTable();

            tClassList = tClassList.GetAll(); // Get Term classes

            

            dt.Columns.Add("Student Name");
            dt.Columns.Add("Class Name");
            dt.Columns.Add("Instructor Name");
            dt.Columns.Add("Section Name");

            Guid sectionID = new Guid(ddlSections.SelectedValue);

            foreach (TermClass tc in tClassList.List)
            {
                if (tc.InstructorId == instructor.Id)
                {
                    if (tc.SectionId == sectionID)
                    {
                        clas = clas.GetById(tc.ClassId);
                        student = student.GetById(tc.StudentId);

                        string className = clas.Name;
                        string instructorName = instructor.FirstName + " " + instructor.LastName;
                        string studentName = student.FirstName + " " + student.LastName;
                        string sectionName = ddlSections.SelectedItem.ToString();

                        dt.Rows.Add(studentName, className, instructorName, sectionName);
                    }
                }
                ShowTable(dt);
            }
        }


        private void ShowTable(DataTable dt)
        {
            gvViewClass.Visible = true;

            dt.DefaultView.Sort = (ddlSelection.SelectedValue + " " + ddlDirection.Text);

            gvViewClass.DataSource = dt;
            gvViewClass.DataBind();

            ddlSelection.Visible = true;
            ddlDirection.Visible = true;
            lblOrderBy.Visible = true;

            Session["DataTable"] = dt;
        }




        protected void ddlSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = Session["DataTable"] as DataTable;
            if (gvViewClass.Visible = true && data != null)
            {
                data.DefaultView.Sort = (ddlSelection.SelectedValue + " " + ddlDirection.Text);

                gvViewClass.DataSource = data;
                gvViewClass.DataBind();
            }
        }

        protected void ddlDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = Session["DataTable"] as DataTable;
            if (gvViewClass.Visible = true && data != null)
            {
                data.DefaultView.Sort = (ddlSelection.SelectedValue + " " + ddlDirection.Text);

                gvViewClass.DataSource = data;
                gvViewClass.DataBind();
            }
        }
    }
}