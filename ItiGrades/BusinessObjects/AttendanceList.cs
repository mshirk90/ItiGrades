using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class AttendanceList : Event
    {
        #region Private Members
        private BindingList<Attendance> _List;
        private String _path = String.Empty;
        #endregion

        #region Public Properties
        public BindingList<Attendance> List
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
        public AttendanceList GetById(Guid Id)
        {
            Database database = new Database("DB_109645_projectfinal");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblAttendanceGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Attendance attendance = new Attendance();
                attendance.Initialize(dr);
                attendance.InitializeBusinessData(dr);
                _List.Add(attendance);
            }
            return this;
        }
        public AttendanceList Save()
        {
            foreach (Attendance attendance in _List)
            {
                if (attendance.IsSavable() == true)
                {
                    attendance.Save();
                }
            }

            return this;
        }
        public Boolean IsSavable()
        {
            Boolean result = false;

            foreach (Attendance attendance in _List)
            {
                if (attendance.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public AttendanceList GetAll()
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblAttendanceGetAll";

            DataTable dt = database.ExecuteQuery();

            foreach (DataRow dr in dt.Rows)
            {
                Attendance attendance = new Attendance();
                attendance.Initialize(dr);
                attendance.InitializeBusinessData(dr);
                attendance.IsNew = false;
                attendance.IsDirty = false;
                attendance.Savable += Attendance_Savable;
                _List.Add(attendance);
            }

            return this;
        }

        public AttendanceList GetAttendanceByStudentID(Guid studentId)
        {
            Database database = new Database("DB_109645_projectfinal");

            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblAttendanceGetByStudentId";
            database.Command.Parameters.Add("@StudentId", SqlDbType.UniqueIdentifier).Value = studentId;

            DataTable dt = database.ExecuteQuery();
            dt = database.ExecuteQuery();
            foreach (DataRow dr in dt.Rows)
            {
                Attendance attendance = new Attendance();
                attendance.Initialize(dr);
                attendance.InitializeBusinessData(dr);
                _List.Add(attendance);
            }
            return this;
        }
        #endregion

        #region Public Events
        private void Attendance_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
        }
        #endregion

        #region Public Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Attendance();
            Attendance attendance = (Attendance)e.NewObject;
            attendance.Savable += Attendance_Savable;
        }
        #endregion

        #region Construction
        public AttendanceList()
        {
            _List = new BindingList<Attendance>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}