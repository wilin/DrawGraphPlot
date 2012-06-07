namespace UsageExample {
    partial class Form1 {
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
	    this.button1 = new System.Windows.Forms.Button();
	    this.button2 = new System.Windows.Forms.Button();
	    this.button3 = new System.Windows.Forms.Button();
	    this.button4 = new System.Windows.Forms.Button();
	    this.button5 = new System.Windows.Forms.Button();
	    this.button6 = new System.Windows.Forms.Button();
	    this.button7 = new System.Windows.Forms.Button();
	    this.button8 = new System.Windows.Forms.Button();
	    this.groupBox1 = new System.Windows.Forms.GroupBox();
	    this.comboBox7 = new System.Windows.Forms.ComboBox();
	    this.label7 = new System.Windows.Forms.Label();
	    this.comboBox6 = new System.Windows.Forms.ComboBox();
	    this.label6 = new System.Windows.Forms.Label();
	    this.comboBox5 = new System.Windows.Forms.ComboBox();
	    this.label5 = new System.Windows.Forms.Label();
	    this.comboBox4 = new System.Windows.Forms.ComboBox();
	    this.label4 = new System.Windows.Forms.Label();
	    this.comboBox3 = new System.Windows.Forms.ComboBox();
	    this.label3 = new System.Windows.Forms.Label();
	    this.comboBox2 = new System.Windows.Forms.ComboBox();
	    this.label2 = new System.Windows.Forms.Label();
	    this.comboBox1 = new System.Windows.Forms.ComboBox();
	    this.label1 = new System.Windows.Forms.Label();
	    this.button9 = new System.Windows.Forms.Button();
	    this.groupBox2 = new System.Windows.Forms.GroupBox();
	    this.button13 = new System.Windows.Forms.Button();
	    this.button12 = new System.Windows.Forms.Button();
	    this.button11 = new System.Windows.Forms.Button();
	    this.button10 = new System.Windows.Forms.Button();
	    this.graphDisplay1 = new GraphControl.GraphDisplay();
	    this.groupBox1.SuspendLayout();
	    this.groupBox2.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // button1
	    // 
	    this.button1.Location = new System.Drawing.Point(12, 234);
	    this.button1.Name = "button1";
	    this.button1.Size = new System.Drawing.Size(103, 31);
	    this.button1.TabIndex = 1;
	    this.button1.Text = "Add test data";
	    this.button1.UseVisualStyleBackColor = true;
	    this.button1.Click += new System.EventHandler(this.button1_Click);
	    // 
	    // button2
	    // 
	    this.button2.Location = new System.Drawing.Point(12, 271);
	    this.button2.Name = "button2";
	    this.button2.Size = new System.Drawing.Size(103, 30);
	    this.button2.TabIndex = 2;
	    this.button2.Text = "Auto add test data";
	    this.button2.UseVisualStyleBackColor = true;
	    this.button2.Click += new System.EventHandler(this.button2_Click);
	    // 
	    // button3
	    // 
	    this.button3.Location = new System.Drawing.Point(12, 307);
	    this.button3.Name = "button3";
	    this.button3.Size = new System.Drawing.Size(103, 29);
	    this.button3.TabIndex = 3;
	    this.button3.Text = "Stop adding data";
	    this.button3.UseVisualStyleBackColor = true;
	    this.button3.Click += new System.EventHandler(this.button3_Click);
	    // 
	    // button4
	    // 
	    this.button4.Location = new System.Drawing.Point(235, 307);
	    this.button4.Name = "button4";
	    this.button4.Size = new System.Drawing.Size(79, 29);
	    this.button4.TabIndex = 4;
	    this.button4.Text = "Exit";
	    this.button4.UseVisualStyleBackColor = true;
	    this.button4.Click += new System.EventHandler(this.button4_Click);
	    // 
	    // button5
	    // 
	    this.button5.Location = new System.Drawing.Point(121, 234);
	    this.button5.Name = "button5";
	    this.button5.Size = new System.Drawing.Size(92, 31);
	    this.button5.TabIndex = 5;
	    this.button5.Text = "Signal view";
	    this.button5.UseVisualStyleBackColor = true;
	    this.button5.Click += new System.EventHandler(this.button5_Click);
	    // 
	    // button6
	    // 
	    this.button6.Location = new System.Drawing.Point(121, 271);
	    this.button6.Name = "button6";
	    this.button6.Size = new System.Drawing.Size(92, 30);
	    this.button6.TabIndex = 6;
	    this.button6.Text = "FFT view";
	    this.button6.UseVisualStyleBackColor = true;
	    this.button6.Click += new System.EventHandler(this.button6_Click);
	    // 
	    // button7
	    // 
	    this.button7.Location = new System.Drawing.Point(219, 234);
	    this.button7.Name = "button7";
	    this.button7.Size = new System.Drawing.Size(95, 31);
	    this.button7.TabIndex = 7;
	    this.button7.Text = "Record mode";
	    this.button7.UseVisualStyleBackColor = true;
	    this.button7.Click += new System.EventHandler(this.button7_Click);
	    // 
	    // button8
	    // 
	    this.button8.Location = new System.Drawing.Point(219, 271);
	    this.button8.Name = "button8";
	    this.button8.Size = new System.Drawing.Size(95, 30);
	    this.button8.TabIndex = 8;
	    this.button8.Text = "Playback mode";
	    this.button8.UseVisualStyleBackColor = true;
	    this.button8.Click += new System.EventHandler(this.button8_Click);
	    // 
	    // groupBox1
	    // 
	    this.groupBox1.Controls.Add(this.comboBox7);
	    this.groupBox1.Controls.Add(this.label7);
	    this.groupBox1.Controls.Add(this.comboBox6);
	    this.groupBox1.Controls.Add(this.label6);
	    this.groupBox1.Controls.Add(this.comboBox5);
	    this.groupBox1.Controls.Add(this.label5);
	    this.groupBox1.Controls.Add(this.comboBox4);
	    this.groupBox1.Controls.Add(this.label4);
	    this.groupBox1.Controls.Add(this.comboBox3);
	    this.groupBox1.Controls.Add(this.label3);
	    this.groupBox1.Controls.Add(this.comboBox2);
	    this.groupBox1.Controls.Add(this.label2);
	    this.groupBox1.Controls.Add(this.comboBox1);
	    this.groupBox1.Controls.Add(this.label1);
	    this.groupBox1.Location = new System.Drawing.Point(321, 13);
	    this.groupBox1.Name = "groupBox1";
	    this.groupBox1.Size = new System.Drawing.Size(149, 323);
	    this.groupBox1.TabIndex = 9;
	    this.groupBox1.TabStop = false;
	    this.groupBox1.Text = "Colors";
	    this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
	    // 
	    // comboBox7
	    // 
	    this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox7.FormattingEnabled = true;
	    this.comboBox7.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox7.Location = new System.Drawing.Point(9, 284);
	    this.comboBox7.Name = "comboBox7";
	    this.comboBox7.Size = new System.Drawing.Size(121, 21);
	    this.comboBox7.TabIndex = 13;
	    this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
	    // 
	    // label7
	    // 
	    this.label7.AutoSize = true;
	    this.label7.Location = new System.Drawing.Point(6, 267);
	    this.label7.Name = "label7";
	    this.label7.Size = new System.Drawing.Size(52, 13);
	    this.label7.TabIndex = 12;
	    this.label7.Text = "Zero Line";
	    // 
	    // comboBox6
	    // 
	    this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox6.FormattingEnabled = true;
	    this.comboBox6.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox6.Location = new System.Drawing.Point(9, 237);
	    this.comboBox6.Name = "comboBox6";
	    this.comboBox6.Size = new System.Drawing.Size(121, 21);
	    this.comboBox6.TabIndex = 11;
	    this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
	    // 
	    // label6
	    // 
	    this.label6.AutoSize = true;
	    this.label6.Location = new System.Drawing.Point(6, 221);
	    this.label6.Name = "label6";
	    this.label6.Size = new System.Drawing.Size(64, 13);
	    this.label6.TabIndex = 10;
	    this.label6.Text = "Bottom Text";
	    // 
	    // comboBox5
	    // 
	    this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox5.FormattingEnabled = true;
	    this.comboBox5.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox5.Location = new System.Drawing.Point(9, 193);
	    this.comboBox5.Name = "comboBox5";
	    this.comboBox5.Size = new System.Drawing.Size(121, 21);
	    this.comboBox5.TabIndex = 9;
	    this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
	    // 
	    // label5
	    // 
	    this.label5.AutoSize = true;
	    this.label5.Location = new System.Drawing.Point(6, 176);
	    this.label5.Name = "label5";
	    this.label5.Size = new System.Drawing.Size(52, 13);
	    this.label5.TabIndex = 8;
	    this.label5.Text = "Side Text";
	    // 
	    // comboBox4
	    // 
	    this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox4.FormattingEnabled = true;
	    this.comboBox4.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox4.Location = new System.Drawing.Point(9, 152);
	    this.comboBox4.Name = "comboBox4";
	    this.comboBox4.Size = new System.Drawing.Size(121, 21);
	    this.comboBox4.TabIndex = 7;
	    this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
	    // 
	    // label4
	    // 
	    this.label4.AutoSize = true;
	    this.label4.Location = new System.Drawing.Point(6, 136);
	    this.label4.Name = "label4";
	    this.label4.Size = new System.Drawing.Size(63, 13);
	    this.label4.TabIndex = 6;
	    this.label4.Text = "Water Mark";
	    // 
	    // comboBox3
	    // 
	    this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox3.FormattingEnabled = true;
	    this.comboBox3.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox3.Location = new System.Drawing.Point(9, 112);
	    this.comboBox3.Name = "comboBox3";
	    this.comboBox3.Size = new System.Drawing.Size(121, 21);
	    this.comboBox3.TabIndex = 5;
	    this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
	    // 
	    // label3
	    // 
	    this.label3.AutoSize = true;
	    this.label3.Location = new System.Drawing.Point(6, 96);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(70, 13);
	    this.label3.TabIndex = 4;
	    this.label3.Text = "Bottom Panel";
	    // 
	    // comboBox2
	    // 
	    this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox2.FormattingEnabled = true;
	    this.comboBox2.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox2.Location = new System.Drawing.Point(9, 72);
	    this.comboBox2.Name = "comboBox2";
	    this.comboBox2.Size = new System.Drawing.Size(121, 21);
	    this.comboBox2.TabIndex = 3;
	    this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
	    // 
	    // label2
	    // 
	    this.label2.AutoSize = true;
	    this.label2.Location = new System.Drawing.Point(6, 56);
	    this.label2.Name = "label2";
	    this.label2.Size = new System.Drawing.Size(58, 13);
	    this.label2.TabIndex = 2;
	    this.label2.Text = "Side Panel";
	    // 
	    // comboBox1
	    // 
	    this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    this.comboBox1.FormattingEnabled = true;
	    this.comboBox1.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Black",
            "Lime",
            "Yellow",
            "Orange",
            "Cyan"});
	    this.comboBox1.Location = new System.Drawing.Point(9, 32);
	    this.comboBox1.Name = "comboBox1";
	    this.comboBox1.Size = new System.Drawing.Size(121, 21);
	    this.comboBox1.TabIndex = 1;
	    this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Location = new System.Drawing.Point(6, 16);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(65, 13);
	    this.label1.TabIndex = 0;
	    this.label1.Text = "Background";
	    // 
	    // button9
	    // 
	    this.button9.Location = new System.Drawing.Point(121, 307);
	    this.button9.Name = "button9";
	    this.button9.Size = new System.Drawing.Size(92, 29);
	    this.button9.TabIndex = 10;
	    this.button9.Text = "Load .WAV";
	    this.button9.UseVisualStyleBackColor = true;
	    this.button9.Click += new System.EventHandler(this.button9_Click);
	    // 
	    // groupBox2
	    // 
	    this.groupBox2.Controls.Add(this.button13);
	    this.groupBox2.Controls.Add(this.button12);
	    this.groupBox2.Controls.Add(this.button11);
	    this.groupBox2.Controls.Add(this.button10);
	    this.groupBox2.Location = new System.Drawing.Point(476, 13);
	    this.groupBox2.Name = "groupBox2";
	    this.groupBox2.Size = new System.Drawing.Size(161, 323);
	    this.groupBox2.TabIndex = 11;
	    this.groupBox2.TabStop = false;
	    this.groupBox2.Text = "Extra testing";
	    // 
	    // button13
	    // 
	    this.button13.Location = new System.Drawing.Point(7, 136);
	    this.button13.Name = "button13";
	    this.button13.Size = new System.Drawing.Size(148, 23);
	    this.button13.TabIndex = 3;
	    this.button13.Text = "Disable scaling";
	    this.button13.UseVisualStyleBackColor = true;
	    this.button13.Click += new System.EventHandler(this.button13_Click);
	    // 
	    // button12
	    // 
	    this.button12.Location = new System.Drawing.Point(6, 96);
	    this.button12.Name = "button12";
	    this.button12.Size = new System.Drawing.Size(149, 23);
	    this.button12.TabIndex = 2;
	    this.button12.Text = "Enable scaling";
	    this.button12.UseVisualStyleBackColor = true;
	    this.button12.Click += new System.EventHandler(this.button12_Click);
	    // 
	    // button11
	    // 
	    this.button11.Location = new System.Drawing.Point(6, 56);
	    this.button11.Name = "button11";
	    this.button11.Size = new System.Drawing.Size(149, 23);
	    this.button11.TabIndex = 1;
	    this.button11.Text = "Decrease visible portion";
	    this.button11.UseVisualStyleBackColor = true;
	    this.button11.Click += new System.EventHandler(this.button11_Click);
	    // 
	    // button10
	    // 
	    this.button10.Location = new System.Drawing.Point(6, 19);
	    this.button10.Name = "button10";
	    this.button10.Size = new System.Drawing.Size(149, 23);
	    this.button10.TabIndex = 0;
	    this.button10.Text = "Increase visible portion";
	    this.button10.UseVisualStyleBackColor = true;
	    this.button10.Click += new System.EventHandler(this.button10_Click);
	    // 
	    // graphDisplay1
	    // 
	    this.graphDisplay1.BackColor = System.Drawing.SystemColors.MenuHighlight;
	    this.graphDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	    this.graphDisplay1.Location = new System.Drawing.Point(12, 12);
	    this.graphDisplay1.MinimumSize = new System.Drawing.Size(152, 62);
	    this.graphDisplay1.Name = "graphDisplay1";
	    this.graphDisplay1.Size = new System.Drawing.Size(302, 202);
	    this.graphDisplay1.TabIndex = 0;
	    // 
	    // Form1
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(646, 352);
	    this.Controls.Add(this.groupBox2);
	    this.Controls.Add(this.button9);
	    this.Controls.Add(this.groupBox1);
	    this.Controls.Add(this.button8);
	    this.Controls.Add(this.button7);
	    this.Controls.Add(this.button6);
	    this.Controls.Add(this.button5);
	    this.Controls.Add(this.button4);
	    this.Controls.Add(this.button3);
	    this.Controls.Add(this.button2);
	    this.Controls.Add(this.button1);
	    this.Controls.Add(this.graphDisplay1);
	    this.Name = "Form1";
	    this.Text = "Form1";
	    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
	    this.groupBox1.ResumeLayout(false);
	    this.groupBox1.PerformLayout();
	    this.groupBox2.ResumeLayout(false);
	    this.ResumeLayout(false);

	}

	#endregion

	private GraphControl.GraphDisplay graphDisplay1;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.Button button3;
	private System.Windows.Forms.Button button4;
	private System.Windows.Forms.Button button5;
	private System.Windows.Forms.Button button6;
	private System.Windows.Forms.Button button7;
	private System.Windows.Forms.Button button8;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.ComboBox comboBox1;
	private System.Windows.Forms.ComboBox comboBox2;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.ComboBox comboBox3;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.ComboBox comboBox4;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.ComboBox comboBox5;
	private System.Windows.Forms.ComboBox comboBox7;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.ComboBox comboBox6;
	private System.Windows.Forms.Button button9;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.Button button11;
	private System.Windows.Forms.Button button10;
	private System.Windows.Forms.Button button13;
	private System.Windows.Forms.Button button12;
    }
}

