using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace GraphControl {
    public partial class GraphDisplay : UserControl {

	public int samplingFrequency = 0;
	public int refreshRate = 0;
	public float minDisplay = -1;
	public float maxDisplay = 1;

	public static int Fvz = 44100;	    // Mogoce kasneje float?
	public int maxFPS = 10;	    // 1-30, recimo
	public static float visibleSignal = (float)0.01;  // visibleSignal*Fvz = signal shown (is underSampling == 0)
	public int underSampling = 0;	    // 0-xy -> every n-th sample shown.

	public LinkedList<float> podatki = new LinkedList<float>();

	public float [] dataToDisplay = new float[(Convert.ToInt32(visibleSignal*Fvz))];

	public int displayMode = 0;	// 0 == recording mode, 1 == playback mode 
	public int signalMode = 0;  // 0 == signal, 1 == FFT

	public System.Timers.Timer timer = new System.Timers.Timer();

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
	    for (int i = 0; i < dataToDisplay.Length; i++) {
		dataToDisplay[i] = (float)0.0;
	    }
	
	    InitializeComponent();

	    initTimer();
	    startTimer();
	    hScrollBar1.Enabled = false;
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

	    // Primer fill-a neuporabljenega prostora (Prostor za copymark)
	    b = new SolidBrush(Color.HotPink);
	    e.Graphics.FillRectangle(b, vertikalnaLeft, vertikalnaDown, (vertikalnaRight-vertikalnaLeft), (this.Size.Height - vertikalnaDown));


	    // Preprost izpis količine podatkov
	    /*
	    b = new SolidBrush(Color.Orange);
	    e.Graphics.DrawString(podatki.Count.ToString(), new Font(FontFamily.GenericSansSerif, 36), b, vertikalnaRight + 2, vertikalnaUp); 
	    */

	    // We will display the actual data here.


	    if (displayMode == 0) {


		if (signalMode == 0) {
		    // The signal

		    float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)((Convert.ToInt32(visibleSignal * Fvz))));

		    System.Console.WriteLine("ok " + step.ToString());



		    float maxValue = dataToDisplay.Max();
		    float minValue = dataToDisplay.Min();

		    b = new SolidBrush(Color.Orange);
		    e.Graphics.DrawString("1", new Font(FontFamily.GenericSansSerif, 8), b, 0, 0);
		    e.Graphics.DrawString("-1", new Font(FontFamily.GenericSansSerif, 8), b, 0, vertikalnaDown-15);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 8), b, 0, (vertikalnaDown)/2-8);


		    e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);

		    b = new SolidBrush(Color.Ivory);

		    float horizontalDraw = (float) horizontalnaLeft+1;

		    for (int i = 0; i < dataToDisplay.Length-1; i++) {
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown / 2 + dataToDisplay[i] * (vertikalnaDown / 2), horizontalDraw + step, vertikalnaDown / 2 + dataToDisplay[i+1] * (vertikalnaDown / 2));
			horizontalDraw = horizontalDraw + step;
			//System.Console.WriteLine("oh");
		    }

		    b = new SolidBrush(Color.Orange); 
		    e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);


		}
		else if (signalMode == 1) {
		    // The FFT

		}

	    }
	    else {

	    }



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

	void initTimer() {

	    timer.Interval = Convert.ToInt32(1000 / maxFPS);
	    timer.Elapsed += new ElapsedEventHandler(prepareDataToDisplay);	    
	}

	void startTimer() {
	    timer.Enabled = true;
	}

	void stopTimer() {
	    timer.Enabled = false;
	}

	private void prepareDataToDisplay(object source, ElapsedEventArgs e) {
	    if (displayMode != 0) {
		return;
	    }

	    if (signalMode == 0) {
		// Prepare the Actual signal

		// Prepare flatline
		dataToDisplay = new float [(Convert.ToInt32(visibleSignal*Fvz))];
		for (int i = 0; i<dataToDisplay.Length; i++){
		    dataToDisplay[i]=((float)0.0);
		}

		LinkedListNode<float> currentNode = podatki.Last;
		int r = dataToDisplay.Length - 1;
		while (currentNode != null && r>=0) {
		    dataToDisplay[r] = currentNode.Value;
		    currentNode = currentNode.Previous;
		    r--;
		}

	    }
	    else if (signalMode == 1) {
		// Prepare the FFT

	    }

	    this.Invalidate();

	}



    }
}
