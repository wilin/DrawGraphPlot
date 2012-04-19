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
	    this.graphDisplay1 = new GraphControl.GraphDisplay();
	    this.button5 = new System.Windows.Forms.Button();
	    this.button6 = new System.Windows.Forms.Button();
	    this.button7 = new System.Windows.Forms.Button();
	    this.button8 = new System.Windows.Forms.Button();
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
	    this.button7.Enabled = false;
	    this.button7.Location = new System.Drawing.Point(219, 234);
	    this.button7.Name = "button7";
	    this.button7.Size = new System.Drawing.Size(95, 31);
	    this.button7.TabIndex = 7;
	    this.button7.Text = "Record mode";
	    this.button7.UseVisualStyleBackColor = true;
	    // 
	    // button8
	    // 
	    this.button8.Enabled = false;
	    this.button8.Location = new System.Drawing.Point(219, 271);
	    this.button8.Name = "button8";
	    this.button8.Size = new System.Drawing.Size(95, 30);
	    this.button8.TabIndex = 8;
	    this.button8.Text = "Playback mode";
	    this.button8.UseVisualStyleBackColor = true;
	    // 
	    // Form1
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(329, 352);
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
    }
}

