namespace GraphControl {
    partial class GraphDisplay {
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

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
	    this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
	    this.SuspendLayout();
	    // 
	    // hScrollBar1
	    // 
	    this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
	    this.hScrollBar1.Location = new System.Drawing.Point(21, 41);
	    this.hScrollBar1.Name = "hScrollBar1";
	    this.hScrollBar1.Size = new System.Drawing.Size(130, 19);
	    this.hScrollBar1.TabIndex = 0;
	    // 
	    // GraphDisplay
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.SystemColors.MenuHighlight;
	    this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	    this.Controls.Add(this.hScrollBar1);
	    this.DoubleBuffered = true;
	    this.MinimumSize = new System.Drawing.Size(152, 62);
	    this.Name = "GraphDisplay";
	    this.Size = new System.Drawing.Size(150, 60);
	    this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}
