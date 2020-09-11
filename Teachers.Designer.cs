namespace JZF003First
{
    partial class Teachers
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
            this.listBoxTeachersNames = new System.Windows.Forms.ListBox();
            this.richTextBoxTeachersLessons = new System.Windows.Forms.RichTextBox();
            this.labelTeachersNames = new System.Windows.Forms.Label();
            this.labelTeachersLessons = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTeachersNames
            // 
            this.listBoxTeachersNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxTeachersNames.FormattingEnabled = true;
            this.listBoxTeachersNames.ItemHeight = 12;
            this.listBoxTeachersNames.Location = new System.Drawing.Point(12, 32);
            this.listBoxTeachersNames.Name = "listBoxTeachersNames";
            this.listBoxTeachersNames.Size = new System.Drawing.Size(237, 148);
            this.listBoxTeachersNames.TabIndex = 0;
            this.listBoxTeachersNames.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxTeachersNames_DrawItem);
            this.listBoxTeachersNames.SelectedIndexChanged += new System.EventHandler(this.listBoxTeachersNames_SelectedIndexChanged);
            // 
            // richTextBoxTeachersLessons
            // 
            this.richTextBoxTeachersLessons.Location = new System.Drawing.Point(12, 218);
            this.richTextBoxTeachersLessons.Name = "richTextBoxTeachersLessons";
            this.richTextBoxTeachersLessons.Size = new System.Drawing.Size(237, 136);
            this.richTextBoxTeachersLessons.TabIndex = 1;
            this.richTextBoxTeachersLessons.Text = "";
            // 
            // labelTeachersNames
            // 
            this.labelTeachersNames.AutoSize = true;
            this.labelTeachersNames.Location = new System.Drawing.Point(12, 9);
            this.labelTeachersNames.Name = "labelTeachersNames";
            this.labelTeachersNames.Size = new System.Drawing.Size(65, 20);
            this.labelTeachersNames.TabIndex = 2;
            this.labelTeachersNames.Text = "Oktatók";
            // 
            // labelTeachersLessons
            // 
            this.labelTeachersLessons.AutoSize = true;
            this.labelTeachersLessons.Location = new System.Drawing.Point(12, 195);
            this.labelTeachersLessons.Name = "labelTeachersLessons";
            this.labelTeachersLessons.Size = new System.Drawing.Size(145, 20);
            this.labelTeachersLessons.TabIndex = 3;
            this.labelTeachersLessons.Text = "Kijelölt oktatói órák:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 369);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(237, 32);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Vissza";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // Teachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 413);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTeachersLessons);
            this.Controls.Add(this.labelTeachersNames);
            this.Controls.Add(this.richTextBoxTeachersLessons);
            this.Controls.Add(this.listBoxTeachersNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Teachers";
            this.Text = "Oktatók";
            this.Load += new System.EventHandler(this.Teachers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTeachersNames;
        private System.Windows.Forms.RichTextBox richTextBoxTeachersLessons;
        private System.Windows.Forms.Label labelTeachersNames;
        private System.Windows.Forms.Label labelTeachersLessons;
        private System.Windows.Forms.Button buttonCancel;
    }
}