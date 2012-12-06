using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AceProject.Models
{
    public class TaskObjects
    {
        #region Private Member

        private int _taskId;
        private string _projectName;
        private string _moduleName;
        private string _screenName;
        private string _taskName;
        private string _estimateHours;
        private string _priority;
        private string _creator;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _assigned;
        private string _startTime;
        private string _endTime;
        private string _Reviewer;
        private string _status;
        private string _comments;
        private bool _activeFlag;

        #endregion


        #region Public Member

        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }

        public string ScreenName
        {
            get { return _screenName; }
            set { _screenName = value; }
        }

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        public string EstimateHours
        {
            get { return _estimateHours; }
            set { _estimateHours = value; }
        }

        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string Assigned
        {
            get { return _assigned; }
            set { _assigned = value; }
        }

        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public string Reviewer
        {
            get { return _Reviewer; }
            set { _Reviewer = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public bool ActiveFlag
        {
            get { return _activeFlag; }
            set { _activeFlag = value; }
        }

        #endregion
    }
}