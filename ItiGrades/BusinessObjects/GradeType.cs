using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;


namespace BusinessObjects
{
    public class GradeType : HeaderData
    {
        #region Private Members
        private string _Type = string.Empty;
        private DateTime _Date = DateTime.MaxValue;
        private decimal _Weight = 0;
        #endregion

        #region Public Properties       
        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
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
                database.Command.CommandText = "tblGradeTypeINSERT";
                database.Command.Parameters.Add("@Type", SqlDbType.VarChar).Value = _Type;
                database.Command.Parameters.Add("@Date", SqlDbType.DateTime).Value = _Date;
                database.Command.Parameters.Add("@Weight", SqlDbType.Decimal).Value = _Weight;

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
                database.Command.CommandText = "tblGradeTypeUPDATE";
                database.Command.Parameters.Add("@Type", SqlDbType.VarChar).Value = _Type;
                database.Command.Parameters.Add("@Date", SqlDbType.DateTime).Value = _Date;
                database.Command.Parameters.Add("@Weight", SqlDbType.Decimal).Value = _Weight;


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
                database.Command.CommandText = "tblGradeTypeDELETE";

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
        public GradeType GetById(Guid id)
        {
            Database database = new Database("ITIGrades");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblGradeTypeGetById";
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

            _Type = dr["Type"].ToString();
            _Date = (DateTime)dr["Date"];
            _Weight = (decimal)dr["Weight"];
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
        public GradeType Save()
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
