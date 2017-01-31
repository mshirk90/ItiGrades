using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseHelper;


namespace BusinessObjects
{
    public class Section : HeaderData
    {
        #region Private Members
        private string _Name = string.Empty;
        #endregion

        #region Public Properties       
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
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
                database.Command.CommandText = "tblSectionInsert";
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;

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
                database.Command.CommandText = "tblSectionUPDATE";
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;


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
                database.Command.CommandText = "tblSectionDELETE";

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


        public Section GetById(Guid id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = System.Data.CommandType.StoredProcedure;
            database.Command.CommandText = "tblSectionGetById";
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
            _Name = dr["Name"].ToString();
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
        public Section Save()
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
