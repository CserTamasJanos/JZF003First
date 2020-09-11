using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLSupport
{
    class JogaData
    {
    }

    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int Master { get; set; }

        public Member (string memberName, int master)
        {
            MemberName = memberName;
            Master = master;
        }

        public Member (int memberID, string memberName, int master)
        {
            MemberID = memberID;
            MemberName = memberName;
            Master = master;
        }

        public override string ToString()
        {
            return MemberName;
        }
    }

    public class Pose
    {
        public int PoseId { get; set; }
        public string PoseName { get; set; }

        public Pose (string poseName)
        {
            PoseName = poseName;
        }
        public Pose (int poseID, string poseName)
        {
            PoseId = poseID;
            PoseName = poseName;
        }

        public override string ToString()
        {
            return PoseName;
        }
    }

    public class Schedule
    {
        public int ScheduleID { get; set; }
        public DateTime TimeOfLesson { get; set; }
        public int Instructor { get; set; }
        public string Students { get; set; }
        public int Curriculum { get; set; }

        public Schedule (int scheduleID, DateTime timeOfLesson, int instructor, string students, int curriculum)
        {
            ScheduleID = scheduleID;
            TimeOfLesson = timeOfLesson;
            Instructor = instructor;
            Students = students;
            Curriculum = curriculum;
        }
    }
}
