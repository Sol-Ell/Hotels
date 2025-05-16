namespace L4_14._Hotels
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openTravelersFileToolStripMenuItem = new ToolStripMenuItem();
            openHotelsFileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            tasksToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            loadedHotelsDataToolStripMenuItem = new ToolStripMenuItem();
            loadedTravelersDataToolStripMenuItem = new ToolStripMenuItem();
            tasksToolStripMenuItem1 = new ToolStripMenuItem();
            hotelsChosenByTravelersToolStripMenuItem2 = new ToolStripMenuItem();
            hotelsNotChosenByTravelersToolStripMenuItem = new ToolStripMenuItem();
            travelersWhoSpentNoMoreThanMToolStripMenuItem = new ToolStripMenuItem();
            travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1 = new ToolStripMenuItem();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            textBox1 = new TextBox();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, tasksToolStripMenuItem, tasksToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(882, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openTravelersFileToolStripMenuItem, openHotelsFileToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openTravelersFileToolStripMenuItem
            // 
            openTravelersFileToolStripMenuItem.Name = "openTravelersFileToolStripMenuItem";
            openTravelersFileToolStripMenuItem.Size = new Size(213, 26);
            openTravelersFileToolStripMenuItem.Text = "Open travelers file";
            openTravelersFileToolStripMenuItem.Click += OpenTravelers;
            // 
            // openHotelsFileToolStripMenuItem
            // 
            openHotelsFileToolStripMenuItem.Name = "openHotelsFileToolStripMenuItem";
            openHotelsFileToolStripMenuItem.Size = new Size(213, 26);
            openHotelsFileToolStripMenuItem.Text = "Open hotels file";
            openHotelsFileToolStripMenuItem.Click += OpenHotels;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(213, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += Save;
            // 
            // tasksToolStripMenuItem
            // 
            tasksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logsToolStripMenuItem, loadedHotelsDataToolStripMenuItem, loadedTravelersDataToolStripMenuItem });
            tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            tasksToolStripMenuItem.Size = new Size(59, 24);
            tasksToolStripMenuItem.Text = "Show";
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(236, 26);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += Logs;
            // 
            // loadedHotelsDataToolStripMenuItem
            // 
            loadedHotelsDataToolStripMenuItem.Name = "loadedHotelsDataToolStripMenuItem";
            loadedHotelsDataToolStripMenuItem.Size = new Size(236, 26);
            loadedHotelsDataToolStripMenuItem.Text = "Loaded hotels data";
            loadedHotelsDataToolStripMenuItem.Click += LoadedHotelsData;
            // 
            // loadedTravelersDataToolStripMenuItem
            // 
            loadedTravelersDataToolStripMenuItem.Name = "loadedTravelersDataToolStripMenuItem";
            loadedTravelersDataToolStripMenuItem.Size = new Size(236, 26);
            loadedTravelersDataToolStripMenuItem.Text = "Loaded travelers data";
            loadedTravelersDataToolStripMenuItem.Click += LoadedTravelersData;
            // 
            // tasksToolStripMenuItem1
            // 
            tasksToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { hotelsChosenByTravelersToolStripMenuItem2, hotelsNotChosenByTravelersToolStripMenuItem, travelersWhoSpentNoMoreThanMToolStripMenuItem, travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1 });
            tasksToolStripMenuItem1.Name = "tasksToolStripMenuItem1";
            tasksToolStripMenuItem1.Size = new Size(56, 24);
            tasksToolStripMenuItem1.Text = "Tasks";
            // 
            // hotelsChosenByTravelersToolStripMenuItem2
            // 
            hotelsChosenByTravelersToolStripMenuItem2.Name = "hotelsChosenByTravelersToolStripMenuItem2";
            hotelsChosenByTravelersToolStripMenuItem2.Size = new Size(447, 26);
            hotelsChosenByTravelersToolStripMenuItem2.Text = "Hotels chosen by travelers";
            hotelsChosenByTravelersToolStripMenuItem2.Click += HotelsChosenByTravelers;
            // 
            // hotelsNotChosenByTravelersToolStripMenuItem
            // 
            hotelsNotChosenByTravelersToolStripMenuItem.Name = "hotelsNotChosenByTravelersToolStripMenuItem";
            hotelsNotChosenByTravelersToolStripMenuItem.Size = new Size(447, 26);
            hotelsNotChosenByTravelersToolStripMenuItem.Text = "Hotels not chosen by travelers";
            hotelsNotChosenByTravelersToolStripMenuItem.Click += HotelsNotChosenByTravelers;
            // 
            // travelersWhoSpentNoMoreThanMToolStripMenuItem
            // 
            travelersWhoSpentNoMoreThanMToolStripMenuItem.Name = "travelersWhoSpentNoMoreThanMToolStripMenuItem";
            travelersWhoSpentNoMoreThanMToolStripMenuItem.Size = new Size(447, 26);
            travelersWhoSpentNoMoreThanMToolStripMenuItem.Text = "Travelers who spent no more than M";
            travelersWhoSpentNoMoreThanMToolStripMenuItem.Click += TravelersWhoSpentNoMoreThanM;
            // 
            // travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1
            // 
            travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1.Name = "travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1";
            travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1.Size = new Size(447, 26);
            travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1.Text = "Travellers who plan to spend the most nights in hotels";
            travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1.Click += TravellersWhoPlanToSpendTheMostNightsInHotels;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.Font = new Font("Consolas", 9F);
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.Location = new Point(12, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(858, 364);
            listBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(40, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(830, 27);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 3;
            label1.Text = "M";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 427);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(882, 26);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 453);
            Controls.Add(statusStrip1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ListBox listBox1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openTravelersFileToolStripMenuItem;
        private ToolStripMenuItem openHotelsFileToolStripMenuItem;
        private ToolStripMenuItem tasksToolStripMenuItem;
        private TextBox textBox1;
        private Label label1;
        private ToolStripMenuItem loadedTravelersDataToolStripMenuItem;
        private ToolStripMenuItem loadedHotelsDataToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem tasksToolStripMenuItem1;
        private ToolStripMenuItem hotelsChosenByTravelersToolStripMenuItem2;
        private ToolStripMenuItem hotelsNotChosenByTravelersToolStripMenuItem;
        private ToolStripMenuItem travelersWhoSpentNoMoreThanMToolStripMenuItem;
        private ToolStripMenuItem travellersWhoPlanToSpendTheMostNightsInHotelsToolStripMenuItem1;
    }
}
