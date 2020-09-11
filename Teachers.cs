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
    public partial class Teachers : Form
    {
        private string givenConnectionString;

        public Teachers(string connectionString)
        {
            givenConnectionString = connectionString;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            labelTeachersNames.ForeColor = Color.Red;
            labelTeachersLessons.ForeColor = Color.Red;
            richTextBoxTeachersLessons.ForeColor = Color.Orange;

            foreach(Member aMember in Queries.members)
            {
                if(aMember.Master == 1)
                {
                    listBoxTeachersNames.Items.Add(aMember);
                }
            }
        }

        private void listBoxTeachersNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Member SelectedTeacher = (Member)listBoxTeachersNames.SelectedItem;
                
            List<DateTime> selectedTeacherLessonsTime = Queries.LessonsTimeOfSelectedTeacher(SelectedTeacher.MemberID);

            richTextBoxTeachersLessons.Text = String.Empty;

            for (int i = 0; i < selectedTeacherLessonsTime.Count; i++)
            {
                if (i == 0)
                {
                    richTextBoxTeachersLessons.Text = selectedTeacherLessonsTime[i].ToString();
                }
                else
                {
                    richTextBoxTeachersLessons.Text += Environment.NewLine + selectedTeacherLessonsTime[i].ToString();
                }

                richTextBoxTeachersLessons.SelectionColor = Color.Orange;
            }
        }

        private void listBoxTeachersNames_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
            Brushes.Orange : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(
            (sender as ListBox).Items[e.Index].ToString(), e.Font,
                new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
}
