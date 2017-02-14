using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class TermClassList : Event
    {
        #region Private Members
        private BindingList<TermClass> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<TermClass> List
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
        public TermClassList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblTermClassGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                TermClass termclass = new TermClass();
                termclass.Initialize(dr);
                termclass.InitializeBusinessData(dr);
                _List.Add(termclass);
            }
            return this;
        }

        public TermClassList GetByStudentId(Guid studentId)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblTermClassGetByStudentId";
            database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = studentId;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                TermClass termclass = new TermClass();
                termclass.Initialize(dr);
                termclass.InitializeBusinessData(dr);
                _List.Add(termclass);
            }
            return this;
        }

        public TermClassList Save()
        {
            foreach (TermClass termclass in _List)
            {
                if (termclass.IsSavable() == true)
                {
                    termclass.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (TermClass termclass in _List)
            {
                if (termclass.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public TermClassList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblTermClassGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                TermClass termclass = new TermClass();
                termclass.Initialize(dr);
                termclass.InitializeBusinessData(dr);
                termclass.IsNew = false;
                termclass.IsDirty = false;
                termclass.Savable += TermClass_Savable;
                _List.Add(termclass);
            }

            return this;
        }


        public TermClassList GetClassesByClassId(Guid classId)
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblTermClassGetByClassId";
            database.Command.Parameters.Add("@ClassId", SqlDbType.UniqueIdentifier).Value = classId;

            DataTable dt = database.ExecuteQuery();
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                TermClass termclass = new TermClass();
                termclass.Initialize(dr);
                termclass.InitializeBusinessData(dr);
                _List.Add(termclass);
            }
            return this;
        }


        #endregion

        #region Public Events
        private void TermClass_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Class();
            Class classes = (Class)e.NewObject;
            classes.Savable += TermClass_Savable;
        }
        #endregion

        #region Construction
        public TermClassList()
        {
            _List = new BindingList<TermClass>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}