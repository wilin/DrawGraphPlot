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
	    this.graphDisplay1 = new GraphControl.GraphDisplay();
	    this.SuspendLayout();
	    // 
	    // graphDisplay1
	    // 
	    this.graphDisplay1.BackColor = System.Drawing.SystemColors.MenuHighlight;
	    this.graphDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	    this.graphDisplay1.Location = new System.Drawing.Point(12, 12);
	    this.graphDisplay1.MinimumSize = new System.Drawing.Size(152, 62);
	    this.graphDisplay1.Name = "graphDisplay1";
	    this.graphDisplay1.Size = new System.Drawing.Size(206, 134);
	    this.graphDisplay1.TabIndex = 0;
	    // 
	    // Form1
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(326, 226);
	    this.Controls.Add(this.graphDisplay1);
	    this.Name = "Form1";
	    this.Text = "Form1";
	    this.ResumeLayout(false);

	}

	#endregion

	private GraphControl.GraphDisplay graphDisplay1;
    }
}

