using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;
using System.Web.Security;


namespace BusinessObjects
{
    public class Instructor : HeaderData
    {
        #region Private Members
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private string _Email = string.Empty;
        private string _Password = String.Empty;
        private bool _EmailSent = false;
        private bool _IsPasswordPending = true;
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

        public String Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }
        public String Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    base.IsDirty = true;
                    Boolean Savable = IsSavable();
                    SavableEventArgs e = new SavableEventArgs(Savable);
                    RaiseEvent(e);
                }
            }
        }
        public BrokenRuleList BrokenRules
        {
            get { return _BrokenRules; }
        }
        public Boolean EmailSent
        {
            get { return _EmailSent; }
            set { _EmailSent = value; }
        }
        public bool IsPasswordPending
        {
            get
            {
                return _IsPasswordPending;
            }
            set
            {
                if (_IsPasswordPending != value)
                {
                    _IsPasswordPending = value;
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
                database.Command.CommandText = "tblInstructorINSERT";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@IsPasswordPending", SqlDbType.Bit).Value = _IsPasswordPending;



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
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@IsPasswordPending", SqlDbType.Bit).Value = _IsPasswordPending;


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
            Database database = new Database("DB_109645_projectfinal");
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
            _Email = dr["Email"].ToString();
            _Password = dr["Password"].ToString();
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
        public Instructor Login(String email, String password)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblInstructorLogin";
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
        public Instructor Register(String FirstName, String LastName, String Email)
        {
            // Generate a new 12-character password with 1 non-alphanumeric character
            String Password = Membership.GeneratePassword(12, 1);
            try
            {
                Database database = new Database("DB_109645_projectfinal");
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblInstructorINSERT";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                database.Command.Parameters.Add("@IsPasswordPending", SqlDbType.Bit).Value = _IsPasswordPending;

                _FirstName = FirstName;
                _LastName = LastName;
                _Email = Email;
                _Password = Password;

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
        public Instructor Exists(string email)
        {
            bool result = false;
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblInstructorExists";
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
