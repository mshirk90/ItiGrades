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
    public partial class ViewClasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Instructor"] != null)
            {
                Instructor instructor = (Instructor)Session["Instructor"];

                lblTitle.Text = "Welcome " + instructor.FirstName + " " + instructor.LastName;

                ddlSections.Items.Add("Default");         
            }
        }

        protected void btnViewClasses_Click(object sender, EventArgs e)
        {
            SectionList sList = new SectionList();

            sList = sList.GetAll(); // Get all sections

            ddlSections.DataSource = sList.List;
            ddlSections.DataBind();
            ddlSections.Visible = true;
        }

        private void TempMethod()
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            TermClass termclass = new TermClass();
            Student student = new Student();
            Section section = new Section();
            Class clas = new Class();

            List<DataTable> dtList = new List<DataTable>();
            ClassList cList = new ClassList();
            TermClassList tClassList = new TermClassList();

            cList = cList.GetAll();
            tClassList = tClassList.GetAll();

            DataTable dt = new DataTable();

            dt.Columns.Add("Class Name");
            dt.Columns.Add("Instructor Name");
            dt.Columns.Add("Student Name");
            dt.Columns.Add("Section Name");

            foreach (TermClass tc in tClassList.List)
            {
                if (tc.InstructorId == instructor.Id)
                {
                    clas = clas.GetById(tc.ClassId);
                    student = student.GetById(tc.StudentId);
                    section = section.GetById(tc.SectionId);

                    string className = clas.Name;
                    string instructorName = instructor.FirstName + " " + instructor.LastName;
                    string studentName = student.FirstName + " " + student.LastName;
                    string sectionName = section.Name;

                    foreach (Class classes in cList.List)
                    {
                        if (className == classes.Name)
                        {
                            dt.Rows.Add(className, instructorName, studentName, sectionName);
                        }
                    }
                }
            }
        }

        protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            TermClass termclass = new TermClass();
            Student student = new Student();
            Section section = new Section();
            Class clas = new Class();

            List<DataTable> dtList = new List<DataTable>();
            TermClassList tClassList = new TermClassList();
            DataTable dtMorning = new DataTable();
            DataTable dtAfternoon = new DataTable();
            DataTable dtEvening = new DataTable();

            tClassList = tClassList.GetAll(); // Get Term classes

            dtMorning.Columns.Add("Class Name");
            dtMorning.Columns.Add("Instructor Name");
            dtMorning.Columns.Add("Student Name");
            dtMorning.Columns.Add("Section Name");

            dtAfternoon.Columns.Add("Class Name");
            dtAfternoon.Columns.Add("Instructor Name");
            dtAfternoon.Columns.Add("Student Name");
            dtAfternoon.Columns.Add("Section Name");

            dtEvening.Columns.Add("Class Name");
            dtEvening.Columns.Add("Instructor Name");
            dtEvening.Columns.Add("Student Name");
            dtEvening.Columns.Add("Section Name");

            foreach (TermClass tc in tClassList.List)
            {
                if (tc.InstructorId == instructor.Id)
                {
                    clas = clas.GetById(tc.ClassId);
                    student = student.GetById(tc.StudentId);
                    section = section.GetById(tc.SectionId);

                    string className = clas.Name;
                    string instructorName = instructor.FirstName + " " + instructor.LastName;
                    string studentName = student.FirstName + " " + student.LastName;
                    Guid sectionID =  new Guid(ddlSections.SelectedValue);
                    section.Id = sectionID;
                    string sectionName = section.Name;

                    if (sectionName == "Morning")
                    {
                        dtMorning.Rows.Add(className, instructorName, studentName, sectionName);
                        MorningTable(dtMorning);
                    }
                    if (sectionName == "Afternoon")
                    {
                        dtAfternoon.Rows.Add(className, instructorName, studentName, sectionName);
                        AfternoonTable(dtAfternoon);
                    }
                    if (sectionName == "Evening")
                    {
                        dtEvening.Rows.Add(className, instructorName, studentName, sectionName);
                        EveningTable(dtEvening);
                    }
                }
            }
        }

        private void MorningTable(DataTable dt)
        {
            DataTable dtMorning = new DataTable();
            dtMorning = dt;

            gvMorning.DataSource = dtMorning;
            gvMorning.DataBind();
        }

        private void AfternoonTable(DataTable dt)
        {
            DataTable dtAfternoon = new DataTable();
            dtAfternoon = dt;

            gvAfternoon.DataSource = dtAfternoon;
            gvAfternoon.DataBind();
        }

        private void EveningTable(DataTable dt)
        {
            DataTable dtEvening = new DataTable();
            dtEvening = dt;

            gvEvening.DataSource = dtEvening;
            gvEvening.DataBind();
        }

    }
}