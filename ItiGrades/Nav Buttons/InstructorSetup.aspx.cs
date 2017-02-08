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

                lblTitle.Text = "Welcome " + instructor.FirstName + " " + instructor.LastName;

            }
         
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("First Name");
                dt.Columns.Add("Last Name");
                ViewState["StudentNames"] = dt;
                this.BindGrid();
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
            btnAddStudents.Visible = true;
        }
        

        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            tblInsert.Visible = true;
            btnSaveClass.Visible = true;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["StudentNames"];
            dt.Rows.Add(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            ViewState["StudentNames"] = dt;
            this.BindGrid();
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
        }

        protected void BindGrid()
        {
            GridView1.DataSource = (DataTable)ViewState["StudentNames"];
            GridView1.DataBind();

            Session["SaveTable"] = (DataTable)ViewState["StudentNames"];
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
                DataTable dt = Session["SaveTable"] as DataTable;

                foreach(DataRow row in dt.Rows)
                {
                    Student student = new Student();
                    student.FirstName = row[0].ToString();
                    student.LastName = row[1].ToString();
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
                }  
            }
            lblStatus1.Text = "Class Successfully saved!";
            lblStatus1.Visible = true;
            lblStatus2.Text = "Here's a preview of your class..";
            lblStatus2.Visible = true;




            ShowTable(tClassList);
        }

        private void ShowTable(List<TermClass> tClassList)
        {
            Class clas = new Class();
            Instructor instructor = (Instructor)Session["Instructor"];
            Student student = new Student();
            Section section = new Section();

            DataTable dt = new DataTable();


            dt.Columns.Add("Student Name");
            dt.Columns.Add("Class Name");
            dt.Columns.Add("Instructor Name");
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
               
                    dt.Rows.Add(studentName, className, instructorName, sectionName);                

               
            }           
        }


    }
    
}