using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;


namespace BusinessObjects
{
    public class Instructor : HeaderData
    {
        #region Private Members
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private BrokenRuleList _BrokenRules = new BrokenRuleList();
        #endregion

        #region Public Properties       
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
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
                database.Command.CommandText = "tblInstructorINSERT";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;

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
                database.Command.CommandText = "tblInstructorUPDATE";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;


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
                database.Command.CommandText = "tblInstructorDELETE";

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
        private Boolean IsValid()
        {
            Boolean result = true;

            _BrokenRules.List.Clear();

            if (_FirstName == string.Empty)
            {
                result = false;
                BrokenRule rule = new BrokenRule("Invalid First Name. Cannot be empty");
                _BrokenRules.List.Add(rule);
            }
            if (_LastName == string.Empty)
            {
                result = false;
                BrokenRule rule = new BrokenRule("Invalid Last Name. Cannot be empty");
                _BrokenRules.List.Add(rule);
            }

            return result;
        }
        #endregion

        #region Public Methods


        public Instructor GetById(Guid id)
        {
            Database database = new Database("ITIGrades");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblInstructorGetById";
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

            _FirstName = dr["FirstName"].ToString();
            _LastName = dr["LastName"].ToString();
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            if ((base.IsDirty == true) || (IsValid() == true))
            {
                result = true;
            }

            return result;
        }
        public Instructor Save()
        {
            Boolean result = true;
            Database database = new Database("ITIGrades");
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
