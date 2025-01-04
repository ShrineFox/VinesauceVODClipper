namespace VinesauceVODClipper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tlp_Main = new TableLayoutPanel();
            rtb_Log = new RichTextBox();
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
            btn_CreateClips = new Button();
            tlp_Main.SuspendLayout();
            groupBox_ClipsDir.SuspendLayout();
            tlp_ClipsDir.SuspendLayout();
            groupBox_TxtFile.SuspendLayout();
            tlp_TxtFile.SuspendLayout();
            groupBox_VideoList.SuspendLayout();
            pnl_VideoList.SuspendLayout();
            tlp_VideoList.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.AllowDrop = true;
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlp_Main.Controls.Add(rtb_Log, 0, 4);
            tlp_Main.Controls.Add(groupBox_ClipsDir, 0, 1);
            tlp_Main.Controls.Add(groupBox_TxtFile, 0, 0);
            tlp_Main.Controls.Add(groupBox_VideoList, 0, 3);
            tlp_Main.Controls.Add(rtb_Instructions, 0, 2);
            tlp_Main.Controls.Add(btn_CreateClips, 1, 4);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 5;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Main.Size = new Size(800, 450);
            tlp_Main.TabIndex = 0;
            // 
            // rtb_Log
            // 
            rtb_Log.BackColor = SystemColors.MenuBar;
            rtb_Log.BorderStyle = BorderStyle.None;
            rtb_Log.Dock = DockStyle.Fill;
            rtb_Log.ForeColor = Color.Gray;
            rtb_Log.Location = new Point(3, 406);
            rtb_Log.Name = "rtb_Log";
            rtb_Log.ReadOnly = true;
            rtb_Log.Size = new Size(674, 41);
            rtb_Log.TabIndex = 8;
            rtb_Log.Text = "Created by ShrineFox";
            // 
            // groupBox_ClipsDir
            // 
            tlp_Main.SetColumnSpan(groupBox_ClipsDir, 2);
            groupBox_ClipsDir.Controls.Add(tlp_ClipsDir);
            groupBox_ClipsDir.Dock = DockStyle.Fill;
            groupBox_ClipsDir.Location = new Point(3, 70);
            groupBox_ClipsDir.Name = "groupBox_ClipsDir";
            groupBox_ClipsDir.Size = new Size(794, 61);
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
            tlp_ClipsDir.Location = new Point(3, 23);
            tlp_ClipsDir.Name = "tlp_ClipsDir";
            tlp_ClipsDir.RowCount = 1;
            tlp_ClipsDir.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_ClipsDir.Size = new Size(788, 35);
            tlp_ClipsDir.TabIndex = 0;
            // 
            // txt_ClipsDir
            // 
            txt_ClipsDir.AllowDrop = true;
            txt_ClipsDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_ClipsDir.BorderStyle = BorderStyle.FixedSingle;
            txt_ClipsDir.Location = new Point(3, 4);
            txt_ClipsDir.Name = "txt_ClipsDir";
            txt_ClipsDir.Size = new Size(624, 27);
            txt_ClipsDir.TabIndex = 0;
            txt_ClipsDir.TextChanged += OutputDirTxt_Changed;
            txt_ClipsDir.DragDrop += ClipsDir_DragDrop;
            txt_ClipsDir.DragEnter += DragEnter;
            // 
            // btn_ClipsDir
            // 
            btn_ClipsDir.AllowDrop = true;
            btn_ClipsDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_ClipsDir.Location = new Point(633, 4);
            btn_ClipsDir.Name = "btn_ClipsDir";
            btn_ClipsDir.Size = new Size(152, 27);
            btn_ClipsDir.TabIndex = 1;
            btn_ClipsDir.Text = ". . .";
            btn_ClipsDir.UseVisualStyleBackColor = true;
            btn_ClipsDir.Click += OutputDirBtn_Click;
            btn_ClipsDir.DragDrop += ClipsDir_DragDrop;
            btn_ClipsDir.DragEnter += DragEnter;
            // 
            // groupBox_TxtFile
            // 
            tlp_Main.SetColumnSpan(groupBox_TxtFile, 2);
            groupBox_TxtFile.Controls.Add(tlp_TxtFile);
            groupBox_TxtFile.Dock = DockStyle.Fill;
            groupBox_TxtFile.Location = new Point(3, 3);
            groupBox_TxtFile.Name = "groupBox_TxtFile";
            groupBox_TxtFile.Size = new Size(794, 61);
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
            tlp_TxtFile.Location = new Point(3, 23);
            tlp_TxtFile.Name = "tlp_TxtFile";
            tlp_TxtFile.RowCount = 1;
            tlp_TxtFile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_TxtFile.Size = new Size(788, 35);
            tlp_TxtFile.TabIndex = 0;
            // 
            // txt_TxtFile
            // 
            txt_TxtFile.AllowDrop = true;
            txt_TxtFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_TxtFile.BorderStyle = BorderStyle.FixedSingle;
            txt_TxtFile.Location = new Point(3, 4);
            txt_TxtFile.Name = "txt_TxtFile";
            txt_TxtFile.ReadOnly = true;
            txt_TxtFile.Size = new Size(624, 27);
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
            btn_TxtFile.Location = new Point(633, 3);
            btn_TxtFile.Name = "btn_TxtFile";
            btn_TxtFile.Size = new Size(152, 29);
            btn_TxtFile.TabIndex = 1;
            btn_TxtFile.Text = ". . .";
            btn_TxtFile.UseVisualStyleBackColor = true;
            btn_TxtFile.Click += TxtBtn_Click;
            btn_TxtFile.DragDrop += TxtFile_DragDrop;
            btn_TxtFile.DragEnter += DragEnter;
            // 
            // groupBox_VideoList
            // 
            tlp_Main.SetColumnSpan(groupBox_VideoList, 2);
            groupBox_VideoList.Controls.Add(pnl_VideoList);
            groupBox_VideoList.Dock = DockStyle.Fill;
            groupBox_VideoList.Location = new Point(3, 204);
            groupBox_VideoList.Name = "groupBox_VideoList";
            groupBox_VideoList.Size = new Size(794, 196);
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
            pnl_VideoList.Location = new Point(3, 23);
            pnl_VideoList.Name = "pnl_VideoList";
            pnl_VideoList.Size = new Size(788, 170);
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
            tlp_VideoList.Name = "tlp_VideoList";
            tlp_VideoList.RowCount = 1;
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.Size = new Size(762, 22);
            tlp_VideoList.TabIndex = 0;
            // 
            // lbl_VideoPath
            // 
            lbl_VideoPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_VideoPath.AutoSize = true;
            lbl_VideoPath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_VideoPath.Location = new Point(293, 1);
            lbl_VideoPath.Name = "lbl_VideoPath";
            lbl_VideoPath.Size = new Size(174, 20);
            lbl_VideoPath.TabIndex = 6;
            lbl_VideoPath.Text = "Video Path";
            // 
            // lbl_Title
            // 
            lbl_Title.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.Location = new Point(4, 1);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(282, 20);
            lbl_Title.TabIndex = 5;
            lbl_Title.Text = "Video Title";
            // 
            // lbl_StartTime
            // 
            lbl_StartTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_StartTime.AutoSize = true;
            lbl_StartTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_StartTime.Location = new Point(547, 1);
            lbl_StartTime.Name = "lbl_StartTime";
            lbl_StartTime.Size = new Size(102, 20);
            lbl_StartTime.TabIndex = 7;
            lbl_StartTime.Text = "Start Time";
            // 
            // lbl_EndTime
            // 
            lbl_EndTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_EndTime.AutoSize = true;
            lbl_EndTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_EndTime.Location = new Point(656, 1);
            lbl_EndTime.Name = "lbl_EndTime";
            lbl_EndTime.Size = new Size(102, 20);
            lbl_EndTime.TabIndex = 8;
            lbl_EndTime.Text = "End Time";
            // 
            // rtb_Instructions
            // 
            rtb_Instructions.BackColor = SystemColors.MenuBar;
            rtb_Instructions.BorderStyle = BorderStyle.None;
            tlp_Main.SetColumnSpan(rtb_Instructions, 2);
            rtb_Instructions.Dock = DockStyle.Fill;
            rtb_Instructions.ForeColor = Color.DimGray;
            rtb_Instructions.Location = new Point(3, 137);
            rtb_Instructions.Name = "rtb_Instructions";
            rtb_Instructions.ReadOnly = true;
            rtb_Instructions.Size = new Size(794, 61);
            rtb_Instructions.TabIndex = 6;
            rtb_Instructions.Text = "Instructions:\n- Load a .txt file with each line matching the following format:\n[Vinesauce] Vinny - Video Title 00:00:00 01:59:59";
            // 
            // btn_CreateClips
            // 
            btn_CreateClips.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_CreateClips.Enabled = false;
            btn_CreateClips.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_CreateClips.Location = new Point(688, 406);
            btn_CreateClips.Name = "btn_CreateClips";
            btn_CreateClips.Size = new Size(109, 41);
            btn_CreateClips.TabIndex = 7;
            btn_CreateClips.Text = "Create Clips";
            btn_CreateClips.UseVisualStyleBackColor = true;
            btn_CreateClips.Click += CreateClipsBtn_Click;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlp_Main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Vinesauce VOD Clipper";
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
            ResumeLayout(false);
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
        private RichTextBox rtb_Log;
        private Button btn_CreateClips;
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
    }
}
