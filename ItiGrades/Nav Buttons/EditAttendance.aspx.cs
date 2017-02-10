using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessObjects;

namespace ItiGrades.Nav_Buttons
{
    public partial class EditAttendance : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Instructor"] != null)
            {
                Instructor instructor = (Instructor)Session["Instructor"];

                lblTitle.Text = "Welcome " + instructor.FirstName + " " + instructor.LastName;

            }

            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("First Name");
                dt.Columns.Add("Last Name");
                ViewState["StudentNames"] = dt;
            }

        }

        protected void btnSetupClass_Click(object sender, EventArgs e)
        {

            Instructor instructor = (Instructor)Session["Instructor"]; //Initialize BusinessObjects         

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
            DepartmentList dList = new DepartmentList();

            dList = dList.GetAll(); //Get all Departments

            ddlDepartment.DataSource = dList.List; //Add all Departments to DropDownList
            ddlDepartment.DataBind();
            ddlDepartment.Items.Add("Choose Department");
            ddlDepartment.SelectedValue = "Choose Department";
            ddlDepartment.Visible = true; //Show DropDownList for Departments 
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid departmentValue = new Guid(ddlDepartment.SelectedValue);
            LoadClasses(departmentValue);
        }
        private void LoadClasses(Guid departmentValue)
        {
            ClassList cList = new ClassList();
            //ddlDepartment.Visible = true;

            if (ddlDepartment.SelectedValue != null)
            {
                cList = cList.GetClassesByDepartmentId(departmentValue);//Get Department Id By Department Name selected
                ddlSelectClass.DataSource = cList.List;
                ddlSelectClass.DataBind();
                ddlSelectClass.Items.Add("Choose Class");
                ddlSelectClass.SelectedValue = "Choose Class";
                ddlSelectClass.Visible = true;
            }
            btnEditAttendance.Visible = true;
        }


      
      
       

        //private void ShowTable(List<TermClass> tClassList)
        //{
        //    Class clas = new Class();
        //    Instructor instructor = (Instructor)Session["Instructor"];
        //    Student student = new Student();
        //    Section section = new Section();

        //    DataTable dt = new DataTable();


        //    dt.Columns.Add("Student Name");
        //    dt.Columns.Add("Class Name");
        //    dt.Columns.Add("Instructor Name");
        //    dt.Columns.Add("Section Name");
        //    foreach (TermClass tc in tClassList)
        //    {

        //        clas = clas.GetById(tc.ClassId);
        //        student = student.GetById(tc.StudentId);
        //        section = section.GetById(tc.SectionId);

        //        string className = clas.Name;
        //        string instructorName = instructor.FirstName + " " + instructor.LastName;
        //        string studentName = student.FirstName + " " + student.LastName;
        //        string sectionName = section.Name;

        //        dt.Rows.Add(studentName, className, instructorName, sectionName);


        //    }
        //}

        protected void btnEditAttendance_Click(object sender, EventArgs e)
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
            Guid classID = new Guid(ddlSelectClass.SelectedValue);

            foreach (TermClass tc in tClassList.List)
            {
                if (tc.InstructorId == instructor.Id)
                {
                    if (tc.SectionId == sectionID)
                    {
                        if (tc.ClassId == classID)
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
                }                
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

}