using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class SectionList : Event
    {
        #region Private Members
        private BindingList<Section> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Section> List
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
        public SectionList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblSectionGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Section section = new Section();
                section.Initialize(dr);
                section.InitializeBusinessData(dr);
                _List.Add(section);
            }
            return this;
        }
        public SectionList Save()
        {
            foreach (Section section in _List)
            {
                if (section.IsSavable() == true)
                {
                    section.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Section section in _List)
            {
                if (section.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public SectionList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblSectionGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                Section section = new Section();
                section.Initialize(dr);
                section.InitializeBusinessData(dr);
                section.IsNew = false;
                section.IsDirty = false;
                section.Savable += Section_Savable;
                _List.Add(section);
            }

            return this;
        }       
        #endregion

        #region Public Events
        private void Section_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Section();
            Section section = (Section)e.NewObject;
            section.Savable += Section_Savable;
        }
        #endregion

        #region Construction
        public SectionList()
        {
            _List = new BindingList<Section>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}