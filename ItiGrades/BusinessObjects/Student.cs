using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;
using System.Web.Security;


namespace BusinessObjects
{
    public class Student : HeaderData
    {
        #region Private Members
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private string _FullName = string.Empty;
        private Guid _DepartmentId = Guid.Empty;
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

        public String FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public BrokenRuleList BrokenRules
        {
            get { return _BrokenRules; }
        }

        public Guid DepartmentId
        {
            get { return _DepartmentId; }
            set
            {
                if (_DepartmentId != value)
                {
                    _DepartmentId = value;
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
                database.Command.CommandText = "tblStudentINSERT";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = _FullName;
                database.Command.Parameters.Add("@DepartmentId", SqlDbType.UniqueIdentifier).Value = _DepartmentId;


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
                database.Command.CommandText = "tblStudentUPDATE";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@FullName", SqlDbType.VarChar).Value = _FullName;
                database.Command.Parameters.Add("@DepartmentId", SqlDbType.UniqueIdentifier).Value = _DepartmentId;

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
                database.Command.CommandText = "tblStudentDELETE";

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


        public Student GetById(Guid id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentGetById";
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
            _FullName = dr["FullName"].ToString();
            _DepartmentId = (Guid)dr["DepartmentId"];
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
        public Student Save()
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
        public Student Login(String email, String password)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentLogin";
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

            dt = database.ExecuteQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
                return this;
            }
            else
            {
                return null; // typically a good idea to have only one entry and one exit per method
            }
        }
        public Student Register(String FirstName, String LastName, String Email)
        {
            // Generate a new 12-character password with 1 non-alphanumeric character
            String Password = Membership.GeneratePassword(12, 1);
            try
            {
                Database database = new Database("DB_109645_projectfinal");
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblStudentINSERT";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;

                _FirstName = FirstName;
                _LastName = LastName;

                base.IsDirty = true;

                if (this.IsSavable() == true)
                {
                    // Provides the empty buckets
                    base.Initialize(database, Guid.Empty);
                    database.ExecuteNonQuery();

                    // Unloads the full buckets into the object
                    base.Initialize(database.Command);
                    base.IsNew = false;
                }
                else
                {
                    throw new Exception("Invalid Register Data.");
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return this;
        }
        public Student Exists(string email)
        {
            bool result = false;
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblStudentExists";
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;

            dt = database.ExecuteQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
                return this;
            }
            else
            {
                return null; // typically a good idea to have only one entry and one exit per method
            }
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
