using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class StudentList : Event
    {
        #region Private Members
        private BindingList<Student> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Student> List
        {
            get { return _List; }
        }
        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public StudentList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Student student = new Student();
                student.Initialize(dr);
                student.InitializeBusinessData(dr);
                _List.Add(student);
            }
            return this;
        }

        public StudentList GetStudentsById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Student student = new Student();
                student.Initialize(dr);
                student.InitializeBusinessData(dr);
                _List.Add(student);
            }
            return this;
        }

        public StudentList Save()
        {
            foreach (Student student in _List)
            {
                if (student.IsSavable() == true)
                {
                    student.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Student student in _List)
            {
                if (student.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public StudentList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentGetAll";

            DataTable dt = database.ExecuteQuery();   

            foreach (DataRow dr in dt.Rows)
            {
                Student student = new Student();
                student.Initialize(dr);
                student.InitializeBusinessData(dr);
                student.IsNew = false;
                student.IsDirty = false;
                student.Savable += Student_Savable;
                _List.Add(student);
            }

            return this;
        }
        #endregion

        #region Public Events
        private void Student_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Student();
            Student student = (Student)e.NewObject;
            student.Savable += Student_Savable;
        }
        #endregion

        #region Construction
        public StudentList()
        {
            _List = new BindingList<Student>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}