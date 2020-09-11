using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLSupport
{
    class SQLData
    {
        public const string ConncectionString = @" Data Source=DESKTOP-SHENOF4\SQLEXPRESS; Initial Catalog=jogastudio; Integrated Security=true ";

        public const string DatabaseCheck = @"SELECT database_id FROM sys.databases WHERE Name = 'jogastudio'";

        public const string DatabaseTablePosesCheck = @"SELECT MemberID FROM Poses WHERE MemberID = 1";

        public const string DatabaseTablePosesCount = @"SELECT COUNT(PoseID) FROM Poses";

        public const string DatabaseTableMembersCheck = @"SELECT PoseID FROM Members WHERE PoseID = 1";

        public const string DatabaseTableMembersCount = @"SELECT COUNT(MemberID) FROM Members";

        public const string MembersUpload = @"INSERT INTO Members VALUES(@MemberName, @Master)";

        public const string MembersDownload = @"SELECT MemberID,MemberName,Master FROM Members ORDER BY MemberID";

        public const string PosesUpload = @"INSERT INTO Poses VALUES(@PoseName)";

        public const string PoseDownload = @"SELECT PoseID, PoseName FROM Poses ORDER BY PoseID";

        public const string TeachersDownload = @"SELECT MemberName FROM Members WHERE Master > 0";

        public const string ScheduleDownload = @"SELECT ScheduleID, TimeOfLesson, Instructor,Students,Curriculum FROM Schedule ORDER BY ScheduleID";

        public const string DeleteSelectedSchedule = @"DELETE FROM Schedule WHERE ScheduleID = @SelectedSchedule";

        public const string ScheduleSave = @"INSERT INTO Schedule VALUES(@ScheduleID, @TimeOfLessons,@Instructor,@Students,@Curriculum)";

        public const string LessonsOfSelectedTeacher = @"SELECT s.TimeOfLesson FROM Schedule s
                                                        JOIN Members m ON m.MemberID = s.Instructor
                                                        WHERE s.Instructor = @MemberID";

        public const string ScheduleInsert = @"INSERT INTO Schedule(TimeOfLesson, Instructor, Students, Curriculum)
                                             VALUES (@TimeOfLesson, @Instructor, @Students, @Curriculum)";

        public const string ScheduleUpdate = @"UPDATE Schedule
                                             SET TimeOfLesson = @TimeOfLesson, Instructor = @Instructor, Curriculum = @Curriculum
                                             WHERE ScheduleID = @ScheduleID";

        public const string ScheduleDelete = @"DELETE Schedule WHERE ScheduleID = @ScheduleID";
    }
}
