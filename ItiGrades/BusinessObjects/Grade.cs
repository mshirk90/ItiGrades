using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;


namespace BusinessObjects
{
    public class Grade : HeaderData
    {
        #region Private Members

        private string _LetterGrade = string.Empty;
        private decimal _Grades = 0;
        private Guid _StudentId = Guid.Empty;

        #endregion

        #region Public Properties
               
        public String LetterGrade
        {
            get { return _LetterGrade; }
            set { _LetterGrade = value; }
        }
        public decimal Grades
        {
            get { return _Grades; }
            set { _Grades = value; }
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

        #endregion

        #region Private Methods

        private Boolean Insert(Database database)
        {
            Boolean result = true;

            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblGradeINSERT";
                database.Command.Parameters.Add("@LetterGrade", SqlDbType.VarChar).Value = _LetterGrade;
                database.Command.Parameters.Add("@Grade", SqlDbType.Decimal).Value = _Grades;
                database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = _StudentId;

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
                database.Command.CommandText = "tblGradeUPDATE";
                database.Command.Parameters.Add("@LetterGrade", SqlDbType.VarChar).Value = _LetterGrade;
                database.Command.Parameters.Add("@Grade", SqlDbType.Decimal).Value = _Grades;
                database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = _StudentId;


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
                database.Command.CommandText = "tblGradeDELETE";

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

        public Grade GetById(Guid id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblGradeGetById";
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

            _LetterGrade = dr["LetterGrade"].ToString();
            _Grades = (decimal)dr["Grade"];
            _StudentId = (Guid)dr["StudentId"];
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
        public Grade Save()
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
