using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;


namespace BusinessObjects
{
    public class Attendance : HeaderData
    {
        #region Private Members
        private bool _Absent = false;
        private int _TotalAbsences = 0;
        private Guid _StudentId = Guid.Empty;
        private Guid _ClassId = Guid.Empty;
        #endregion

        #region Public Properties   
            
        public Boolean Absent
        {
            get { return _Absent; }
            set
            {
                if (_Absent != value)
                {
                    _Absent = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }
        public int TotalAbsences
        {
            get { return _TotalAbsences; }
            set { _TotalAbsences = value; }
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

        #endregion

        #region Private Methods
        private Boolean Insert(Database database)
        {
            Boolean result = true;
            _TotalAbsences = _TotalAbsences + 1;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblAttendanceINSERT";
                database.Command.Parameters.Add("@TotalAbsences", SqlDbType.Bit).Value = _TotalAbsences;
                database.Command.Parameters.Add("@Absent", SqlDbType.Bit).Value = _Absent;
                database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = _StudentId;
                database.Command.Parameters.Add("@ClassId", SqlDbType.UniqueIdentifier).Value = _ClassId;

               

                // Provides the empty buckets
                base.Initialize(database, Guid.Empty);
                database.ExecuteNonQuery();

                // Unloads the full buckets into the object
                base.Initialize(database.Command);


            }
            catch (Exception e)
            {
                result = true;
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
                database.Command.CommandText = "tblAttendanceUPDATE";
                database.Command.Parameters.Add("@Absent", SqlDbType.Bit).Value = _Absent;
                database.Command.Parameters.Add("@TotalAbsences", SqlDbType.Bit).Value = _TotalAbsences;
                database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = _StudentId;
                database.Command.Parameters.Add("@ClassId", SqlDbType.UniqueIdentifier).Value = _ClassId;


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
                database.Command.CommandText = "tblAttendanceDELETE";

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


        public Attendance GetById(Guid id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblAttendanceGetById";
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
        public Attendance GetByStudentId(Guid studentId)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblAttendanceGetByStudentId";
            database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = studentId;
            dt = database.ExecuteQuery();
            if (dt != null && dt.Rows.Count >= 1)
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

            _Absent = (bool)dr["Absent"];
            _TotalAbsences = (int)dr["TotalAbsences"];
            _StudentId = (Guid)dr["StudentId"];
            _ClassId = (Guid)dr["ClassId"];
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
        public Attendance Save()
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
