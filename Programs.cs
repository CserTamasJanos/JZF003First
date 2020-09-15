using SQLSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JZF003First
{
    public partial class Programs : Form
    {
        private List<Schedule> schedules = new List<Schedule>();
        private string givenConnectionString;

        private TimeSpan LessonTime
        {
            get
            {
                return new TimeSpan(Convert.ToInt32(textBoxHour.Text), Convert.ToInt32(textBoxMinutes.Text), 0);
            }
        }

        private Member SelectedTeacher
        {
            get
            {
                return (Member)comboBox1Teachers.SelectedItem;
            }
        }

        private Pose SelectedPose
        {
            get
            {
                return (Pose)comboBoxExercise.SelectedItem;
            }
        }

        private Schedule SelectedSchedule
        {
            get
            {
                int selectedTag;

                if(dataGridViewJogaPrograms.Rows[dataGridViewJogaPrograms.CurrentCell.RowIndex].Cells[0].Tag != null)
                {
                    selectedTag = (int)dataGridViewJogaPrograms.Rows[dataGridViewJogaPrograms.CurrentCell.RowIndex].Cells[0].Tag;
                }
                else
                {
                    selectedTag = schedules[0].ScheduleID;
                }          
                return schedules.FirstOrDefault(x => x.ScheduleID == selectedTag);
            }
        }

        public Programs(string connectionString)
        {
             givenConnectionString = connectionString;

            InitializeComponent();
        }

        private void Programs_Load(object sender, EventArgs e)
        {
            dataGridViewJogaPrograms.ColumnCount = 5;

            dataGridViewJogaPrograms.Columns[0].Name = "Date";
            dataGridViewJogaPrograms.Columns[0].HeaderText = "Dátum";

            dataGridViewJogaPrograms.Columns[1].Name = "Start";
            dataGridViewJogaPrograms.Columns[1].HeaderText = "Kezdés";
            dataGridViewJogaPrograms.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewJogaPrograms.Columns[2].Name = "Teacher";
            dataGridViewJogaPrograms.Columns[2].HeaderText = "Oktató";

            dataGridViewJogaPrograms.Columns[3].Name = "Exercise";
            dataGridViewJogaPrograms.Columns[3].HeaderText = "Gyakorlat";

            dataGridViewJogaPrograms.Columns[4].Name = "NumberOfStudents";
            dataGridViewJogaPrograms.Columns[4].HeaderText = "Létszám";
            dataGridViewJogaPrograms.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach(Member aTeacher in Queries.members)
            {
                if(aTeacher.Master == 1)
                {
                    comboBox1Teachers.Items.Add(aTeacher);
                }
            }

            foreach(Pose aPose in Queries.poses)
            {
                comboBoxExercise.Items.Add(aPose);
            }

            comboBox1Teachers.SelectedItem = comboBox1Teachers.Items[0];
            comboBoxExercise.SelectedItem = comboBoxExercise.Items[0];
            dateTimePicker1.Value = DateTime.Now;
            textBoxHour.Text = "16";
            textBoxMinutes.Text = "00";

            DGVRefresh();

            dataGridViewJogaPrograms.SelectionChanged += selectedRowChanged;
        }

        private void DGVRefresh()
        {
            schedules = Queries.SchedulesDownload();
            dataGridViewJogaPrograms.Rows.Clear();

            foreach (Schedule aSchedule in schedules)
            {
                int rowID = dataGridViewJogaPrograms.Rows.Add();

                DataGridViewRow aRow = dataGridViewJogaPrograms.Rows[rowID];
                aRow.Cells[0].Value = aSchedule.TimeOfLesson.Date.ToString("yyyy/MM/dd");
                aRow.Cells[0].Tag = aSchedule.ScheduleID;

                aRow.Cells[1].Value = aSchedule.TimeOfLesson.Hour.ToString() + ":" + ZeroStyle(aSchedule.TimeOfLesson.Minute);
                
                aRow.Cells[2].Value = Queries.members.FirstOrDefault(x => x.MemberID == aSchedule.Instructor).MemberName;

                aRow.Cells[3].Value = Queries.poses.FirstOrDefault(x => x.PoseId == aSchedule.Curriculum).PoseName;

                aRow.Cells[4].Value = StudentsCount(aSchedule.Students).ToString();
            }
        }

        private int StudentsCount(string students)
        {
            string[] splittedStudents = students.Split('-');

            return students == string.Empty ? 0 :splittedStudents.Length;
        }

        private void ButtonClick(object sender)
        {
            if(TimeFormIsValid(textBoxHour.Text,textBoxHour) && TimeFormIsValid(textBoxMinutes.Text,textBoxMinutes) && (dateTimePicker1.Value.Date + LessonTime) >= DateTime.Now)
            {
                if (TimeIsFree(dateTimePicker1.Value) || sender == buttonDeleteChosenEvent)
                {
                    DialogResult areYouSure = MessageBox.Show(sender == buttonDeleteChosenEvent ? "Biztosan törölni szeretné az órát?" : "Minden adat rendben?", "", MessageBoxButtons.YesNo);

                    if (areYouSure == DialogResult.Yes)
                    {
                        dataGridViewJogaPrograms.SelectionChanged -= selectedRowChanged;

                        if (sender == buttonAddNewEvent)
                        {
                            Queries.ScheduleInsert(dateTimePicker1.Value.Date + LessonTime, SelectedTeacher.MemberID, String.Empty, SelectedPose.PoseId);
                        }
                        else if (sender == buttonUpdateChosenEvent)
                        {
                            Queries.ScheduleUpdate(SelectedSchedule.ScheduleID, dateTimePicker1.Value.Date + LessonTime, SelectedTeacher.MemberID, SelectedPose.PoseId);
                        }
                        else
                        {
                            Queries.ScheduleDelete(SelectedSchedule.ScheduleID);
                        }

                        DGVRefresh();

                        dataGridViewJogaPrograms.SelectionChanged += selectedRowChanged;
                    }
                }
                else
                {
                    MessageBox.Show("Az időpont foglalt, módosítsa az adatokat!");
                }
            }
            else
            {
                MessageBox.Show("Nem megfelelő a megadott idő formátuma, vagy a megadott időpontban a terem nem használható.");
            }
        }

        private void buttonAddNewEvent_Click(object sender, EventArgs e)
        {
            ButtonClick(sender);
        }

        private void buttonUpdateChosenEvent_Click(object sender, EventArgs e)
        {
            ButtonClick(sender);
        }

        private void buttonDeleteChosenEvent_Click(object sender, EventArgs e)
        {
            ButtonClick(sender);
        }

        private bool TimeFormIsValid(string time, TextBox clickedTextBox)
        {
            int convertedTime = -1;
            bool result = Int32.TryParse(time, out convertedTime) &&
                (convertedTime > 6 && (clickedTextBox.TabIndex == 4 && convertedTime < 22) ||
                (clickedTextBox.TabIndex == 5 && (convertedTime == 30 || convertedTime == 0)));

            clickedTextBox.BackColor = !result ? Color.Red : SystemColors.ControlLightLight;

            return result;
        }

        private  bool TimeIsFree (DateTime selectedDate)
        {
            foreach(Schedule aSchedule in schedules)
            {
                if(aSchedule.TimeOfLesson == selectedDate.Date + LessonTime)
                {
                    return false;
                }
            }
            return true;
        }

        private void selectedRowChanged(object sender, EventArgs e)
        {           
            comboBox1Teachers.SelectedItem = Queries.members.FirstOrDefault(x=> x.MemberID == SelectedSchedule.Instructor);
            comboBoxExercise.SelectedItem = Queries.poses.FirstOrDefault(x=> x.PoseId == SelectedSchedule.Curriculum);
            dateTimePicker1.Value = SelectedSchedule.TimeOfLesson.Date;
            textBoxHour.Text = SelectedSchedule.TimeOfLesson.Hour.ToString();
            textBoxMinutes.Text = ZeroStyle(SelectedSchedule.TimeOfLesson.Minute);
        }

        private string ZeroStyle(int zeroNumber)
        {
            return zeroNumber == 0 ? "00" : zeroNumber.ToString();
        }
    }
}
