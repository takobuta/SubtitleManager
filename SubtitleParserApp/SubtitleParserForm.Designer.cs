namespace SubtitleParserApp {
    partial class SubtitleParserForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SelectSubtitleFileButton = new System.Windows.Forms.Button();
            this.TextCountLabel = new System.Windows.Forms.Label();
            this.FilePathLabeltextBox = new System.Windows.Forms.TextBox();
            this.CutButton1 = new System.Windows.Forms.Button();
            this.CutStartTimeTextBox1 = new System.Windows.Forms.TextBox();
            this.Namilabel = new System.Windows.Forms.Label();
            this.CutEndTimeTextBox1 = new System.Windows.Forms.TextBox();
            this.OutputButton1 = new System.Windows.Forms.Button();
            this.CutResultTextBox1 = new System.Windows.Forms.TextBox();
            this.DeleteSubtitleCheckBox1 = new System.Windows.Forms.CheckBox();
            this.ProcessTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CutResultTextBox2 = new System.Windows.Forms.TextBox();
            this.OutputButton2 = new System.Windows.Forms.Button();
            this.CutEndTimeTextBox2 = new System.Windows.Forms.TextBox();
            this.Cutbutton2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CutStartTimeTextBox2 = new System.Windows.Forms.TextBox();
            this.MovieFilePathLabelTextBox = new System.Windows.Forms.TextBox();
            this.SelectMovieFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TextCountLabel3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DelayRadioButton = new System.Windows.Forms.RadioButton();
            this.ForwardRadioButton = new System.Windows.Forms.RadioButton();
            this.OffsetTextBox3 = new System.Windows.Forms.TextBox();
            this.FilePathLabeltextBox3 = new System.Windows.Forms.TextBox();
            this.EditResultTextBox3 = new System.Windows.Forms.TextBox();
            this.OutputButton3 = new System.Windows.Forms.Button();
            this.SelectSubtitleFileButton3 = new System.Windows.Forms.Button();
            this.EditEndTimeTextBox3 = new System.Windows.Forms.TextBox();
            this.EditButton3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.EditStartTimeTextBox3 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ResultLabel4 = new System.Windows.Forms.Label();
            this.OutputButton4 = new System.Windows.Forms.Button();
            this.GaijiInfoFilePathLabeltextBox4 = new System.Windows.Forms.TextBox();
            this.SelectGaijiInfoFileButton4 = new System.Windows.Forms.Button();
            this.FilePathLabeltextBox4 = new System.Windows.Forms.TextBox();
            this.SelectSubtitleFileButton4 = new System.Windows.Forms.Button();
            this.ReplaceGaijiCheckBox1 = new System.Windows.Forms.CheckBox();
            this.GaijiInfoFilePathLabeltextBox1 = new System.Windows.Forms.TextBox();
            this.SelectGaijiInfoFileButton1 = new System.Windows.Forms.Button();
            this.ProcessTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectSubtitleFileButton
            // 
            this.SelectSubtitleFileButton.Location = new System.Drawing.Point(9, 17);
            this.SelectSubtitleFileButton.Name = "SelectSubtitleFileButton";
            this.SelectSubtitleFileButton.Size = new System.Drawing.Size(137, 25);
            this.SelectSubtitleFileButton.TabIndex = 0;
            this.SelectSubtitleFileButton.Text = "字幕ファイル選択";
            this.SelectSubtitleFileButton.UseVisualStyleBackColor = true;
            this.SelectSubtitleFileButton.Click += new System.EventHandler(this.SelectSubtitleFileButton_Click);
            // 
            // TextCountLabel
            // 
            this.TextCountLabel.AutoSize = true;
            this.TextCountLabel.Location = new System.Drawing.Point(159, 45);
            this.TextCountLabel.Name = "TextCountLabel";
            this.TextCountLabel.Size = new System.Drawing.Size(0, 18);
            this.TextCountLabel.TabIndex = 2;
            // 
            // FilePathLabeltextBox
            // 
            this.FilePathLabeltextBox.Location = new System.Drawing.Point(152, 17);
            this.FilePathLabeltextBox.Name = "FilePathLabeltextBox";
            this.FilePathLabeltextBox.ReadOnly = true;
            this.FilePathLabeltextBox.Size = new System.Drawing.Size(423, 25);
            this.FilePathLabeltextBox.TabIndex = 3;
            // 
            // CutButton1
            // 
            this.CutButton1.Location = new System.Drawing.Point(304, 80);
            this.CutButton1.Name = "CutButton1";
            this.CutButton1.Size = new System.Drawing.Size(137, 25);
            this.CutButton1.TabIndex = 4;
            this.CutButton1.Text = "カット編集";
            this.CutButton1.UseVisualStyleBackColor = true;
            this.CutButton1.Click += new System.EventHandler(this.CutButton1_Click);
            // 
            // CutStartTimeTextBox1
            // 
            this.CutStartTimeTextBox1.Location = new System.Drawing.Point(9, 80);
            this.CutStartTimeTextBox1.Name = "CutStartTimeTextBox1";
            this.CutStartTimeTextBox1.Size = new System.Drawing.Size(124, 25);
            this.CutStartTimeTextBox1.TabIndex = 5;
            this.CutStartTimeTextBox1.Text = "00:00:00.000";
            // 
            // Namilabel
            // 
            this.Namilabel.AutoSize = true;
            this.Namilabel.Location = new System.Drawing.Point(139, 83);
            this.Namilabel.Name = "Namilabel";
            this.Namilabel.Size = new System.Drawing.Size(20, 18);
            this.Namilabel.TabIndex = 6;
            this.Namilabel.Text = "～";
            // 
            // CutEndTimeTextBox1
            // 
            this.CutEndTimeTextBox1.Location = new System.Drawing.Point(165, 80);
            this.CutEndTimeTextBox1.Name = "CutEndTimeTextBox1";
            this.CutEndTimeTextBox1.Size = new System.Drawing.Size(124, 25);
            this.CutEndTimeTextBox1.TabIndex = 7;
            // 
            // OutputButton1
            // 
            this.OutputButton1.Location = new System.Drawing.Point(9, 363);
            this.OutputButton1.Name = "OutputButton1";
            this.OutputButton1.Size = new System.Drawing.Size(137, 25);
            this.OutputButton1.TabIndex = 8;
            this.OutputButton1.Text = "出力";
            this.OutputButton1.UseVisualStyleBackColor = true;
            this.OutputButton1.Click += new System.EventHandler(this.OutputButton1_Click);
            // 
            // CutResultTextBox1
            // 
            this.CutResultTextBox1.Location = new System.Drawing.Point(9, 220);
            this.CutResultTextBox1.Multiline = true;
            this.CutResultTextBox1.Name = "CutResultTextBox1";
            this.CutResultTextBox1.ReadOnly = true;
            this.CutResultTextBox1.Size = new System.Drawing.Size(566, 137);
            this.CutResultTextBox1.TabIndex = 9;
            // 
            // DeleteSubtitleCheckBox1
            // 
            this.DeleteSubtitleCheckBox1.AutoSize = true;
            this.DeleteSubtitleCheckBox1.Checked = true;
            this.DeleteSubtitleCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DeleteSubtitleCheckBox1.Location = new System.Drawing.Point(9, 112);
            this.DeleteSubtitleCheckBox1.Name = "DeleteSubtitleCheckBox1";
            this.DeleteSubtitleCheckBox1.Size = new System.Drawing.Size(195, 22);
            this.DeleteSubtitleCheckBox1.TabIndex = 10;
            this.DeleteSubtitleCheckBox1.Text = "カット範囲内の字幕は削除する";
            this.DeleteSubtitleCheckBox1.UseVisualStyleBackColor = true;
            // 
            // ProcessTabControl
            // 
            this.ProcessTabControl.Controls.Add(this.tabPage1);
            this.ProcessTabControl.Controls.Add(this.tabPage2);
            this.ProcessTabControl.Controls.Add(this.tabPage3);
            this.ProcessTabControl.Controls.Add(this.tabPage4);
            this.ProcessTabControl.Location = new System.Drawing.Point(0, 0);
            this.ProcessTabControl.Name = "ProcessTabControl";
            this.ProcessTabControl.SelectedIndex = 0;
            this.ProcessTabControl.Size = new System.Drawing.Size(605, 574);
            this.ProcessTabControl.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GaijiInfoFilePathLabeltextBox1);
            this.tabPage1.Controls.Add(this.SelectGaijiInfoFileButton1);
            this.tabPage1.Controls.Add(this.ReplaceGaijiCheckBox1);
            this.tabPage1.Controls.Add(this.FilePathLabeltextBox);
            this.tabPage1.Controls.Add(this.CutResultTextBox1);
            this.tabPage1.Controls.Add(this.OutputButton1);
            this.tabPage1.Controls.Add(this.DeleteSubtitleCheckBox1);
            this.tabPage1.Controls.Add(this.SelectSubtitleFileButton);
            this.tabPage1.Controls.Add(this.TextCountLabel);
            this.tabPage1.Controls.Add(this.CutEndTimeTextBox1);
            this.tabPage1.Controls.Add(this.CutButton1);
            this.tabPage1.Controls.Add(this.Namilabel);
            this.tabPage1.Controls.Add(this.CutStartTimeTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "①カット（字幕編集）";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CutResultTextBox2);
            this.tabPage2.Controls.Add(this.OutputButton2);
            this.tabPage2.Controls.Add(this.CutEndTimeTextBox2);
            this.tabPage2.Controls.Add(this.Cutbutton2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.CutStartTimeTextBox2);
            this.tabPage2.Controls.Add(this.MovieFilePathLabelTextBox);
            this.tabPage2.Controls.Add(this.SelectMovieFileButton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "②カットのみ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CutResultTextBox2
            // 
            this.CutResultTextBox2.Location = new System.Drawing.Point(9, 140);
            this.CutResultTextBox2.Multiline = true;
            this.CutResultTextBox2.Name = "CutResultTextBox2";
            this.CutResultTextBox2.ReadOnly = true;
            this.CutResultTextBox2.Size = new System.Drawing.Size(566, 137);
            this.CutResultTextBox2.TabIndex = 16;
            // 
            // OutputButton2
            // 
            this.OutputButton2.Location = new System.Drawing.Point(8, 297);
            this.OutputButton2.Name = "OutputButton2";
            this.OutputButton2.Size = new System.Drawing.Size(137, 25);
            this.OutputButton2.TabIndex = 15;
            this.OutputButton2.Text = "出力";
            this.OutputButton2.UseVisualStyleBackColor = true;
            this.OutputButton2.Click += new System.EventHandler(this.OutputButton2_Click);
            // 
            // CutEndTimeTextBox2
            // 
            this.CutEndTimeTextBox2.Location = new System.Drawing.Point(165, 80);
            this.CutEndTimeTextBox2.Name = "CutEndTimeTextBox2";
            this.CutEndTimeTextBox2.Size = new System.Drawing.Size(124, 25);
            this.CutEndTimeTextBox2.TabIndex = 14;
            // 
            // Cutbutton2
            // 
            this.Cutbutton2.Location = new System.Drawing.Point(304, 80);
            this.Cutbutton2.Name = "Cutbutton2";
            this.Cutbutton2.Size = new System.Drawing.Size(137, 25);
            this.Cutbutton2.TabIndex = 11;
            this.Cutbutton2.Text = "カット編集";
            this.Cutbutton2.UseVisualStyleBackColor = true;
            this.Cutbutton2.Click += new System.EventHandler(this.Cutbutton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "～";
            // 
            // CutStartTimeTextBox2
            // 
            this.CutStartTimeTextBox2.Location = new System.Drawing.Point(9, 80);
            this.CutStartTimeTextBox2.Name = "CutStartTimeTextBox2";
            this.CutStartTimeTextBox2.Size = new System.Drawing.Size(124, 25);
            this.CutStartTimeTextBox2.TabIndex = 12;
            // 
            // MovieFilePathLabelTextBox
            // 
            this.MovieFilePathLabelTextBox.Location = new System.Drawing.Point(152, 17);
            this.MovieFilePathLabelTextBox.Name = "MovieFilePathLabelTextBox";
            this.MovieFilePathLabelTextBox.ReadOnly = true;
            this.MovieFilePathLabelTextBox.Size = new System.Drawing.Size(423, 25);
            this.MovieFilePathLabelTextBox.TabIndex = 6;
            // 
            // SelectMovieFileButton
            // 
            this.SelectMovieFileButton.Location = new System.Drawing.Point(9, 17);
            this.SelectMovieFileButton.Name = "SelectMovieFileButton";
            this.SelectMovieFileButton.Size = new System.Drawing.Size(137, 25);
            this.SelectMovieFileButton.TabIndex = 4;
            this.SelectMovieFileButton.Text = "動画ファイル選択";
            this.SelectMovieFileButton.UseVisualStyleBackColor = true;
            this.SelectMovieFileButton.Click += new System.EventHandler(this.SelectMovieFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TextCountLabel3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.DelayRadioButton);
            this.tabPage3.Controls.Add(this.ForwardRadioButton);
            this.tabPage3.Controls.Add(this.OffsetTextBox3);
            this.tabPage3.Controls.Add(this.FilePathLabeltextBox3);
            this.tabPage3.Controls.Add(this.EditResultTextBox3);
            this.tabPage3.Controls.Add(this.OutputButton3);
            this.tabPage3.Controls.Add(this.SelectSubtitleFileButton3);
            this.tabPage3.Controls.Add(this.EditEndTimeTextBox3);
            this.tabPage3.Controls.Add(this.EditButton3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.EditStartTimeTextBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 543);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "③字幕調整";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TextCountLabel3
            // 
            this.TextCountLabel3.AutoSize = true;
            this.TextCountLabel3.Location = new System.Drawing.Point(159, 45);
            this.TextCountLabel3.Name = "TextCountLabel3";
            this.TextCountLabel3.Size = new System.Drawing.Size(0, 18);
            this.TextCountLabel3.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "※ 終了を指定しない場合は最後まで";
            // 
            // DelayRadioButton
            // 
            this.DelayRadioButton.AutoSize = true;
            this.DelayRadioButton.Location = new System.Drawing.Point(210, 112);
            this.DelayRadioButton.Name = "DelayRadioButton";
            this.DelayRadioButton.Size = new System.Drawing.Size(74, 22);
            this.DelayRadioButton.TabIndex = 21;
            this.DelayRadioButton.Text = "遅らせる";
            this.DelayRadioButton.UseVisualStyleBackColor = true;
            // 
            // ForwardRadioButton
            // 
            this.ForwardRadioButton.AutoSize = true;
            this.ForwardRadioButton.Checked = true;
            this.ForwardRadioButton.Location = new System.Drawing.Point(142, 112);
            this.ForwardRadioButton.Name = "ForwardRadioButton";
            this.ForwardRadioButton.Size = new System.Drawing.Size(62, 22);
            this.ForwardRadioButton.TabIndex = 20;
            this.ForwardRadioButton.TabStop = true;
            this.ForwardRadioButton.Text = "早める";
            this.ForwardRadioButton.UseVisualStyleBackColor = true;
            // 
            // OffsetTextBox3
            // 
            this.OffsetTextBox3.Location = new System.Drawing.Point(9, 109);
            this.OffsetTextBox3.Name = "OffsetTextBox3";
            this.OffsetTextBox3.Size = new System.Drawing.Size(124, 25);
            this.OffsetTextBox3.TabIndex = 19;
            this.OffsetTextBox3.Text = "00:00:00.000";
            // 
            // FilePathLabeltextBox3
            // 
            this.FilePathLabeltextBox3.Location = new System.Drawing.Point(152, 17);
            this.FilePathLabeltextBox3.Name = "FilePathLabeltextBox3";
            this.FilePathLabeltextBox3.ReadOnly = true;
            this.FilePathLabeltextBox3.Size = new System.Drawing.Size(423, 25);
            this.FilePathLabeltextBox3.TabIndex = 12;
            // 
            // EditResultTextBox3
            // 
            this.EditResultTextBox3.Location = new System.Drawing.Point(9, 140);
            this.EditResultTextBox3.Multiline = true;
            this.EditResultTextBox3.Name = "EditResultTextBox3";
            this.EditResultTextBox3.ReadOnly = true;
            this.EditResultTextBox3.Size = new System.Drawing.Size(566, 137);
            this.EditResultTextBox3.TabIndex = 18;
            // 
            // OutputButton3
            // 
            this.OutputButton3.Location = new System.Drawing.Point(8, 297);
            this.OutputButton3.Name = "OutputButton3";
            this.OutputButton3.Size = new System.Drawing.Size(137, 25);
            this.OutputButton3.TabIndex = 17;
            this.OutputButton3.Text = "出力";
            this.OutputButton3.UseVisualStyleBackColor = true;
            this.OutputButton3.Click += new System.EventHandler(this.OutputButton3_Click);
            // 
            // SelectSubtitleFileButton3
            // 
            this.SelectSubtitleFileButton3.Location = new System.Drawing.Point(9, 17);
            this.SelectSubtitleFileButton3.Name = "SelectSubtitleFileButton3";
            this.SelectSubtitleFileButton3.Size = new System.Drawing.Size(137, 25);
            this.SelectSubtitleFileButton3.TabIndex = 11;
            this.SelectSubtitleFileButton3.Text = "字幕ファイル選択";
            this.SelectSubtitleFileButton3.UseVisualStyleBackColor = true;
            this.SelectSubtitleFileButton3.Click += new System.EventHandler(this.SelectSubtitleFileButton3_Click);
            // 
            // EditEndTimeTextBox3
            // 
            this.EditEndTimeTextBox3.Location = new System.Drawing.Point(165, 80);
            this.EditEndTimeTextBox3.Name = "EditEndTimeTextBox3";
            this.EditEndTimeTextBox3.Size = new System.Drawing.Size(124, 25);
            this.EditEndTimeTextBox3.TabIndex = 16;
            // 
            // EditButton3
            // 
            this.EditButton3.Location = new System.Drawing.Point(304, 109);
            this.EditButton3.Name = "EditButton3";
            this.EditButton3.Size = new System.Drawing.Size(137, 25);
            this.EditButton3.TabIndex = 13;
            this.EditButton3.Text = "編集";
            this.EditButton3.UseVisualStyleBackColor = true;
            this.EditButton3.Click += new System.EventHandler(this.EditButton3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "～";
            // 
            // EditStartTimeTextBox3
            // 
            this.EditStartTimeTextBox3.Location = new System.Drawing.Point(9, 80);
            this.EditStartTimeTextBox3.Name = "EditStartTimeTextBox3";
            this.EditStartTimeTextBox3.Size = new System.Drawing.Size(124, 25);
            this.EditStartTimeTextBox3.TabIndex = 14;
            this.EditStartTimeTextBox3.Text = "00:00:00.000";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ResultLabel4);
            this.tabPage4.Controls.Add(this.OutputButton4);
            this.tabPage4.Controls.Add(this.GaijiInfoFilePathLabeltextBox4);
            this.tabPage4.Controls.Add(this.SelectGaijiInfoFileButton4);
            this.tabPage4.Controls.Add(this.FilePathLabeltextBox4);
            this.tabPage4.Controls.Add(this.SelectSubtitleFileButton4);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(597, 543);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "④外字置換";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ResultLabel4
            // 
            this.ResultLabel4.AutoSize = true;
            this.ResultLabel4.Location = new System.Drawing.Point(20, 186);
            this.ResultLabel4.Name = "ResultLabel4";
            this.ResultLabel4.Size = new System.Drawing.Size(0, 18);
            this.ResultLabel4.TabIndex = 19;
            // 
            // OutputButton4
            // 
            this.OutputButton4.Location = new System.Drawing.Point(9, 143);
            this.OutputButton4.Name = "OutputButton4";
            this.OutputButton4.Size = new System.Drawing.Size(137, 25);
            this.OutputButton4.TabIndex = 18;
            this.OutputButton4.Text = "出力";
            this.OutputButton4.UseVisualStyleBackColor = true;
            this.OutputButton4.Click += new System.EventHandler(this.OutputButton4_Click);
            // 
            // GaijiInfoFilePathLabeltextBox4
            // 
            this.GaijiInfoFilePathLabeltextBox4.Location = new System.Drawing.Point(152, 79);
            this.GaijiInfoFilePathLabeltextBox4.Name = "GaijiInfoFilePathLabeltextBox4";
            this.GaijiInfoFilePathLabeltextBox4.ReadOnly = true;
            this.GaijiInfoFilePathLabeltextBox4.Size = new System.Drawing.Size(423, 25);
            this.GaijiInfoFilePathLabeltextBox4.TabIndex = 16;
            // 
            // SelectGaijiInfoFileButton4
            // 
            this.SelectGaijiInfoFileButton4.Location = new System.Drawing.Point(9, 79);
            this.SelectGaijiInfoFileButton4.Name = "SelectGaijiInfoFileButton4";
            this.SelectGaijiInfoFileButton4.Size = new System.Drawing.Size(137, 25);
            this.SelectGaijiInfoFileButton4.TabIndex = 15;
            this.SelectGaijiInfoFileButton4.Text = "外字情報ファイル選択";
            this.SelectGaijiInfoFileButton4.UseVisualStyleBackColor = true;
            // 
            // FilePathLabeltextBox4
            // 
            this.FilePathLabeltextBox4.Location = new System.Drawing.Point(152, 17);
            this.FilePathLabeltextBox4.Name = "FilePathLabeltextBox4";
            this.FilePathLabeltextBox4.ReadOnly = true;
            this.FilePathLabeltextBox4.Size = new System.Drawing.Size(423, 25);
            this.FilePathLabeltextBox4.TabIndex = 14;
            // 
            // SelectSubtitleFileButton4
            // 
            this.SelectSubtitleFileButton4.Location = new System.Drawing.Point(9, 17);
            this.SelectSubtitleFileButton4.Name = "SelectSubtitleFileButton4";
            this.SelectSubtitleFileButton4.Size = new System.Drawing.Size(137, 25);
            this.SelectSubtitleFileButton4.TabIndex = 13;
            this.SelectSubtitleFileButton4.Text = "字幕ファイル選択";
            this.SelectSubtitleFileButton4.UseVisualStyleBackColor = true;
            this.SelectSubtitleFileButton4.Click += new System.EventHandler(this.SelectSubtitleFileButton4_Click);
            // 
            // ReplaceGaijiCheckBox1
            // 
            this.ReplaceGaijiCheckBox1.AutoSize = true;
            this.ReplaceGaijiCheckBox1.Checked = true;
            this.ReplaceGaijiCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ReplaceGaijiCheckBox1.Location = new System.Drawing.Point(9, 140);
            this.ReplaceGaijiCheckBox1.Name = "ReplaceGaijiCheckBox1";
            this.ReplaceGaijiCheckBox1.Size = new System.Drawing.Size(195, 22);
            this.ReplaceGaijiCheckBox1.TabIndex = 11;
            this.ReplaceGaijiCheckBox1.Text = "外字が含まれる場合は置換する\r\n";
            this.ReplaceGaijiCheckBox1.UseVisualStyleBackColor = true;
            this.ReplaceGaijiCheckBox1.CheckedChanged += new System.EventHandler(this.ReplaceGaijiCheckBox1_CheckedChanged);
            // 
            // GaijiInfoFilePathLabeltextBox1
            // 
            this.GaijiInfoFilePathLabeltextBox1.Location = new System.Drawing.Point(152, 167);
            this.GaijiInfoFilePathLabeltextBox1.Name = "GaijiInfoFilePathLabeltextBox1";
            this.GaijiInfoFilePathLabeltextBox1.ReadOnly = true;
            this.GaijiInfoFilePathLabeltextBox1.Size = new System.Drawing.Size(423, 25);
            this.GaijiInfoFilePathLabeltextBox1.TabIndex = 18;
            // 
            // SelectGaijiInfoFileButton1
            // 
            this.SelectGaijiInfoFileButton1.Location = new System.Drawing.Point(9, 167);
            this.SelectGaijiInfoFileButton1.Name = "SelectGaijiInfoFileButton1";
            this.SelectGaijiInfoFileButton1.Size = new System.Drawing.Size(137, 25);
            this.SelectGaijiInfoFileButton1.TabIndex = 17;
            this.SelectGaijiInfoFileButton1.Text = "外字情報ファイル選択";
            this.SelectGaijiInfoFileButton1.UseVisualStyleBackColor = true;
            // 
            // SubtitleParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 572);
            this.Controls.Add(this.ProcessTabControl);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubtitleParserForm";
            this.Text = "字幕編集";
            this.ProcessTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectSubtitleFileButton;
        private System.Windows.Forms.Label TextCountLabel;
        private System.Windows.Forms.TextBox FilePathLabeltextBox;
        private System.Windows.Forms.Button CutButton1;
        private System.Windows.Forms.TextBox CutStartTimeTextBox1;
        private System.Windows.Forms.Label Namilabel;
        private System.Windows.Forms.TextBox CutEndTimeTextBox1;
        private System.Windows.Forms.Button OutputButton1;
        private System.Windows.Forms.TextBox CutResultTextBox1;
        private System.Windows.Forms.CheckBox DeleteSubtitleCheckBox1;
        private System.Windows.Forms.TabControl ProcessTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox MovieFilePathLabelTextBox;
        private System.Windows.Forms.Button SelectMovieFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CutResultTextBox2;
        private System.Windows.Forms.Button OutputButton2;
        private System.Windows.Forms.TextBox CutEndTimeTextBox2;
        private System.Windows.Forms.Button Cutbutton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CutStartTimeTextBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox FilePathLabeltextBox3;
        private System.Windows.Forms.TextBox EditResultTextBox3;
        private System.Windows.Forms.Button OutputButton3;
        private System.Windows.Forms.Button SelectSubtitleFileButton3;
        private System.Windows.Forms.TextBox EditEndTimeTextBox3;
        private System.Windows.Forms.Button EditButton3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EditStartTimeTextBox3;
        private System.Windows.Forms.TextBox OffsetTextBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton DelayRadioButton;
        private System.Windows.Forms.RadioButton ForwardRadioButton;
        private System.Windows.Forms.Label TextCountLabel3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox FilePathLabeltextBox4;
        private System.Windows.Forms.Button SelectSubtitleFileButton4;
        private System.Windows.Forms.TextBox GaijiInfoFilePathLabeltextBox4;
        private System.Windows.Forms.Button SelectGaijiInfoFileButton4;
        private System.Windows.Forms.Button OutputButton4;
        private System.Windows.Forms.Label ResultLabel4;
        private System.Windows.Forms.TextBox GaijiInfoFilePathLabeltextBox1;
        private System.Windows.Forms.Button SelectGaijiInfoFileButton1;
        private System.Windows.Forms.CheckBox ReplaceGaijiCheckBox1;
    }
}