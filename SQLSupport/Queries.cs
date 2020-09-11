using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SQLSupport
{
    public class Queries
    {
        public delegate void SQLConnectionError(string message);
        public static event SQLConnectionError CEPrintout;

        public static List<Member> members = new List<Member>();
        public static List<Pose> poses = new List<Pose>();

        public static void DataFromTxt (string fileURL)
        {
            string aLine = String.Empty;

            using (StreamReader sr = new StreamReader(fileURL))
            {
                sr.ReadLine();

                while((aLine = sr.ReadLine()) != null)
                {
                    if(aLine.Contains(';'))
                    {
                        break;
                    }

                    aLine = aLine.Substring(1,aLine.Length-3).Replace(@"'",String.Empty);

                    string[] split = aLine.Split(',');

                    members.Add(new Member(split[0],Convert.ToInt32(split[1].Trim())));
                }

                sr.ReadLine();
                sr.ReadLine();

                while((aLine = sr.ReadLine()) != null)
                {
                    if(aLine.Contains(';'))
                    {
                        break;
                    }

                    poses.Add(new Pose(aLine.Substring(2,aLine.Length-5)));
                }

            }

        }

        public static void MemberDataUpload()
        {           
            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.MembersUpload,connection);

                    connection.Open();

                    command.Parameters.Add("@MemberName", SqlDbType.VarChar);
                    command.Parameters.Add("@Master", SqlDbType.Bit);

                    for (int i = 0; i < members.Count; i++)
                    {

                        command.Parameters["@MemberName"].Value = members[i].MemberName;
                        command.Parameters["@Master"].Value = members[i].Master;

                        command.ExecuteNonQuery();
                    }

                }

            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }

        }
            
        public static void MembersDataDownload()
        {
            members.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.MembersDownload,connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        members.Add(new Member(Convert.ToInt32(reader[0]), reader[1].ToString(),Convert.ToInt32(reader[2])));
                    }
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }
        }

        public static void PosesUpload()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.PosesUpload, connection);

                    command.Parameters.Add("@PoseName",SqlDbType.VarChar);

                    connection.Open();

                    for(int i = 0; i < poses.Count; i++)
                    {
                        command.Parameters["@PoseName"].Value = poses[i].PoseName;

                        command.ExecuteNonQuery();
                    }

                }

            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }
        }

        public static void PosesDownload()
        {
            poses.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.PoseDownload,connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        poses.Add(new Pose(Convert.ToInt32(reader[0]),reader[1].ToString()));
                    }
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }
        }

        public static bool DatabaseCheck ()
        {
            object checkResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.DatabaseCheck,connection);

                    connection.Open();

                    checkResult = command.ExecuteScalar();
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }

            return checkResult != null;
        }

        public static bool TableIsEmpty(int table)
        {
            object checkresult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(table == 1 ? SQLData.DatabaseTablePosesCheck : SQLData.DatabaseTableMembersCheck,connection);

                    connection.Open();

                    checkresult = command.ExecuteScalar();
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }

            return checkresult == null;
        }

        public static int TableCount(int table)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(table == 1 ? SQLData.DatabaseTablePosesCount : SQLData.DatabaseTableMembersCount,connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    result = Convert.ToInt32(reader[0]);
                }

            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }

            return result;
        }

        public static List<Schedule> SchedulesDownload ()
        {
            List<Schedule> lessons = new List<Schedule>();

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.ScheduleDownload,connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        lessons.Add(new Schedule(Convert.ToInt32(reader[0]),Convert.ToDateTime(reader[1]),Convert.ToInt32(reader[2]),reader[3].ToString(),Convert.ToInt32(reader[4])));
                    }
                }
            }
            catch(Exception a)
            {
                if(CEPrintout!= null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }
            return lessons;
        }

        public static List<DateTime> LessonsTimeOfSelectedTeacher(int selectedMeberId)
        {
            List<DateTime> timeOfLessons = new List<DateTime>();

            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.LessonsOfSelectedTeacher,connection);

                    command.Parameters.AddWithValue("@MemberID",selectedMeberId);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        timeOfLessons.Add(Convert.ToDateTime(reader[0]));
                    }
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }

            return timeOfLessons;
        }

        public static void ScheduleInsert (DateTime timeOfLessons, int instructor, string students, int curriculum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.ScheduleInsert,connection);

                    command.Parameters.Add("@TimeOfLesson",SqlDbType.DateTime);
                    command.Parameters["@TimeOfLesson"].Value = timeOfLessons;

                    command.Parameters.Add("@Instructor",SqlDbType.Int);
                    command.Parameters["@Instructor"].Value = instructor;

                    command.Parameters.Add("@Students",SqlDbType.VarChar);
                    command.Parameters["@Students"].Value = students;

                    command.Parameters.Add("@Curriculum",SqlDbType.Int);
                    command.Parameters["@Curriculum"].Value = curriculum;

                    connection.Open();

                    command.ExecuteNonQuery();
                }

            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }
        }

        public static void ScheduleUpdate (int scheduleID,DateTime modifiedTimeOfLesson, int modifiedInstructor, int modifiedCurriculum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.ScheduleUpdate,connection);

                    command.Parameters.Add("@ScheduleID",SqlDbType.Int);
                    command.Parameters["@ScheduleID"].Value = scheduleID;

                    command.Parameters.Add("@TimeOfLesson",SqlDbType.DateTime);
                    command.Parameters["@TimeOfLesson"].Value = modifiedTimeOfLesson;

                    command.Parameters.Add("@Instructor",SqlDbType.Int);
                    command.Parameters["@Instructor"].Value = modifiedInstructor;

                    command.Parameters.Add("@Curriculum",SqlDbType.Int);
                    command.Parameters["@Curriculum"].Value = modifiedCurriculum;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }
        }

        public static void ScheduleDelete (int selectedSceduleID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(SQLData.ConncectionString))
                {
                    SqlCommand command = new SqlCommand(SQLData.ScheduleDelete,connection);

                    command.Parameters.Add("@ScheduleID",SqlDbType.Int);
                    command.Parameters["@ScheduleID"].Value = selectedSceduleID;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception a)
            {
                if(CEPrintout != null)
                {
                    CEPrintout.Invoke(a.Message);
                }
            }

        }



    }

    



}
