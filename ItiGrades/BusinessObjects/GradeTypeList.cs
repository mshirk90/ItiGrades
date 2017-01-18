using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class GradeTypeList : Event
    {
        #region Private Members
        private BindingList<GradeType> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<GradeType> List
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
        public GradeTypeList GetById(Guid Id)
        {
            Database database = new Database("ITIGrades");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblGradeTypeGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                GradeType gradetype = new GradeType();
                gradetype.Initialize(dr);
                gradetype.InitializeBusinessData(dr);
                _List.Add(gradetype);
            }
            return this;
        }
        public GradeTypeList Save()
        {
            foreach (GradeType gradetype in _List)
            {
                if (gradetype.IsSavable() == true)
                {
                    gradetype.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (GradeType grade in _List)
            {
                if (grade.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public GradeTypeList GetAll()
        {
            Database database = new Database("ITIGrades");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblGradeTypeGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                GradeType gradetype = new GradeType();
                gradetype.Initialize(dr);
                gradetype.InitializeBusinessData(dr);
                gradetype.IsNew = false;
                gradetype.IsDirty = false;
                gradetype.Savable += GradeType_Savable;
                _List.Add(gradetype);
            }

            return this;
        }
        #endregion

        #region Public Events
        private void GradeType_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new GradeType();
            GradeType gradetype = (GradeType)e.NewObject;
            gradetype.Savable += GradeType_Savable;
        }
        #endregion

        #region Construction
        public GradeTypeList()
        {
            _List = new BindingList<GradeType>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}