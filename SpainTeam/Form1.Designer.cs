namespace SpainTeam
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            mainlabel = new Label();
            responselabel = new Label();
            addteam = new Button();
            deleteteam = new Button();
            updateteam = new Button();
            SearchBar = new TextBox();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            TeamName = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            Wins = new DataGridViewTextBoxColumn();
            Losses = new DataGridViewTextBoxColumn();
            Draws = new DataGridViewTextBoxColumn();
            GoalsScored = new DataGridViewTextBoxColumn();
            GoalsConceded = new DataGridViewTextBoxColumn();
            teamBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teamBindingSource).BeginInit();
            SuspendLayout();
            // 
            // mainlabel
            // 
            mainlabel.AutoSize = true;
            mainlabel.Font = new Font("Hanson", 20F, FontStyle.Bold);
            mainlabel.Location = new Point(111, -1);
            mainlabel.Name = "mainlabel";
            mainlabel.Size = new Size(595, 34);
            mainlabel.TabIndex = 7;
            mainlabel.Text = "Spain Team Managment Panel";
            mainlabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // responselabel
            // 
            responselabel.AutoSize = true;
            responselabel.Font = new Font("Stencil", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            responselabel.Location = new Point(78, 54);
            responselabel.Name = "responselabel";
            responselabel.Size = new Size(115, 24);
            responselabel.TabIndex = 5;
            responselabel.Text = "Response:";
            // 
            // addteam
            // 
            addteam.BackColor = SystemColors.GradientInactiveCaption;
            addteam.Location = new Point(650, 50);
            addteam.Name = "addteam";
            addteam.Size = new Size(138, 54);
            addteam.TabIndex = 8;
            addteam.Text = "Add new team";
            addteam.UseVisualStyleBackColor = false;
            addteam.Click += addteam_Click_1;
            // 
            // deleteteam
            // 
            deleteteam.BackColor = SystemColors.GradientInactiveCaption;
            deleteteam.Location = new Point(362, 50);
            deleteteam.Name = "deleteteam";
            deleteteam.Size = new Size(138, 54);
            deleteteam.TabIndex = 9;
            deleteteam.Text = "Delete team";
            deleteteam.UseVisualStyleBackColor = false;
            deleteteam.Click += deleteteam_Click_1;
            // 
            // updateteam
            // 
            updateteam.BackColor = SystemColors.GradientInactiveCaption;
            updateteam.Location = new Point(506, 50);
            updateteam.Name = "updateteam";
            updateteam.Size = new Size(138, 54);
            updateteam.TabIndex = 10;
            updateteam.Text = "Update team";
            updateteam.UseVisualStyleBackColor = false;
            updateteam.Click += updateteam_Click_1;
            // 
            // SearchBar
            // 
            SearchBar.Location = new Point(78, 81);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(278, 23);
            SearchBar.TabIndex = 11;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, TeamName, City, Wins, Losses, Draws, GoalsScored, GoalsConceded });
            dataGridView1.DataSource = teamBindingSource;
            dataGridView1.Location = new Point(78, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(694, 319);
            dataGridView1.TabIndex = 12;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // TeamName
            // 
            TeamName.DataPropertyName = "TeamName";
            TeamName.HeaderText = "TeamName";
            TeamName.Name = "TeamName";
            // 
            // City
            // 
            City.DataPropertyName = "City";
            City.HeaderText = "City";
            City.Name = "City";
            City.Width = 50;
            // 
            // Wins
            // 
            Wins.DataPropertyName = "Wins";
            Wins.HeaderText = "Wins";
            Wins.Name = "Wins";
            Wins.Width = 50;
            // 
            // Losses
            // 
            Losses.DataPropertyName = "Losses";
            Losses.HeaderText = "Losses";
            Losses.Name = "Losses";
            // 
            // Draws
            // 
            Draws.DataPropertyName = "Draws";
            Draws.HeaderText = "Draws";
            Draws.Name = "Draws";
            // 
            // GoalsScored
            // 
            GoalsScored.DataPropertyName = "GoalsScored";
            GoalsScored.HeaderText = "GoalsScored";
            GoalsScored.Name = "GoalsScored";
            // 
            // GoalsConceded
            // 
            GoalsConceded.DataPropertyName = "GoalsConceded";
            GoalsConceded.HeaderText = "GoalsConceded";
            GoalsConceded.Name = "GoalsConceded";
            // 
            // teamBindingSource
            // 
            teamBindingSource.DataSource = typeof(DAL.Entities.Team);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(SearchBar);
            Controls.Add(updateteam);
            Controls.Add(deleteteam);
            Controls.Add(addteam);
            Controls.Add(responselabel);
            Controls.Add(mainlabel);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)teamBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainlabel;
        private Label responselabel;
        private Button addteam;
        private Button deleteteam;
        private Button updateteam;
        private TextBox SearchBar;
        private BindingSource teamBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn Wins;
        private DataGridViewTextBoxColumn Losses;
        private DataGridViewTextBoxColumn Draws;
        private DataGridViewTextBoxColumn GoalsScored;
        private DataGridViewTextBoxColumn GoalsConceded;
    }
}
