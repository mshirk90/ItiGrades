using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;


namespace BusinessObjects
{
    public class TermClass : HeaderData

    {
        #region Private Members
        private Guid _ClassId = Guid.Empty;
        private Guid _InstructorId = Guid.Empty;
        private Guid _StudentId = Guid.Empty;
        private Guid _SectionId = Guid.Empty;
        #endregion

        #region Public Properties   

        public Guid ClassId
        {
            get { return _ClassId; }
            set
            {
                if (_ClassId != value)
                {
                    _ClassId = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }
        public Guid InstructorId
        {
            get { return _InstructorId; }
            set
            {
                if (_InstructorId != value)
                {
                    _InstructorId = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }
        public Guid StudentId
        {
            get { return _StudentId; }
            set
            {
                if (_StudentId != value)
                {
                    _StudentId = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }

        public Guid SectionId
        {
            get { return _SectionId; }
            set
            {
                if (_SectionId != value)
                {
                    _SectionId = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }

        #endregion

        #region Private Methods
        private Boolean Insert(Database database)
        {
            Boolean result = true;

            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblTermClassINSERT";
                database.Command.Parameters.Add("@ClassId", SqlDbType.UniqueIdentifier).Value = _ClassId;
                database.Command.Parameters.Add("@InstructorId", SqlDbType.UniqueIdentifier).Value = _InstructorId;
                database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = _StudentId;
                database.Command.Parameters.Add("@SectionId", SqlDbType.UniqueIdentifier).Value = _SectionId;

                // Provides the empty buckets
                base.Initialize(database, Guid.Empty);
                database.ExecuteNonQuery();

                // Unloads the full buckets into the object
                base.Initialize(database.Command);


            }
            catch (Exception e)
            {
                result = false;
                throw;
            }

            //System.IO.File.Delete(_FilePath);
            return result;
        }
        private Boolean Update(Database database)
        {
            Boolean result = true;

            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblClassUPDATE";
                database.Command.Parameters.Add("@ClassId", SqlDbType.UniqueIdentifier).Value = _ClassId;
                database.Command.Parameters.Add("@InstructorId", SqlDbType.UniqueIdentifier).Value = _InstructorId;
                database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = _StudentId;
                database.Command.Parameters.Add("@SectionId", SqlDbType.UniqueIdentifier).Value = _SectionId;

                // Provides the empty buckets
                base.Initialize(database, base.Id);
                database.ExecuteNonQuery();

                // Unloads the full buckets into the object
                base.Initialize(database.Command);
            }
            catch (Exception e)
            {
                result = false;
                throw;
            }

            return result;
        }
        private Boolean Delete(Database database)
        {
            Boolean result = true;

            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblTermClassDELETE";

                // Provides the empty buckets
                base.Initialize(database, base.Id);
                database.ExecuteNonQuery();

                // Unloads the full buckets into the object
                base.Initialize(database.Command);
            }
            catch (Exception e)
            {
                result = false;
                throw;
            }

            return result;
        }

        #endregion

        #region Public Methods
        public TermClass GetById(Guid id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblTermClassGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
            dt = database.ExecuteQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
            }

            return this;
        }
        public void InitializeBusinessData(DataRow dr)
        {
            _ClassId = (Guid)dr["ClassId"];
            _InstructorId = (Guid)dr["InstructorId"];
            _StudentId = (Guid)dr["StudentId"];
            _SectionId = (Guid)dr["SectionId"];
        }

      

        public Boolean IsSavable()
        {
            Boolean result = false;

            if ((base.IsDirty == true))
            {
                result = true;
            }

            return result;
        }
        public TermClass Save()
        {
            Boolean result = true;
            Database database = new Database("DB_109645_projectfinal");
            if (base.IsNew == true && IsSavable() == true)
            {
                result = Insert(database);
            }
            else if (base.Deleted == true && base.IsDirty)
            {
                result = Delete(database);
            }
            else if (base.IsNew == false && IsSavable() == true)
            {
                result = Update(database);
            }

            if (result == true)
            {
                base.IsDirty = false;
                base.IsNew = false;
            }
            return this;
        }
        #endregion

        #region Public Events

        #endregion

        #region Public Event Handlers

        #endregion

        #region Construction

        #endregion
    }
}
