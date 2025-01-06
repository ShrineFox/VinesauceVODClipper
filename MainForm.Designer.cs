using MetroSet_UI.Forms;

namespace VinesauceVODClipper
{
    partial class MainForm : MetroSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tlp_Main = new TableLayoutPanel();
            groupBox_ClipsDir = new GroupBox();
            tlp_ClipsDir = new TableLayoutPanel();
            txt_ClipsDir = new TextBox();
            btn_ClipsDir = new Button();
            groupBox_TxtFile = new GroupBox();
            tlp_TxtFile = new TableLayoutPanel();
            txt_TxtFile = new TextBox();
            btn_TxtFile = new Button();
            groupBox_VideoList = new GroupBox();
            pnl_VideoList = new Panel();
            tlp_VideoList = new TableLayoutPanel();
            lbl_VideoPath = new Label();
            lbl_Title = new Label();
            lbl_StartTime = new Label();
            lbl_EndTime = new Label();
            rtb_Instructions = new RichTextBox();
            menuStrip1 = new MenuStrip();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            reEncodeClipsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            avoidNegativeTimestampsToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox_AvoidNegativeTS = new ToolStripComboBox();
            toggleThemeToolStripMenuItem = new ToolStripMenuItem();
            splitContainer_Main = new SplitContainer();
            tlp_LogAndCreateClipsBtn = new TableLayoutPanel();
            rtb_Log = new RichTextBox();
            btn_CreateClips = new MetroSet_UI.Controls.MetroSetButton();
            tlp_Main.SuspendLayout();
            groupBox_ClipsDir.SuspendLayout();
            tlp_ClipsDir.SuspendLayout();
            groupBox_TxtFile.SuspendLayout();
            tlp_TxtFile.SuspendLayout();
            groupBox_VideoList.SuspendLayout();
            pnl_VideoList.SuspendLayout();
            tlp_VideoList.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Main).BeginInit();
            splitContainer_Main.Panel1.SuspendLayout();
            splitContainer_Main.Panel2.SuspendLayout();
            splitContainer_Main.SuspendLayout();
            tlp_LogAndCreateClipsBtn.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.AllowDrop = true;
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(groupBox_ClipsDir, 0, 1);
            tlp_Main.Controls.Add(groupBox_TxtFile, 0, 0);
            tlp_Main.Controls.Add(groupBox_VideoList, 0, 3);
            tlp_Main.Controls.Add(rtb_Instructions, 0, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(2, 3, 2, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Main.Size = new Size(793, 380);
            tlp_Main.TabIndex = 0;
            // 
            // groupBox_ClipsDir
            // 
            tlp_Main.SetColumnSpan(groupBox_ClipsDir, 2);
            groupBox_ClipsDir.Controls.Add(tlp_ClipsDir);
            groupBox_ClipsDir.Dock = DockStyle.Fill;
            groupBox_ClipsDir.Font = new Font("Microsoft Sans Serif", 9F);
            groupBox_ClipsDir.Location = new Point(2, 60);
            groupBox_ClipsDir.Margin = new Padding(2, 3, 2, 3);
            groupBox_ClipsDir.Name = "groupBox_ClipsDir";
            groupBox_ClipsDir.Padding = new Padding(2, 3, 2, 3);
            groupBox_ClipsDir.Size = new Size(789, 51);
            groupBox_ClipsDir.TabIndex = 5;
            groupBox_ClipsDir.TabStop = false;
            groupBox_ClipsDir.Text = "Output Clips Directory";
            // 
            // tlp_ClipsDir
            // 
            tlp_ClipsDir.ColumnCount = 2;
            tlp_ClipsDir.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tlp_ClipsDir.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_ClipsDir.Controls.Add(txt_ClipsDir, 0, 0);
            tlp_ClipsDir.Controls.Add(btn_ClipsDir, 1, 0);
            tlp_ClipsDir.Dock = DockStyle.Fill;
            tlp_ClipsDir.Location = new Point(2, 20);
            tlp_ClipsDir.Margin = new Padding(2, 3, 2, 3);
            tlp_ClipsDir.Name = "tlp_ClipsDir";
            tlp_ClipsDir.RowCount = 1;
            tlp_ClipsDir.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_ClipsDir.Size = new Size(785, 28);
            tlp_ClipsDir.TabIndex = 0;
            // 
            // txt_ClipsDir
            // 
            txt_ClipsDir.AllowDrop = true;
            txt_ClipsDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_ClipsDir.BorderStyle = BorderStyle.FixedSingle;
            txt_ClipsDir.Location = new Point(2, 3);
            txt_ClipsDir.Margin = new Padding(2, 3, 2, 3);
            txt_ClipsDir.Name = "txt_ClipsDir";
            txt_ClipsDir.Size = new Size(624, 24);
            txt_ClipsDir.TabIndex = 0;
            txt_ClipsDir.TextChanged += OutputDirTxt_Changed;
            txt_ClipsDir.DragDrop += ClipsDir_DragDrop;
            txt_ClipsDir.DragEnter += DragEnter;
            // 
            // btn_ClipsDir
            // 
            btn_ClipsDir.AllowDrop = true;
            btn_ClipsDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_ClipsDir.BackColor = Color.FromArgb(30, 30, 30);
            btn_ClipsDir.ForeColor = Color.Silver;
            btn_ClipsDir.Location = new Point(630, 3);
            btn_ClipsDir.Margin = new Padding(2, 3, 2, 3);
            btn_ClipsDir.Name = "btn_ClipsDir";
            btn_ClipsDir.Size = new Size(153, 22);
            btn_ClipsDir.TabIndex = 1;
            btn_ClipsDir.Text = ". . .";
            btn_ClipsDir.UseVisualStyleBackColor = false;
            btn_ClipsDir.Click += OutputDirBtn_Click;
            btn_ClipsDir.DragDrop += ClipsDir_DragDrop;
            btn_ClipsDir.DragEnter += DragEnter;
            // 
            // groupBox_TxtFile
            // 
            tlp_Main.SetColumnSpan(groupBox_TxtFile, 2);
            groupBox_TxtFile.Controls.Add(tlp_TxtFile);
            groupBox_TxtFile.Dock = DockStyle.Fill;
            groupBox_TxtFile.Font = new Font("Microsoft Sans Serif", 9F);
            groupBox_TxtFile.Location = new Point(2, 3);
            groupBox_TxtFile.Margin = new Padding(2, 3, 2, 3);
            groupBox_TxtFile.Name = "groupBox_TxtFile";
            groupBox_TxtFile.Padding = new Padding(2, 3, 2, 3);
            groupBox_TxtFile.Size = new Size(789, 51);
            groupBox_TxtFile.TabIndex = 0;
            groupBox_TxtFile.TabStop = false;
            groupBox_TxtFile.Text = ".Txt File With Timestamps";
            // 
            // tlp_TxtFile
            // 
            tlp_TxtFile.ColumnCount = 2;
            tlp_TxtFile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tlp_TxtFile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_TxtFile.Controls.Add(txt_TxtFile, 0, 0);
            tlp_TxtFile.Controls.Add(btn_TxtFile, 1, 0);
            tlp_TxtFile.Dock = DockStyle.Fill;
            tlp_TxtFile.Location = new Point(2, 20);
            tlp_TxtFile.Margin = new Padding(2, 3, 2, 3);
            tlp_TxtFile.Name = "tlp_TxtFile";
            tlp_TxtFile.RowCount = 1;
            tlp_TxtFile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_TxtFile.Size = new Size(785, 28);
            tlp_TxtFile.TabIndex = 0;
            // 
            // txt_TxtFile
            // 
            txt_TxtFile.AllowDrop = true;
            txt_TxtFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_TxtFile.BorderStyle = BorderStyle.FixedSingle;
            txt_TxtFile.Location = new Point(2, 3);
            txt_TxtFile.Margin = new Padding(2, 3, 2, 3);
            txt_TxtFile.Name = "txt_TxtFile";
            txt_TxtFile.ReadOnly = true;
            txt_TxtFile.Size = new Size(624, 24);
            txt_TxtFile.TabIndex = 0;
            txt_TxtFile.Click += TxtBtn_Click;
            txt_TxtFile.TextChanged += Txt_Changed;
            txt_TxtFile.DragDrop += TxtFile_DragDrop;
            txt_TxtFile.DragEnter += DragEnter;
            // 
            // btn_TxtFile
            // 
            btn_TxtFile.AllowDrop = true;
            btn_TxtFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_TxtFile.BackColor = Color.FromArgb(30, 30, 30);
            btn_TxtFile.ForeColor = Color.Silver;
            btn_TxtFile.Location = new Point(630, 3);
            btn_TxtFile.Margin = new Padding(2, 3, 2, 3);
            btn_TxtFile.Name = "btn_TxtFile";
            btn_TxtFile.Size = new Size(153, 22);
            btn_TxtFile.TabIndex = 1;
            btn_TxtFile.Text = ". . .";
            btn_TxtFile.UseVisualStyleBackColor = false;
            btn_TxtFile.Click += TxtBtn_Click;
            btn_TxtFile.DragDrop += TxtFile_DragDrop;
            btn_TxtFile.DragEnter += DragEnter;
            // 
            // groupBox_VideoList
            // 
            tlp_Main.SetColumnSpan(groupBox_VideoList, 2);
            groupBox_VideoList.Controls.Add(pnl_VideoList);
            groupBox_VideoList.Dock = DockStyle.Fill;
            groupBox_VideoList.Font = new Font("Microsoft Sans Serif", 9F);
            groupBox_VideoList.Location = new Point(2, 174);
            groupBox_VideoList.Margin = new Padding(2, 3, 2, 3);
            groupBox_VideoList.Name = "groupBox_VideoList";
            groupBox_VideoList.Padding = new Padding(2, 3, 2, 3);
            groupBox_VideoList.Size = new Size(789, 203);
            groupBox_VideoList.TabIndex = 4;
            groupBox_VideoList.TabStop = false;
            groupBox_VideoList.Text = "Videos to Generate Clips From";
            // 
            // pnl_VideoList
            // 
            pnl_VideoList.AllowDrop = true;
            pnl_VideoList.AutoScroll = true;
            pnl_VideoList.Controls.Add(tlp_VideoList);
            pnl_VideoList.Dock = DockStyle.Fill;
            pnl_VideoList.Location = new Point(2, 20);
            pnl_VideoList.Margin = new Padding(2, 3, 2, 3);
            pnl_VideoList.Name = "pnl_VideoList";
            pnl_VideoList.Size = new Size(785, 180);
            pnl_VideoList.TabIndex = 0;
            // 
            // tlp_VideoList
            // 
            tlp_VideoList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_VideoList.AutoSize = true;
            tlp_VideoList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlp_VideoList.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_VideoList.ColumnCount = 5;
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.0952377F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8095245F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.523809F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlp_VideoList.Controls.Add(lbl_VideoPath, 1, 0);
            tlp_VideoList.Controls.Add(lbl_Title, 0, 0);
            tlp_VideoList.Controls.Add(lbl_StartTime, 3, 0);
            tlp_VideoList.Controls.Add(lbl_EndTime, 4, 0);
            tlp_VideoList.Location = new Point(0, 0);
            tlp_VideoList.Margin = new Padding(2, 3, 2, 3);
            tlp_VideoList.Name = "tlp_VideoList";
            tlp_VideoList.RowCount = 1;
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.Size = new Size(741, 22);
            tlp_VideoList.TabIndex = 0;
            // 
            // lbl_VideoPath
            // 
            lbl_VideoPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_VideoPath.AutoSize = true;
            lbl_VideoPath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_VideoPath.Location = new Point(284, 1);
            lbl_VideoPath.Margin = new Padding(2, 0, 2, 0);
            lbl_VideoPath.Name = "lbl_VideoPath";
            lbl_VideoPath.Size = new Size(171, 20);
            lbl_VideoPath.TabIndex = 6;
            lbl_VideoPath.Text = "Video Path";
            // 
            // lbl_Title
            // 
            lbl_Title.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.Location = new Point(3, 1);
            lbl_Title.Margin = new Padding(2, 0, 2, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(276, 20);
            lbl_Title.TabIndex = 5;
            lbl_Title.Text = "Video Title";
            // 
            // lbl_StartTime
            // 
            lbl_StartTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_StartTime.AutoSize = true;
            lbl_StartTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_StartTime.Location = new Point(531, 1);
            lbl_StartTime.Margin = new Padding(2, 0, 2, 0);
            lbl_StartTime.Name = "lbl_StartTime";
            lbl_StartTime.Size = new Size(101, 20);
            lbl_StartTime.TabIndex = 7;
            lbl_StartTime.Text = "Start Time";
            // 
            // lbl_EndTime
            // 
            lbl_EndTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_EndTime.AutoSize = true;
            lbl_EndTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_EndTime.Location = new Point(637, 1);
            lbl_EndTime.Margin = new Padding(2, 0, 2, 0);
            lbl_EndTime.Name = "lbl_EndTime";
            lbl_EndTime.Size = new Size(101, 20);
            lbl_EndTime.TabIndex = 8;
            lbl_EndTime.Text = "End Time";
            // 
            // rtb_Instructions
            // 
            rtb_Instructions.BackColor = SystemColors.MenuBar;
            rtb_Instructions.BorderStyle = BorderStyle.None;
            tlp_Main.SetColumnSpan(rtb_Instructions, 2);
            rtb_Instructions.Dock = DockStyle.Fill;
            rtb_Instructions.Font = new Font("Microsoft Sans Serif", 9F);
            rtb_Instructions.ForeColor = Color.DimGray;
            rtb_Instructions.Location = new Point(2, 117);
            rtb_Instructions.Margin = new Padding(2, 3, 2, 3);
            rtb_Instructions.Name = "rtb_Instructions";
            rtb_Instructions.ReadOnly = true;
            rtb_Instructions.Size = new Size(789, 51);
            rtb_Instructions.TabIndex = 6;
            rtb_Instructions.Text = "Instructions:\n- Load a .txt file with each line matching the following format:\n[Vinesauce] Vinny - Video Title 00:00:00 01:59:59";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolsToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(2, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(793, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reEncodeClipsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // reEncodeClipsToolStripMenuItem
            // 
            reEncodeClipsToolStripMenuItem.Name = "reEncodeClipsToolStripMenuItem";
            reEncodeClipsToolStripMenuItem.Size = new Size(200, 26);
            reEncodeClipsToolStripMenuItem.Text = "Re-Encode Clips";
            reEncodeClipsToolStripMenuItem.Click += ReEncodeClips_Clicked;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { avoidNegativeTimestampsToolStripMenuItem, toggleThemeToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(75, 24);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // avoidNegativeTimestampsToolStripMenuItem
            // 
            avoidNegativeTimestampsToolStripMenuItem.Checked = true;
            avoidNegativeTimestampsToolStripMenuItem.CheckOnClick = true;
            avoidNegativeTimestampsToolStripMenuItem.CheckState = CheckState.Checked;
            avoidNegativeTimestampsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox_AvoidNegativeTS });
            avoidNegativeTimestampsToolStripMenuItem.Name = "avoidNegativeTimestampsToolStripMenuItem";
            avoidNegativeTimestampsToolStripMenuItem.Size = new Size(279, 26);
            avoidNegativeTimestampsToolStripMenuItem.Text = "Avoid Negative Timestamps";
            // 
            // toolStripComboBox_AvoidNegativeTS
            // 
            toolStripComboBox_AvoidNegativeTS.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_AvoidNegativeTS.Items.AddRange(new object[] { "make_zero", "make_non_negative", "auto" });
            toolStripComboBox_AvoidNegativeTS.Name = "toolStripComboBox_AvoidNegativeTS";
            toolStripComboBox_AvoidNegativeTS.Size = new Size(171, 28);
            // 
            // toggleThemeToolStripMenuItem
            // 
            toggleThemeToolStripMenuItem.Checked = true;
            toggleThemeToolStripMenuItem.CheckOnClick = true;
            toggleThemeToolStripMenuItem.CheckState = CheckState.Checked;
            toggleThemeToolStripMenuItem.Name = "toggleThemeToolStripMenuItem";
            toggleThemeToolStripMenuItem.Size = new Size(279, 26);
            toggleThemeToolStripMenuItem.Text = "Dark Theme";
            toggleThemeToolStripMenuItem.CheckedChanged += ToggleTheme_Click;
            // 
            // splitContainer_Main
            // 
            splitContainer_Main.Dock = DockStyle.Fill;
            splitContainer_Main.Location = new Point(2, 28);
            splitContainer_Main.Name = "splitContainer_Main";
            splitContainer_Main.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            splitContainer_Main.Panel1.Controls.Add(tlp_Main);
            // 
            // splitContainer_Main.Panel2
            // 
            splitContainer_Main.Panel2.Controls.Add(tlp_LogAndCreateClipsBtn);
            splitContainer_Main.Panel2MinSize = 60;
            splitContainer_Main.Size = new Size(793, 442);
            splitContainer_Main.SplitterDistance = 380;
            splitContainer_Main.TabIndex = 2;
            // 
            // tlp_LogAndCreateClipsBtn
            // 
            tlp_LogAndCreateClipsBtn.ColumnCount = 2;
            tlp_LogAndCreateClipsBtn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tlp_LogAndCreateClipsBtn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlp_LogAndCreateClipsBtn.Controls.Add(rtb_Log, 0, 0);
            tlp_LogAndCreateClipsBtn.Controls.Add(btn_CreateClips, 1, 0);
            tlp_LogAndCreateClipsBtn.Dock = DockStyle.Fill;
            tlp_LogAndCreateClipsBtn.Location = new Point(0, 0);
            tlp_LogAndCreateClipsBtn.Name = "tlp_LogAndCreateClipsBtn";
            tlp_LogAndCreateClipsBtn.RowCount = 1;
            tlp_LogAndCreateClipsBtn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_LogAndCreateClipsBtn.Size = new Size(793, 60);
            tlp_LogAndCreateClipsBtn.TabIndex = 0;
            // 
            // rtb_Log
            // 
            rtb_Log.BackColor = SystemColors.MenuBar;
            rtb_Log.BorderStyle = BorderStyle.None;
            rtb_Log.Dock = DockStyle.Fill;
            rtb_Log.Font = new Font("Microsoft Sans Serif", 8F);
            rtb_Log.ForeColor = Color.Gray;
            rtb_Log.Location = new Point(2, 3);
            rtb_Log.Margin = new Padding(2, 3, 2, 3);
            rtb_Log.Name = "rtb_Log";
            rtb_Log.ReadOnly = true;
            rtb_Log.Size = new Size(670, 54);
            rtb_Log.TabIndex = 10;
            rtb_Log.Text = "Created by ShrineFox";
            // 
            // btn_CreateClips
            // 
            btn_CreateClips.DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
            btn_CreateClips.DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
            btn_CreateClips.DisabledForeColor = Color.Gray;
            btn_CreateClips.Dock = DockStyle.Fill;
            btn_CreateClips.Enabled = false;
            btn_CreateClips.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_CreateClips.HoverBorderColor = Color.FromArgb(95, 207, 255);
            btn_CreateClips.HoverColor = Color.FromArgb(95, 207, 255);
            btn_CreateClips.HoverTextColor = Color.White;
            btn_CreateClips.IsDerivedStyle = true;
            btn_CreateClips.Location = new Point(677, 3);
            btn_CreateClips.Name = "btn_CreateClips";
            btn_CreateClips.NormalBorderColor = Color.FromArgb(65, 177, 225);
            btn_CreateClips.NormalColor = Color.FromArgb(65, 177, 225);
            btn_CreateClips.NormalTextColor = Color.White;
            btn_CreateClips.PressBorderColor = Color.FromArgb(35, 147, 195);
            btn_CreateClips.PressColor = Color.FromArgb(35, 147, 195);
            btn_CreateClips.PressTextColor = Color.White;
            btn_CreateClips.Size = new Size(113, 54);
            btn_CreateClips.Style = MetroSet_UI.Enums.Style.Light;
            btn_CreateClips.StyleManager = null;
            btn_CreateClips.TabIndex = 11;
            btn_CreateClips.Text = "Create Clips";
            btn_CreateClips.ThemeAuthor = "Narwin";
            btn_CreateClips.ThemeName = "MetroLite";
            btn_CreateClips.Click += CreateClipsBtn_Click;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(797, 472);
            Controls.Add(splitContainer_Main);
            Controls.Add(menuStrip1);
            Font = new Font("Microsoft Sans Serif", 11F);
            FormBorderStyle = FormBorderStyle.Sizable;
            HeaderHeight = -40;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 3, 2, 3);
            Name = "MainForm";
            Opacity = 0.99D;
            Padding = new Padding(2, 0, 2, 2);
            ShowBorder = true;
            ShowHeader = true;
            ShowLeftRect = false;
            Style = MetroSet_UI.Enums.Style.Dark;
            Text = "Vinesauce VOD Clipper v1.2";
            TextColor = Color.White;
            ThemeName = "MetroDark";
            tlp_Main.ResumeLayout(false);
            groupBox_ClipsDir.ResumeLayout(false);
            tlp_ClipsDir.ResumeLayout(false);
            tlp_ClipsDir.PerformLayout();
            groupBox_TxtFile.ResumeLayout(false);
            tlp_TxtFile.ResumeLayout(false);
            tlp_TxtFile.PerformLayout();
            groupBox_VideoList.ResumeLayout(false);
            pnl_VideoList.ResumeLayout(false);
            pnl_VideoList.PerformLayout();
            tlp_VideoList.ResumeLayout(false);
            tlp_VideoList.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer_Main.Panel1.ResumeLayout(false);
            splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Main).EndInit();
            splitContainer_Main.ResumeLayout(false);
            tlp_LogAndCreateClipsBtn.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private GroupBox groupBox_TxtFile;
        private TableLayoutPanel tlp_TxtFile;
        private TextBox txt_TxtFile;
        private Button btn_TxtFile;
        private GroupBox groupBox_ClipsDir;
        private TableLayoutPanel tlp_ClipsDir;
        private TextBox txt_ClipsDir;
        private Button btn_ClipsDir;
        private GroupBox groupBox_VideoList;
        private RichTextBox rtb_Instructions;
        private Panel pnl_VideoList;
        private TableLayoutPanel tlp_VideoList;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Button button2;
        private Label lbl_Title;
        private Label lbl_VideoPath;
        private Label lbl_StartTime;
        private Label lbl_EndTime;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox15;
        private TextBox textBox14;
        private TextBox textBox13;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private Button button3;
        private TextBox textBox7;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox8;
        private TextBox textBox9;
        private Button button4;
        private Button button5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem reEncodeClipsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem avoidNegativeTimestampsToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox_AvoidNegativeTS;
        private ToolStripMenuItem toggleThemeToolStripMenuItem;
        private SplitContainer splitContainer_Main;
        private TableLayoutPanel tlp_LogAndCreateClipsBtn;
        private RichTextBox rtb_Log;
        private MetroSet_UI.Controls.MetroSetButton btn_CreateClips;
    }
}
