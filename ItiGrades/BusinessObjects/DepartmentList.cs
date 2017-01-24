using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class DepartmentList : Event
    {
        #region Private Members
        private BindingList<Department> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Department> List
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
        public DepartmentList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblDepartmentGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Department department = new Department();
                department.Initialize(dr);
                department.InitializeBusinessData(dr);
                _List.Add(department);
            }
            return this;
        }
        public DepartmentList Save()
        {
            foreach (Department department in _List)
            {
                if (department.IsSavable() == true)
                {
                    department.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Department department in _List)
            {
                if (department.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public DepartmentList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblDepartmentGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                Department department = new Department();
                department.Initialize(dr);
                department.InitializeBusinessData(dr);
                department.IsNew = false;
                department.IsDirty = false;
                department.Savable += Department_Savable;
                _List.Add(department);
            }

            return this;
        }
        #endregion

        #region Public Events
        private void Department_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Department();
            Department department = (Department)e.NewObject;
            department.Savable += Department_Savable;
        }
        #endregion

        #region Construction
        public DepartmentList()
        {
            _List = new BindingList<Department>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}