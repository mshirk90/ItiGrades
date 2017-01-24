using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class InstructorList : Event
    {
        #region Private Members
        private BindingList<Instructor> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Instructor> List
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
        public InstructorList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblInstructorGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Instructor instructor = new Instructor();
                instructor.Initialize(dr);
                instructor.InitializeBusinessData(dr);
                _List.Add(instructor);
            }
            return this;
        }
        public InstructorList Save()
        {
            foreach (Instructor instructor in _List)
            {
                if (instructor.IsSavable() == true)
                {
                    instructor.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Instructor instructor in _List)
            {
                if (instructor.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public InstructorList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblInstructorGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                Instructor instructor = new Instructor();
                instructor.Initialize(dr);
                instructor.InitializeBusinessData(dr);
                instructor.IsNew = false;
                instructor.IsDirty = false;
                instructor.Savable += Instructor_Savable;
                _List.Add(instructor);
            }

            return this;
        }
        #endregion

        #region Public Events
        private void Instructor_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Instructor();
            Instructor instructor = (Instructor)e.NewObject;
            instructor.Savable += Instructor_Savable;
        }
        #endregion

        #region Construction
        public InstructorList()
        {
            _List = new BindingList<Instructor>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}