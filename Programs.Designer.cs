namespace JZF003First
{
    partial class Programs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewJogaPrograms = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMinutes = new System.Windows.Forms.TextBox();
            this.textBoxHour = new System.Windows.Forms.TextBox();
            this.labelExercise = new System.Windows.Forms.Label();
            this.labelTeacher = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.comboBoxExercise = new System.Windows.Forms.ComboBox();
            this.comboBox1Teachers = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonAddNewEvent = new System.Windows.Forms.Button();
            this.buttonUpdateChosenEvent = new System.Windows.Forms.Button();
            this.buttonDeleteChosenEvent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJogaPrograms)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewJogaPrograms
            // 
            this.dataGridViewJogaPrograms.AllowUserToAddRows = false;
            this.dataGridViewJogaPrograms.AllowUserToResizeColumns = false;
            this.dataGridViewJogaPrograms.AllowUserToResizeRows = false;
            this.dataGridViewJogaPrograms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewJogaPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJogaPrograms.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewJogaPrograms.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewJogaPrograms.Name = "dataGridViewJogaPrograms";
            this.dataGridViewJogaPrograms.RowHeadersVisible = false;
            this.dataGridViewJogaPrograms.RowHeadersWidth = 62;
            this.dataGridViewJogaPrograms.RowTemplate.Height = 21;
            this.dataGridViewJogaPrograms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJogaPrograms.Size = new System.Drawing.Size(463, 130);
            this.dataGridViewJogaPrograms.TabIndex = 0;
            this.dataGridViewJogaPrograms.Tag = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMinutes);
            this.groupBox1.Controls.Add(this.textBoxHour);
            this.groupBox1.Controls.Add(this.labelExercise);
            this.groupBox1.Controls.Add(this.labelTeacher);
            this.groupBox1.Controls.Add(this.labelTime);
            this.groupBox1.Controls.Add(this.labelDate);
            this.groupBox1.Controls.Add(this.comboBoxExercise);
            this.groupBox1.Controls.Add(this.comboBox1Teachers);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(8, 155);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(465, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Új esemény felvétele/kijelölt esemény szerkesztése";
            // 
            // textBoxMinutes
            // 
            this.textBoxMinutes.Location = new System.Drawing.Point(100, 54);
            this.textBoxMinutes.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMinutes.MaxLength = 2;
            this.textBoxMinutes.Name = "textBoxMinutes";
            this.textBoxMinutes.Size = new System.Drawing.Size(33, 20);
            this.textBoxMinutes.TabIndex = 5;
            // 
            // textBoxHour
            // 
            this.textBoxHour.Location = new System.Drawing.Point(63, 54);
            this.textBoxHour.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxHour.MaxLength = 2;
            this.textBoxHour.Name = "textBoxHour";
            this.textBoxHour.Size = new System.Drawing.Size(33, 20);
            this.textBoxHour.TabIndex = 4;
            // 
            // labelExercise
            // 
            this.labelExercise.AutoSize = true;
            this.labelExercise.Location = new System.Drawing.Point(240, 57);
            this.labelExercise.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExercise.Name = "labelExercise";
            this.labelExercise.Size = new System.Drawing.Size(55, 13);
            this.labelExercise.TabIndex = 6;
            this.labelExercise.Text = "Gyakorlat:";
            // 
            // labelTeacher
            // 
            this.labelTeacher.AutoSize = true;
            this.labelTeacher.Location = new System.Drawing.Point(253, 23);
            this.labelTeacher.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(42, 13);
            this.labelTeacher.TabIndex = 5;
            this.labelTeacher.Text = "Oktató:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(10, 56);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(46, 13);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "Időpont:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(10, 25);
            this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(41, 13);
            this.labelDate.TabIndex = 3;
            this.labelDate.Text = "Dátum:";
            // 
            // comboBoxExercise
            // 
            this.comboBoxExercise.FormattingEnabled = true;
            this.comboBoxExercise.Location = new System.Drawing.Point(305, 53);
            this.comboBoxExercise.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxExercise.Name = "comboBoxExercise";
            this.comboBoxExercise.Size = new System.Drawing.Size(156, 21);
            this.comboBoxExercise.TabIndex = 6;
            // 
            // comboBox1Teachers
            // 
            this.comboBox1Teachers.FormattingEnabled = true;
            this.comboBox1Teachers.Location = new System.Drawing.Point(305, 19);
            this.comboBox1Teachers.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1Teachers.Name = "comboBox1Teachers";
            this.comboBox1Teachers.Size = new System.Drawing.Size(156, 21);
            this.comboBox1Teachers.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(63, 23);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // buttonAddNewEvent
            // 
            this.buttonAddNewEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddNewEvent.Location = new System.Drawing.Point(8, 242);
            this.buttonAddNewEvent.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewEvent.Name = "buttonAddNewEvent";
            this.buttonAddNewEvent.Size = new System.Drawing.Size(120, 50);
            this.buttonAddNewEvent.TabIndex = 0;
            this.buttonAddNewEvent.Text = "Új esemény felvétele";
            this.buttonAddNewEvent.UseVisualStyleBackColor = true;
            this.buttonAddNewEvent.Click += new System.EventHandler(this.buttonAddNewEvent_Click);
            // 
            // buttonUpdateChosenEvent
            // 
            this.buttonUpdateChosenEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdateChosenEvent.Location = new System.Drawing.Point(183, 242);
            this.buttonUpdateChosenEvent.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdateChosenEvent.Name = "buttonUpdateChosenEvent";
            this.buttonUpdateChosenEvent.Size = new System.Drawing.Size(120, 50);
            this.buttonUpdateChosenEvent.TabIndex = 1;
            this.buttonUpdateChosenEvent.Text = "Kijelölt esemény frissítése";
            this.buttonUpdateChosenEvent.UseVisualStyleBackColor = true;
            this.buttonUpdateChosenEvent.Click += new System.EventHandler(this.buttonUpdateChosenEvent_Click);
            // 
            // buttonDeleteChosenEvent
            // 
            this.buttonDeleteChosenEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteChosenEvent.Location = new System.Drawing.Point(353, 242);
            this.buttonDeleteChosenEvent.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteChosenEvent.Name = "buttonDeleteChosenEvent";
            this.buttonDeleteChosenEvent.Size = new System.Drawing.Size(120, 50);
            this.buttonDeleteChosenEvent.TabIndex = 2;
            this.buttonDeleteChosenEvent.Text = "Kijelölt esemény törlése";
            this.buttonDeleteChosenEvent.UseVisualStyleBackColor = true;
            this.buttonDeleteChosenEvent.Click += new System.EventHandler(this.buttonDeleteChosenEvent_Click);
            // 
            // Programs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 300);
            this.Controls.Add(this.buttonAddNewEvent);
            this.Controls.Add(this.buttonUpdateChosenEvent);
            this.Controls.Add(this.buttonDeleteChosenEvent);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewJogaPrograms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Programs";
            this.Text = "Programs";
            this.Load += new System.EventHandler(this.Programs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJogaPrograms)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJogaPrograms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxMinutes;
        private System.Windows.Forms.TextBox textBoxHour;
        private System.Windows.Forms.Label labelExercise;
        private System.Windows.Forms.Label labelTeacher;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ComboBox comboBoxExercise;
        private System.Windows.Forms.ComboBox comboBox1Teachers;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonAddNewEvent;
        private System.Windows.Forms.Button buttonUpdateChosenEvent;
        private System.Windows.Forms.Button buttonDeleteChosenEvent;
    }
}