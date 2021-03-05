using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLSupport;

namespace JZF003First
{
    public partial class Jogaprogram : Form
    {
        public Jogaprogram()
        {
            InitializeComponent();
        }

        private void buttonTeachers_Click(object sender, EventArgs e)
        {
            Teachers teachers = new Teachers(SQLData.ConncectionString); //Jó így a connectionString átadása, miért kell átadni, mert ez volt a feladat?

            teachers.ShowDialog();
        }

        private void buttonPrograms_Click(object sender, EventArgs e)
        {
            Programs programs = new Programs(SQLData.ConncectionString);

            programs.ShowDialog();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //Nem a YesNoCancel-thasználtam, a mégse és a nemitt ugyan az nem?
            DialogResult closeJoga = MessageBox.Show("Biztosan ki akar lépni?","",MessageBoxButtons.YesNo);

            if(closeJoga == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ErrorPrintOut(string errorMessage) 
        {
            MessageBox.Show(errorMessage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Queries.CEPrintout += ErrorPrintOut;

            pictureBoxMain.Image = Image.FromFile(@"c:\VisualStudioProjects\JZF003First\Accessories\joga_BG.png"); //Nem tettem az URL-eket konstansba, jó lesz így a vizsgán?

            buttonTeachers.ForeColor = buttonPrograms.ForeColor = buttonRegistration.ForeColor = Color.Orange;
            buttonCancel.ForeColor = Color.Red;
            buttonTeachers.BackColor = buttonPrograms.BackColor = buttonRegistration.BackColor = buttonCancel.BackColor = Color.White;

            Queries.DataFromTxt(@"c:\VisualStudioProjects\JZF003First\Accessories\jogaDataRows.txt");//Nem vizsgálom, hogy létezik-e a fájl,ez alapesetben hiba, a vizsgán kell vele foglalkozni?

            int errorCode;

            //Remélem jó így az adatbázis vizsgálat. Vizsgálom, hogy van-e adatbázis, vannak-e táblák, a táblákban van-e adat (a Schedule lehet adat nélkül.), egyáltalán kell ezeket vizsgálni a vizgsán?
            if(Queries.DatabaseIsExist(out errorCode) && Queries.PosesTableIsExist(out errorCode) &&
                Queries.MembersTableExist(out errorCode) && Queries.ScheduleTableIsExist(out errorCode))
            {
                int posesCount = Queries.TableCount(1);
                int membersCount = Queries.TableCount(2);

                if (posesCount == 0 && posesCount != Queries.poses.Count && membersCount == 0 && membersCount != Queries.members.Count)
                {
                    Queries.PosesUpload();
                    Queries.MemberDataUpload();
                }
                else
                {
                    Queries.MembersDataDownload();
                    Queries.PosesDownload();
                }
            }
            else
            {
                string errorText = String.Empty;

                switch(errorCode)
                {
                    case 1:
                        errorText = "Az adatbázis nem létezik.";
                        break;
                    case 2:
                        errorText = "A Poses tábla nem létezik.";
                        break;
                    case 3:
                        errorText = "A Members tábla nem létezik.";
                        break;
                    case 4:
                        errorText = "A Schedule tábla nem létezik.";
                        break;                  
                }

                MessageBox.Show(errorText + " A program így nem használható.");

                this.Close();
            }
        }
    }
}
