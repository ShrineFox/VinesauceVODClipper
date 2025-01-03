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
            groupBox_ClipsDir = new GroupBox();
            tlp_ClipsDir = new TableLayoutPanel();
            txt_ClipsDir = new TextBox();
            btn_ClipsDir = new Button();
            groupBox_TxtFile = new GroupBox();
            tlp_TxtFile = new TableLayoutPanel();
            txt_TxtFile = new TextBox();
            btn_TxtFile = new Button();
            btn_CreateClips = new Button();
            groupBox_VideoList = new GroupBox();
            pnl_VideoList = new Panel();
            tlp_VideoList = new TableLayoutPanel();
            textBox15 = new TextBox();
            textBox14 = new TextBox();
            textBox13 = new TextBox();
            textBox12 = new TextBox();
            textBox11 = new TextBox();
            textBox10 = new TextBox();
            button3 = new Button();
            textBox7 = new TextBox();
            label3 = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            richTextBox1 = new RichTextBox();
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
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(groupBox_ClipsDir, 0, 1);
            tlp_Main.Controls.Add(groupBox_TxtFile, 0, 0);
            tlp_Main.Controls.Add(btn_CreateClips, 0, 4);
            tlp_Main.Controls.Add(groupBox_VideoList, 0, 3);
            tlp_Main.Controls.Add(richTextBox1, 0, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 5;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlp_Main.Size = new Size(800, 450);
            tlp_Main.TabIndex = 0;
            // 
            // groupBox_ClipsDir
            // 
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
            txt_ClipsDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_ClipsDir.Location = new Point(3, 4);
            txt_ClipsDir.Name = "txt_ClipsDir";
            txt_ClipsDir.Size = new Size(624, 27);
            txt_ClipsDir.TabIndex = 0;
            txt_ClipsDir.Text = "C:\\Users\\Ryan\\Videos\\Clips";
            // 
            // btn_ClipsDir
            // 
            btn_ClipsDir.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_ClipsDir.Location = new Point(633, 4);
            btn_ClipsDir.Name = "btn_ClipsDir";
            btn_ClipsDir.Size = new Size(152, 27);
            btn_ClipsDir.TabIndex = 1;
            btn_ClipsDir.Text = ". . .";
            btn_ClipsDir.UseVisualStyleBackColor = true;
            // 
            // groupBox_TxtFile
            // 
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
            txt_TxtFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_TxtFile.Location = new Point(3, 4);
            txt_TxtFile.Name = "txt_TxtFile";
            txt_TxtFile.Size = new Size(624, 27);
            txt_TxtFile.TabIndex = 0;
            txt_TxtFile.Text = "C:\\Users\\Ryan\\Downloads\\TimestampsForJohnny.txt";
            // 
            // btn_TxtFile
            // 
            btn_TxtFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_TxtFile.Location = new Point(633, 3);
            btn_TxtFile.Name = "btn_TxtFile";
            btn_TxtFile.Size = new Size(152, 29);
            btn_TxtFile.TabIndex = 1;
            btn_TxtFile.Text = ". . .";
            btn_TxtFile.UseVisualStyleBackColor = true;
            // 
            // btn_CreateClips
            // 
            btn_CreateClips.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_CreateClips.Location = new Point(688, 406);
            btn_CreateClips.Name = "btn_CreateClips";
            btn_CreateClips.Size = new Size(109, 41);
            btn_CreateClips.TabIndex = 3;
            btn_CreateClips.Text = "Create Clips";
            btn_CreateClips.UseVisualStyleBackColor = true;
            // 
            // groupBox_VideoList
            // 
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
            tlp_VideoList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlp_VideoList.AutoSize = true;
            tlp_VideoList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlp_VideoList.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_VideoList.ColumnCount = 5;
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.0952377F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8095245F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.523809F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlp_VideoList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlp_VideoList.Controls.Add(textBox15, 4, 4);
            tlp_VideoList.Controls.Add(textBox14, 3, 4);
            tlp_VideoList.Controls.Add(textBox13, 4, 3);
            tlp_VideoList.Controls.Add(textBox12, 3, 3);
            tlp_VideoList.Controls.Add(textBox11, 4, 2);
            tlp_VideoList.Controls.Add(textBox10, 3, 2);
            tlp_VideoList.Controls.Add(button3, 2, 2);
            tlp_VideoList.Controls.Add(textBox7, 1, 2);
            tlp_VideoList.Controls.Add(label3, 0, 2);
            tlp_VideoList.Controls.Add(textBox6, 4, 1);
            tlp_VideoList.Controls.Add(textBox5, 3, 1);
            tlp_VideoList.Controls.Add(textBox4, 4, 0);
            tlp_VideoList.Controls.Add(textBox3, 3, 0);
            tlp_VideoList.Controls.Add(label2, 0, 1);
            tlp_VideoList.Controls.Add(textBox1, 1, 0);
            tlp_VideoList.Controls.Add(button1, 2, 0);
            tlp_VideoList.Controls.Add(textBox2, 1, 1);
            tlp_VideoList.Controls.Add(button2, 2, 1);
            tlp_VideoList.Controls.Add(label1, 0, 0);
            tlp_VideoList.Controls.Add(label4, 0, 3);
            tlp_VideoList.Controls.Add(label5, 0, 4);
            tlp_VideoList.Controls.Add(textBox8, 1, 3);
            tlp_VideoList.Controls.Add(textBox9, 1, 4);
            tlp_VideoList.Controls.Add(button4, 2, 3);
            tlp_VideoList.Controls.Add(button5, 2, 4);
            tlp_VideoList.Location = new Point(0, 0);
            tlp_VideoList.Name = "tlp_VideoList";
            tlp_VideoList.RowCount = 5;
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.RowStyles.Add(new RowStyle());
            tlp_VideoList.Size = new Size(757, 201);
            tlp_VideoList.TabIndex = 0;
            // 
            // textBox15
            // 
            textBox15.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox15.Location = new Point(650, 166);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(103, 27);
            textBox15.TabIndex = 25;
            textBox15.Text = "1:06:26";
            // 
            // textBox14
            // 
            textBox14.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox14.Location = new Point(542, 166);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(101, 27);
            textBox14.TabIndex = 24;
            textBox14.Text = "1:05:14";
            // 
            // textBox13
            // 
            textBox13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox13.Location = new Point(650, 125);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(103, 27);
            textBox13.TabIndex = 23;
            textBox13.Text = "49:20";
            // 
            // textBox12
            // 
            textBox12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox12.Location = new Point(542, 125);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(101, 27);
            textBox12.TabIndex = 22;
            textBox12.Text = "46:02";
            // 
            // textBox11
            // 
            textBox11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox11.Location = new Point(650, 84);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(103, 27);
            textBox11.TabIndex = 21;
            textBox11.Text = "1:05:00";
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox10.Location = new Point(542, 84);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(101, 27);
            textBox10.TabIndex = 20;
            textBox10.Text = "1:02:49";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(470, 84);
            button3.Name = "button3";
            button3.Size = new Size(65, 27);
            button3.TabIndex = 17;
            button3.Text = ". . .";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox7.Location = new Point(291, 84);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(172, 27);
            textBox7.TabIndex = 14;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(4, 78);
            label3.Name = "label3";
            label3.Size = new Size(280, 40);
            label3.TabIndex = 11;
            label3.Text = "[Vinesauce] Vinny - Mario & Luigi: Superstar Saga (part 1)";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox6.Location = new Point(650, 43);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(103, 27);
            textBox6.TabIndex = 10;
            textBox6.Text = "1:13:26";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox5.Location = new Point(542, 43);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(101, 27);
            textBox5.TabIndex = 9;
            textBox5.Text = "1:12:00";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Location = new Point(650, 5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(103, 27);
            textBox4.TabIndex = 8;
            textBox4.Text = "48:40";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(542, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(101, 27);
            textBox3.TabIndex = 7;
            textBox3.Text = "45:10";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(4, 37);
            label2.Name = "label2";
            label2.Size = new Size(280, 40);
            label2.TabIndex = 6;
            label2.Text = "Vinny - Mario 64 in Minecraft, Sonic, Doom, TF2, Blender, etc..";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(291, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(172, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "C:\\Users\\Ryan\\Downloads\\Vinesauce： The Full Sauce - [Vinesauce] Vinny & Friends - VRChat #6.mp4";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(470, 4);
            button1.Name = "button1";
            button1.Size = new Size(65, 29);
            button1.TabIndex = 2;
            button1.Text = ". . .";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(291, 43);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(172, 27);
            textBox2.TabIndex = 3;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(470, 43);
            button2.Name = "button2";
            button2.Size = new Size(65, 27);
            button2.TabIndex = 4;
            button2.Text = ". . .";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(4, 8);
            label1.Name = "label1";
            label1.Size = new Size(280, 20);
            label1.TabIndex = 5;
            label1.Text = "[Vinesauce] Vinny & Friends - VRChat #6";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(4, 119);
            label4.Name = "label4";
            label4.Size = new Size(280, 40);
            label4.TabIndex = 12;
            label4.Text = "[Vinesauce] Vinny - Quick GameCube Corruptions";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(4, 160);
            label5.Name = "label5";
            label5.Size = new Size(280, 40);
            label5.TabIndex = 13;
            label5.Text = "[Vinesauce] Vinny - Red Dead Redemption 2 (part 21)";
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox8.Location = new Point(291, 125);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(172, 27);
            textBox8.TabIndex = 15;
            // 
            // textBox9
            // 
            textBox9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox9.Location = new Point(291, 166);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(172, 27);
            textBox9.TabIndex = 16;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button4.Location = new Point(470, 125);
            button4.Name = "button4";
            button4.Size = new Size(65, 27);
            button4.TabIndex = 18;
            button4.Text = ". . .";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button5.Location = new Point(470, 166);
            button5.Name = "button5";
            button5.Size = new Size(65, 27);
            button5.TabIndex = 19;
            button5.Text = ". . .";
            button5.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.MenuBar;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.Location = new Point(3, 137);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(794, 61);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "Drag Raw VODs onto matching video names below, then click Create Clips to generate clips.";
            // 
            // MainForm
            // 
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
        private Button btn_CreateClips;
        private GroupBox groupBox_ClipsDir;
        private TableLayoutPanel tlp_ClipsDir;
        private TextBox txt_ClipsDir;
        private Button btn_ClipsDir;
        private GroupBox groupBox_VideoList;
        private RichTextBox richTextBox1;
        private Panel pnl_VideoList;
        private TableLayoutPanel tlp_VideoList;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Button button2;
        private Label label1;
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
