namespace RestAPIforToDos
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listViewToDos = new ListView();
            descriptionBox = new RichTextBox();
            titleBox = new TextBox();
            groupBox1 = new GroupBox();
            todoTimePicker = new DateTimePicker();
            buttonCreate = new Button();
            label2 = new Label();
            label1 = new Label();
            todoCalendar = new MonthCalendar();
            buttonDelete = new Button();
            buttonDone = new Button();
            label3 = new Label();
            buttonShowDone = new Button();
            txtboxUpdTitle = new TextBox();
            label4 = new Label();
            txtboxUpdateDesc = new RichTextBox();
            upDownComplete = new NumericUpDown();
            label5 = new Label();
            timePickerUpd = new DateTimePicker();
            buttonUpdate = new Button();
            checkBoxDone = new CheckBox();
            buttonReload = new Button();
            label6 = new Label();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upDownComplete).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listViewToDos
            // 
            listViewToDos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listViewToDos.Location = new Point(9, 237);
            listViewToDos.Name = "listViewToDos";
            listViewToDos.Size = new Size(526, 288);
            listViewToDos.TabIndex = 0;
            listViewToDos.UseCompatibleStateImageBehavior = false;
            listViewToDos.View = View.Details;
            listViewToDos.SelectedIndexChanged += listViewToDos_SelectedIndexChanged;
            // 
            // descriptionBox
            // 
            descriptionBox.Location = new Point(97, 57);
            descriptionBox.Name = "descriptionBox";
            descriptionBox.Size = new Size(219, 74);
            descriptionBox.TabIndex = 1;
            descriptionBox.Text = "";
            // 
            // titleBox
            // 
            titleBox.Location = new Point(61, 28);
            titleBox.Name = "titleBox";
            titleBox.Size = new Size(125, 27);
            titleBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(todoTimePicker);
            groupBox1.Controls.Add(buttonCreate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(descriptionBox);
            groupBox1.Controls.Add(titleBox);
            groupBox1.Location = new Point(395, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 142);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add a task";
            // 
            // todoTimePicker
            // 
            todoTimePicker.Location = new Point(192, 28);
            todoTimePicker.MinDate = new DateTime(2024, 12, 1, 0, 0, 0, 0);
            todoTimePicker.Name = "todoTimePicker";
            todoTimePicker.Size = new Size(256, 27);
            todoTimePicker.TabIndex = 5;
            // 
            // buttonCreate
            // 
            buttonCreate.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonCreate.Location = new Point(324, 61);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(125, 70);
            buttonCreate.TabIndex = 6;
            buttonCreate.Text = "Add";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 81);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 4;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 31);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 3;
            label1.Text = "Title";
            // 
            // todoCalendar
            // 
            todoCalendar.Location = new Point(12, 18);
            todoCalendar.MinDate = new DateTime(2024, 12, 5, 0, 0, 0, 0);
            todoCalendar.Name = "todoCalendar";
            todoCalendar.TabIndex = 5;
            todoCalendar.DateSelected += todoCalendar_DateSelected;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDelete.Location = new Point(12, 532);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonDone
            // 
            buttonDone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDone.Location = new Point(112, 531);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(121, 29);
            buttonDone.TabIndex = 7;
            buttonDone.Text = "Mark as done";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += buttonDone_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 103);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 8;
            label3.Text = "Title : ";
            // 
            // buttonShowDone
            // 
            buttonShowDone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonShowDone.Location = new Point(260, 531);
            buttonShowDone.Name = "buttonShowDone";
            buttonShowDone.Size = new Size(161, 29);
            buttonShowDone.TabIndex = 9;
            buttonShowDone.Text = "Show done";
            buttonShowDone.UseVisualStyleBackColor = true;
            buttonShowDone.Click += buttonShowDone_Click;
            // 
            // txtboxUpdTitle
            // 
            txtboxUpdTitle.Location = new Point(107, 100);
            txtboxUpdTitle.Name = "txtboxUpdTitle";
            txtboxUpdTitle.Size = new Size(125, 27);
            txtboxUpdTitle.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 167);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 11;
            label4.Text = "Description : ";
            // 
            // txtboxUpdateDesc
            // 
            txtboxUpdateDesc.Location = new Point(107, 141);
            txtboxUpdateDesc.Name = "txtboxUpdateDesc";
            txtboxUpdateDesc.Size = new Size(219, 74);
            txtboxUpdateDesc.TabIndex = 13;
            txtboxUpdateDesc.Text = "";
            // 
            // upDownComplete
            // 
            upDownComplete.Location = new Point(107, 221);
            upDownComplete.Name = "upDownComplete";
            upDownComplete.Size = new Size(54, 27);
            upDownComplete.TabIndex = 14;
            upDownComplete.ValueChanged += upDownComplete_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 223);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 15;
            label5.Text = "Complete : ";
            // 
            // timePickerUpd
            // 
            timePickerUpd.Location = new Point(116, 254);
            timePickerUpd.MinDate = new DateTime(2024, 12, 1, 0, 0, 0, 0);
            timePickerUpd.Name = "timePickerUpd";
            timePickerUpd.Size = new Size(256, 27);
            timePickerUpd.TabIndex = 16;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonUpdate.Location = new Point(275, 287);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(100, 50);
            buttonUpdate.TabIndex = 17;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // checkBoxDone
            // 
            checkBoxDone.AutoSize = true;
            checkBoxDone.Location = new Point(259, 102);
            checkBoxDone.Name = "checkBoxDone";
            checkBoxDone.Size = new Size(67, 24);
            checkBoxDone.TabIndex = 18;
            checkBoxDone.Text = "Done";
            checkBoxDone.UseVisualStyleBackColor = true;
            checkBoxDone.CheckedChanged += checkBoxDone_CheckedChanged;
            // 
            // buttonReload
            // 
            buttonReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonReload.Location = new Point(427, 531);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(85, 29);
            buttonReload.TabIndex = 19;
            buttonReload.Text = "Show All";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click += reloadButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 261);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 20;
            label6.Text = "Date of Expiry :";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(checkBoxDone);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(buttonUpdate);
            groupBox2.Controls.Add(timePickerUpd);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(upDownComplete);
            groupBox2.Controls.Add(txtboxUpdateDesc);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtboxUpdTitle);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(541, 252);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(395, 351);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Edit a task";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 629);
            Controls.Add(groupBox2);
            Controls.Add(buttonReload);
            Controls.Add(buttonShowDone);
            Controls.Add(buttonDone);
            Controls.Add(buttonDelete);
            Controls.Add(todoCalendar);
            Controls.Add(groupBox1);
            Controls.Add(listViewToDos);
            MinimumSize = new Size(820, 620);
            Name = "MainForm";
            Text = "ToDo App";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)upDownComplete).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox descriptionBox;
        private TextBox titleBox;
        private GroupBox groupBox1;
        private MonthCalendar todoCalendar;
        private Label label2;
        private Label label1;
        private Button buttonCreate;
        private ListView listViewToDos;
        private DateTimePicker todoTimePicker;
        private Button buttonDelete;
        private Button buttonDone;
        private Label label3;
        private Button buttonShowDone;
        private TextBox txtboxUpdTitle;
        private Label label4;
        private RichTextBox txtboxUpdateDesc;
        private NumericUpDown upDownComplete;
        private Label label5;
        private DateTimePicker timePickerUpd;
        private Button buttonUpdate;
        private CheckBox checkBoxDone;
        private Button buttonReload;
        private Label label6;
        private GroupBox groupBox2;
    }
}
