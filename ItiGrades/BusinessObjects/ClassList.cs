using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class ClassList : Event
    {
        #region Private Members
        private BindingList<Class> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Class> List
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
        public ClassList GetById(Guid Id)
        {
            Database database = new Database("ITIGrades");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblClassGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Class classes = new Class();
                classes.Initialize(dr);
                classes.InitializeBusinessData(dr);
                _List.Add(classes);
            }
            return this;
        }
        public ClassList Save()
        {
            foreach (Class classes in _List)
            {
                if (classes.IsSavable() == true)
                {
                    classes.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Class classes in _List)
            {
                if (classes.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public ClassList GetAll()
        {
            Database database = new Database("ITIGrades");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblClassGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                Class classes = new Class();
                classes.Initialize(dr);
                classes.InitializeBusinessData(dr);
                classes.IsNew = false;
                classes.IsDirty = false;
                classes.Savable += Class_Savable;
                _List.Add(classes);
            }

            return this;
        }
        #endregion

        #region Public Events
        private void Class_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Class();
            Class classes = (Class)e.NewObject;
            classes.Savable += Class_Savable;
        }
        #endregion

        #region Construction
        public ClassList()
        {
            _List = new BindingList<Class>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}