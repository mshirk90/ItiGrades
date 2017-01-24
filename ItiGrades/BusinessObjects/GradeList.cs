using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class GradeList : Event
    {
        #region Private Members
        private BindingList<Grade> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Grade> List
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
        public GradeList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblGradeGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Grade grade = new Grade();
                grade.Initialize(dr);
                grade.InitializeBusinessData(dr);
                _List.Add(grade);
            }
            return this;
        }
        public GradeList Save()
        {
            foreach (Grade grade in _List)
            {
                if (grade.IsSavable() == true)
                {
                    grade.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Grade grade in _List)
            {
                if (grade.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public GradeList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblGradeGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                Grade grade = new Grade();
                grade.Initialize(dr);
                grade.InitializeBusinessData(dr);
                grade.IsNew = false;
                grade.IsDirty = false;
                grade.Savable += Grade_Savable;
                _List.Add(grade);
            }

            return this;
        }
        #endregion

        #region Public Events
        private void Grade_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Grade();
            Grade grade = (Grade)e.NewObject;
            grade.Savable += Grade_Savable;
        }
        #endregion

        #region Construction
        public GradeList()
        {
            _List = new BindingList<Grade>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}