using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphControl {
    public partial class GraphDisplay : UserControl {

	public int samplingFrequency = 0;
	public int refreshRate = 0;
	public float minDisplay = -1;
	public float maxDisplay = 1;

	public LinkedList<float> podatki = new LinkedList<float>();

	public override Color BackColor {
	    get {
		return base.BackColor;
	    }
	    set {
		base.BackColor = value;
		this.Invalidate();
	    }
	}
	
	public GraphDisplay() {
	    InitializeComponent();
	}

	protected override void OnPaint(PaintEventArgs e) {
	    base.OnPaint(e);

	    int horizontalnaLeft = 21;
	    int horizontalnaRight = this.Size.Width;
	    int vertikalnaDown = this.Size.Height - 42;
	    int vertikalnaUp = 0;
	    int horizontalnaUp = this.Size.Height - 42;
	    int horizontalnaDown = this.Size.Height - 21;
	    int vertikalnaLeft = 0;
	    int vertikalnaRight = 21;

	    Brush b = new SolidBrush(Color.Gray);

	    // Primer horizontalnega fill-a / za izpifs Fvz, ||||, ...
	    e.Graphics.FillRectangle(b, horizontalnaLeft, horizontalnaUp, (horizontalnaRight - horizontalnaLeft), (horizontalnaDown - horizontalnaUp));

	    // Primer vertikalnega fill-a / za izpis jakosti signala, .....
	    b = new SolidBrush(Color.Honeydew);
	    e.Graphics.FillRectangle(b, vertikalnaLeft, vertikalnaUp, (vertikalnaRight - vertikalnaLeft), (vertikalnaDown - vertikalnaUp));

	    // Primer fill-a neuporabljenega prostora (Prosotr za copymark)
	    b = new SolidBrush(Color.HotPink);
	    e.Graphics.FillRectangle(b, vertikalnaLeft, vertikalnaDown, (vertikalnaRight-vertikalnaLeft), (this.Size.Height - vertikalnaDown));


	    // Preprost izpis količine podatkov
	    b = new SolidBrush(Color.Orange);
	    e.Graphics.DrawString(podatki.Count.ToString(), new Font(FontFamily.GenericSansSerif, 36), b, vertikalnaRight + 2, vertikalnaUp); 


	    b.Dispose();
	}

	public void addData(List<float> data){
	    foreach (float x in data){
		podatki.AddLast(x);
	    }
	}

	public void addData(float data) {
	    podatki.AddLast(data);
	}

    }
}
