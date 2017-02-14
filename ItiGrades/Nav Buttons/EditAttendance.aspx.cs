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

        protected void btnSelectClass_Click(object sender, EventArgs e)
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


        protected void btnEditAttendance_Click(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            TermClass termclass = new TermClass();
            Student student = new Student();
            Section section = new Section();
            Class clas = new Class();
            Attendance attendance = new Attendance();

            List<Student> sList = new List<Student>();
            TermClassList tClassList = new TermClassList();
            StudentList studentList = new StudentList();
            DataTable dt = new DataTable();

            tClassList = tClassList.GetAll(); // Get Term classes
            studentList = studentList.GetAll();

            
            dt.Columns.Add("Student Name");
            dt.Columns.Add("Class Name");
            dt.Columns.Add("Instructor Name");
            dt.Columns.Add("Section Name");
            dt.Columns.Add("Total Absences");
            //dt.Columns.Add(new DataColumn("Absent", typeof(CheckBox)));

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
                            attendance = attendance.GetByStudentId(tc.StudentId);
                            string className = clas.Name;
                            string instructorName = instructor.FirstName + " " + instructor.LastName;
                            string studentName = student.FullName;
                            string sectionName = ddlSections.SelectedItem.ToString();
                            int totalAbsences = attendance.TotalAbsences;
                         

                            
                            dt.Rows.Add(studentName, className, instructorName, sectionName, totalAbsences);
                            foreach(Student stud in studentList.List)
                            {
                                if(stud.Id == tc.StudentId)
                                {
                                    sList.Add(stud);
                                }
                            }

                        }                       
                    }
                }                
            }
            if (sList != null)
            {

                ddlSelectStudent.DataSource = sList;
                ddlSelectStudent.DataBind();
                ddlSelectStudent.Items.Add("Choose Student");
                ddlSelectStudent.SelectedValue = "Choose Student";
                ddlSelectStudent.Visible = true;
                btnMarkAbsent.Visible = true;
            }
            Session["SaveTable"] = dt; 

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

  
        private void EditAttendanceTable(DataTable dt)
        {
           

            dt.Columns.Add(new DataColumn("Absent", typeof(bool)));

         
        }

        protected void btnMarkAbsent_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            Student student = new Student();
            Class clas = new Class();

            Guid studentID = new Guid(ddlSelectStudent.SelectedValue);
            Guid classID = new Guid(ddlSelectClass.SelectedValue);

            DataTable dt = new DataTable();
             dt = Session["SaveTable"] as DataTable;

            attendance.StudentId = studentID;
            attendance.ClassId = classID;
            attendance.Absent = true;
            attendance.Save();

            RefreshTable();
        }

        private void RefreshTable()
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            TermClass termclass = new TermClass();
            Student student = new Student();
            Section section = new Section();
            Class clas = new Class();
            Attendance attendance = new Attendance();

            TermClassList tClassList = new TermClassList();
            StudentList studentList = new StudentList();
            DataTable dt = new DataTable();

            tClassList = tClassList.GetAll(); // Get Term classes


            dt.Columns.Add("Student Name");
            dt.Columns.Add("Class Name");
            dt.Columns.Add("Instructor Name");
            dt.Columns.Add("Section Name");
            dt.Columns.Add("Total Absences");

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
                            attendance = attendance.GetByStudentId(tc.StudentId);
                            string className = clas.Name;
                            string instructorName = instructor.FirstName + " " + instructor.LastName;
                            string studentName = student.FullName;
                            string sectionName = ddlSections.SelectedItem.ToString();
                            int totalAbsences = attendance.TotalAbsences;
                            
                            dt.Rows.Add(studentName, className, instructorName, sectionName, totalAbsences);                 

                        }
                    }
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

}