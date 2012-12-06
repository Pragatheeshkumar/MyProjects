using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AceProject.Models.DAL
{
    public class Task
    {

        public string create(TaskObjects obj)
        {
            string TaskId = string.Empty;

            SqlConnection con = new SqlConnection("Data Source=RTBS1\\SQLEXPRESS;Initial Catalog=ACEPROJECT;Persist Security Info=True;User ID=sa;Password=*rtbs123");
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_CreateTask", con);
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("IsSave", true));
                cmd.Parameters.Add(new SqlParameter("TaskID", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("ProjectName", obj.ProjectName));
                cmd.Parameters.Add(new SqlParameter("ModuleName", obj.ModuleName));
                cmd.Parameters.Add(new SqlParameter("ScreenName", obj.ScreenName));
                cmd.Parameters.Add(new SqlParameter("Task", obj.TaskName));
                cmd.Parameters.Add(new SqlParameter("EstimateHours", obj.EstimateHours));
                cmd.Parameters.Add(new SqlParameter("Priority", obj.Priority));
                cmd.Parameters.Add(new SqlParameter("Creator", obj.Creator));
                cmd.Parameters.Add(new SqlParameter("StartDate", obj.StartDate));
                cmd.Parameters.Add(new SqlParameter("EndDate", obj.EndDate));
                cmd.Parameters.Add(new SqlParameter("Assigned", obj.Assigned));
                cmd.Parameters.Add(new SqlParameter("StartTime", obj.StartTime));
                cmd.Parameters.Add(new SqlParameter("EndTime", obj.EndTime));
                cmd.Parameters.Add(new SqlParameter("Reviewer", obj.Reviewer));
                cmd.Parameters.Add(new SqlParameter("Status", obj.Status));
                cmd.Parameters.Add(new SqlParameter("Comments", obj.Comments));
                SqlParameter param = new SqlParameter("@@guid", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                TaskId = param.Value.ToString();
                obj.TaskId = Convert.ToInt16(TaskId);

            }
            return TaskId;
        }

        public Boolean Update(TaskObjects obj)
        {
            //string TaskId = string.Empty;

            SqlConnection con = new SqlConnection("Data Source=RTBS1\\SQLEXPRESS;Initial Catalog=ACEPROJECT;Persist Security Info=True;User ID=sa;Password=*rtbs123");
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_CreateTask", con);
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("IsSave", false));
                cmd.Parameters.Add(new SqlParameter("TaskID", obj.TaskId));
                cmd.Parameters.Add(new SqlParameter("ProjectName", obj.ProjectName));
                cmd.Parameters.Add(new SqlParameter("ModuleName", obj.ModuleName));
                cmd.Parameters.Add(new SqlParameter("ScreenName", obj.ScreenName));
                cmd.Parameters.Add(new SqlParameter("Task", obj.TaskName));
                cmd.Parameters.Add(new SqlParameter("EstimateHours", obj.EstimateHours));
                cmd.Parameters.Add(new SqlParameter("Priority", obj.Priority));
                cmd.Parameters.Add(new SqlParameter("Creator", obj.Creator));
                cmd.Parameters.Add(new SqlParameter("StartDate", obj.StartDate));
                cmd.Parameters.Add(new SqlParameter("EndDate", obj.EndDate));
                cmd.Parameters.Add(new SqlParameter("Assigned", obj.Assigned));
                cmd.Parameters.Add(new SqlParameter("StartTime", obj.StartTime));
                cmd.Parameters.Add(new SqlParameter("EndTime", obj.EndTime));
                cmd.Parameters.Add(new SqlParameter("Reviewer", obj.Reviewer));
                cmd.Parameters.Add(new SqlParameter("Status", obj.Status));
                cmd.Parameters.Add(new SqlParameter("Comments", obj.Comments));
                SqlParameter param = new SqlParameter("@@guid", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

            }
            return true;
        }

        public Boolean delete(TaskObjects obj)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            using (con = new SqlConnection("Data Source=RTBS1\\SQLEXPRESS;Initial Catalog=ACEPROJECT;Persist Security Info=True;User ID=sa;Password=*rtbs123"))
            {
                con.Open();

                using (cmd = new SqlCommand("Sp_DeleteTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("TaskID", obj.TaskId));
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }


        public List<TaskObjects> LsitTask()
        {

            List<TaskObjects> Classlist = new List<TaskObjects>();
            TaskObjects objclass = null;
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection("Data Source=RTBS1\\SQLEXPRESS;Initial Catalog=ACEPROJECT;Persist Security Info=True;User ID=sa;Password=*rtbs123");
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_ListTask", con);
            {
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objclass = new TaskObjects();
                    objclass.TaskId = Convert.ToInt16(reader["TaskID"]);
                    objclass.ProjectName = Convert.ToString(reader["ProjectName"]);
                    objclass.ModuleName = Convert.ToString(reader["ModuleName"]);
                    objclass.ScreenName = Convert.ToString(reader["ScreenName"]);
                    objclass.TaskName = Convert.ToString(reader["Task"]);
                    objclass.EstimateHours = Convert.ToString(reader["EstimateHours"]);

                    objclass.Priority = Convert.ToString(reader["Priority"]);
                    objclass.Creator = Convert.ToString(reader["Creator"]);
                    objclass.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    objclass.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    objclass.Assigned = Convert.ToString(reader["Assigned"]);


                    objclass.StartTime = Convert.ToString(reader["StartTime"]);
                    objclass.EndTime = Convert.ToString(reader["EndTime"]);
                    objclass.Reviewer = Convert.ToString(reader["Reviewer"]);
                    objclass.Status = Convert.ToString(reader["Status"]);
                    objclass.Comments = Convert.ToString(reader["Comments"]);

                    Classlist.Add(objclass);
                }
                reader.Close();
                return Classlist;
            }

        }

    }
}