using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

using fftwlib;

namespace GraphControl {
    public partial class GraphDisplay : UserControl {

	/*
	private int samplingFrequency = 0;
	private int refreshRate = 0;
	private float minDisplay = -1;
	private float maxDisplay = 1;
	*/


	private static int Fvz = 44100;	    // Mogoce kasneje float?
	private int maxFPS = 30;	    // 1-30, recimo
	private static float visibleSignal = (float)0.01;  // visibleSignal*Fvz = signal shown. Also known as how much signal in seconds.
	private int underSampling = 1;	    // 1-xy -> every n-th sample shown. (has to be more than 1!)
	private int hardLimitSamples = (Fvz*600);   // 10 minutes of signal

	private LinkedList<float> podatki = new LinkedList<float>();
	private LinkedList<float> podatkiPlayback = new LinkedList<float>();

	private float [] dataToDisplay = new float[(Convert.ToInt32(visibleSignal*Fvz))];    // When the Fvz or the visibleSignal variables are changed, this will be updated on the next timer iteration.
	
	// FFT
	private float[] fftDataIn;
	private float[] fftDataOut;
	private IntPtr pin;
	private IntPtr pout;
	private GCHandle hin, hout;
	private IntPtr fplan1;


	private int displayMode = 0;	// 0 == recording mode, 1 == playback mode 
	private int signalMode = 0;  // 0 == signal, 1 == FFT


	// So many colors.
	private Color sidePanel = Color.Honeydew;
	private Color bottomPanel = Color.Gray;
	private Color waterMark = Color.HotPink;
	private Color sideText = Color.Orange;
	private Color bottomText = Color.OrangeRed;
	private Color zeroLine = Color.Orange;


	public System.Timers.Timer timer = new System.Timers.Timer();

	// This is important
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

	    Brush b = new SolidBrush(bottomPanel);

	    // Primer horizontalnega fill-a / za izpifs Fvz, ||||, ...
	    e.Graphics.FillRectangle(b, horizontalnaLeft, horizontalnaUp, (horizontalnaRight - horizontalnaLeft), (horizontalnaDown - horizontalnaUp));

	    // Primer vertikalnega fill-a / za izpis jakosti signala, .....
	    b = new SolidBrush(sidePanel);
	    e.Graphics.FillRectangle(b, vertikalnaLeft, vertikalnaUp, (vertikalnaRight - vertikalnaLeft), (vertikalnaDown - vertikalnaUp));

	    // Primer fill-a neuporabljenega prostora (Prostor za copymark)
	    b = new SolidBrush(waterMark);
	    e.Graphics.FillRectangle(b, vertikalnaLeft, vertikalnaDown, (vertikalnaRight-vertikalnaLeft), (this.Size.Height - vertikalnaDown));


	    // Preprost izpis količine podatkov
	    /*
	    b = new SolidBrush(Color.Orange);
	    e.Graphics.DrawString(podatki.Count.ToString(), new Font(FontFamily.GenericSansSerif, 36), b, vertikalnaRight + 2, vertikalnaUp); 
	    */

	    // We will display the actual data here.


	    if (displayMode == 0) {
		// We're in recording mode.

		if (signalMode == 0) {
		    // The signal

		    float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)((Convert.ToInt32(visibleSignal * Fvz))));

		    //System.Console.WriteLine("ok " + step.ToString());



		    float maxValue = dataToDisplay.Max();
		    float minValue = dataToDisplay.Min();

		    b = new SolidBrush(sideText);
		    e.Graphics.DrawString("1", new Font(FontFamily.GenericSansSerif, 8), b, 0, 0);
		    e.Graphics.DrawString("-1", new Font(FontFamily.GenericSansSerif, 8), b, 0, vertikalnaDown-15);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 8), b, 0, (vertikalnaDown)/2-8);

		    // Add print or draw min and max values.


		    e.Graphics.DrawLine(new Pen(zeroLine), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);

		    b = new SolidBrush(waterMark);

		    float horizontalDraw = (float) horizontalnaLeft+1;

		    for (int i = 0; i < dataToDisplay.Length-1; i++) {
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown / 2 + dataToDisplay[i] * (vertikalnaDown / 2), horizontalDraw + step, vertikalnaDown / 2 + dataToDisplay[i+1] * (vertikalnaDown / 2));
			horizontalDraw = horizontalDraw + step;
			//System.Console.WriteLine("oh");
		    }

		    b = new SolidBrush(zeroLine); 
		    e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);


		}
		else if (signalMode == 1) {
		    // The FFT

		    float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)((Convert.ToInt32(visibleSignal * Fvz))/2));

		    //float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)(((Fvz)) / 2));

		    //System.Console.WriteLine("tff " + step.ToString());
		    float maxValue = dataToDisplay.Max();
		    float minValue = dataToDisplay.Min();

		    b = new SolidBrush(sideText);
		    e.Graphics.DrawString(String.Format("{0:0.#}", maxValue), new Font(FontFamily.GenericSansSerif, 7), b, 0, 0);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 7), b, 0, vertikalnaDown - 15);

		    e.Graphics.DrawString("", new Font(FontFamily.GenericSansSerif, 7), b, 0, vertikalnaDown - 15);

		    // Dodaj še izpis frekvence spodaj

		    //e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);


		    b = new SolidBrush(bottomText);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 7), b, horizontalnaLeft, vertikalnaDown);

		    e.Graphics.DrawString(Convert.ToString(Fvz / 2), new Font(FontFamily.GenericSansSerif, 7), b, (horizontalnaLeft+horizontalnaRight)/2, vertikalnaDown);


		    b = new SolidBrush(waterMark);
		    
		    float horizontalDraw = (float)horizontalnaLeft + 1;
		    /*for (int i = 0; i < dataToDisplay.Length; i = i+2) {
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown - 1, horizontalDraw, vertikalnaDown - dataToDisplay[i] * (vertikalnaDown) +2);
			horizontalDraw = horizontalDraw + step;
		    }
		    */

		    for (int i = 0; i < dataToDisplay.Length; i++) {
			//e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown, horizontalDraw, vertikalnaDown - (dataToDisplay[i]/maxValue) * vertikalnaDown );
			//e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown, horizontalDraw, vertikalnaDown - (1-dataToDisplay[i]/maxValue) * (vertikalnaDown));
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown-1, horizontalDraw, (1 - dataToDisplay[i] / maxValue) * (vertikalnaDown-1));
			
			horizontalDraw = horizontalDraw + step;
		    }

		    //b = new SolidBrush(Color.Orange);
		    //e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);


		}

	    }
	    else {
		// Else, we're in playback mode...
		if (signalMode == 0) {
		    // Raw signal

		    float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)((Convert.ToInt32(visibleSignal * Fvz))));

		    //System.Console.WriteLine("ok " + step.ToString());



		    float maxValue = dataToDisplay.Max();
		    float minValue = dataToDisplay.Min();

		    b = new SolidBrush(sideText);
		    e.Graphics.DrawString("1", new Font(FontFamily.GenericSansSerif, 8), b, 0, 0);
		    e.Graphics.DrawString("-1", new Font(FontFamily.GenericSansSerif, 8), b, 0, vertikalnaDown - 15);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 8), b, 0, (vertikalnaDown) / 2 - 8);

		    // Add print or draw min and max values.


		    e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);

		    b = new SolidBrush(waterMark);

		    float horizontalDraw = (float)horizontalnaLeft + 1;

		    for (int i = 0; i < dataToDisplay.Length - 1; i++) {
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown / 2 + dataToDisplay[i] * (vertikalnaDown / 2), horizontalDraw + step, vertikalnaDown / 2 + dataToDisplay[i + 1] * (vertikalnaDown / 2));
			horizontalDraw = horizontalDraw + step;
			//System.Console.WriteLine("oh");
		    }

		    b = new SolidBrush(zeroLine);
		    e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);


		}
		else {
		    // FFT

		    float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)((Convert.ToInt32(visibleSignal * Fvz)) / 2));

		    //float step = (float)(Convert.ToDouble(horizontalnaRight - horizontalnaLeft - 2) / (float)(((Fvz)) / 2));

		    //System.Console.WriteLine("tff " + step.ToString());
		    float maxValue = dataToDisplay.Max();
		    float minValue = dataToDisplay.Min();

		    b = new SolidBrush(sideText);
		    e.Graphics.DrawString(String.Format("{0:0.#}", maxValue), new Font(FontFamily.GenericSansSerif, 7), b, 0, 0);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 7), b, 0, vertikalnaDown - 15);

		    e.Graphics.DrawString("", new Font(FontFamily.GenericSansSerif, 7), b, 0, vertikalnaDown - 15);

		    // Dodaj še izpis frekvence spodaj

		    //e.Graphics.DrawLine(new Pen(b), horizontalnaLeft + 1, vertikalnaDown / 2, horizontalnaRight - 1, vertikalnaDown / 2);

		    b = new SolidBrush(bottomText);
		    e.Graphics.DrawString("0", new Font(FontFamily.GenericSansSerif, 7), b, horizontalnaLeft, vertikalnaDown);

		    e.Graphics.DrawString(Convert.ToString(Fvz / 2), new Font(FontFamily.GenericSansSerif, 7), b, (horizontalnaLeft + horizontalnaRight) / 2, vertikalnaDown);


		    b = new SolidBrush(waterMark);
		    
		    float horizontalDraw = (float)horizontalnaLeft + 1;
		    /*for (int i = 0; i < dataToDisplay.Length; i = i+2) {
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown - 1, horizontalDraw, vertikalnaDown - dataToDisplay[i] * (vertikalnaDown) +2);
			horizontalDraw = horizontalDraw + step;
		    }
		    */

		    for (int i = 0; i < dataToDisplay.Length; i++) {
			//e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown, horizontalDraw, vertikalnaDown - (dataToDisplay[i]/maxValue) * vertikalnaDown );
			//e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown, horizontalDraw, vertikalnaDown - (1-dataToDisplay[i]/maxValue) * (vertikalnaDown));
			e.Graphics.DrawLine(new Pen(b), horizontalDraw, vertikalnaDown - 1, horizontalDraw, (1 - dataToDisplay[i] / maxValue) * (vertikalnaDown - 1));

			horizontalDraw = horizontalDraw + step;
		    }
		}

	    }



	    b.Dispose();
	}

	public void addData(List<float> data){
	    foreach (float x in data){
		podatki.AddLast(x);
	    }
	    if (podatki.Count > hardLimitSamples) {
		int toRemove = podatki.Count - hardLimitSamples;
		while (toRemove > 0) {
		    podatki.RemoveFirst();
		    toRemove--;
		}
	    }
	}

	public void addData(float data) {
	    podatki.AddLast(data);
	    if (podatki.Count > hardLimitSamples) {
		int toRemove = podatki.Count - hardLimitSamples;
		while (toRemove > 0) {
		    try {
			podatki.RemoveFirst();
			toRemove--;
		    }
		    catch {
		    }
		}
	    }
	}


	public void addData(Int16 data) {	    // This is signed ><
	    podatki.AddLast((float)(Convert.ToDouble(data) / (65535.0/2.0)));
	    if (podatki.Count > hardLimitSamples) {
		int toRemove = podatki.Count - hardLimitSamples;
		while (toRemove > 0) {
		    try {
			podatki.RemoveFirst();
			toRemove--;
		    }
		    catch{
		    }
		}
	    }
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
	    if (displayMode == 0) {
		// Recording mode
		if (signalMode == 0) {
		    // Prepare the Actual signal

		    // Prepare flatline
		    dataToDisplay = new float[(Convert.ToInt32(visibleSignal * Fvz))];
		    for (int i = 0; i < dataToDisplay.Length; i++) {
			dataToDisplay[i] = ((float)0.0);
		    }

		    LinkedListNode<float> currentNode = podatki.Last;
		    int r = dataToDisplay.Length - 1;
		    while (currentNode != null && r >= 0) {
			dataToDisplay[r] = currentNode.Value;
			int j = 0;
			while (currentNode != null && j < underSampling) {
			    currentNode = currentNode.Previous;
			    j++;
			}
			r--;
		    }

		}
		else if (signalMode == 1) {
		    // Prepare the FFT

		    // This is TESTING DATA. No FFT implemented yet.
		    // Prepare flatline
		    dataToDisplay = new float[(Convert.ToInt32(visibleSignal * Fvz))];
		    for (int i = 0; i < dataToDisplay.Length; i++) {
			dataToDisplay[i] = ((float)0.0);
		    }

		    LinkedListNode<float> currentNode = podatki.Last;
		    int r = dataToDisplay.Length - 1;
		    while (currentNode != null && r >= 0) {
			dataToDisplay[r] = currentNode.Value;
			int j = 0;
			while (currentNode != null && j < underSampling) {
			    currentNode = currentNode.Previous;
			    j++;
			}
			r--;
		    }
		    // We decided, to do the FFT right here and now.

		    fftwf.free(pin);
		    fftwf.free(pout);
		    if (hin.IsAllocated == true && hout.IsAllocated == true) {
			try {
			    hin.Free();
			    hout.Free();
			}
			catch (Exception grr) {
			}
		    }
		    pin = fftwf.malloc((Convert.ToInt32(visibleSignal * Fvz)) * 8);	    // Float needs more than int.
		    pout = fftwf.malloc((Convert.ToInt32(visibleSignal * Fvz)) * 8);
		    fftDataIn = new float[(Convert.ToInt32(visibleSignal * Fvz)) * 2];
		    fftDataOut = new float[(Convert.ToInt32(visibleSignal * Fvz)) * 2];
		    hin = GCHandle.Alloc(fftDataIn, GCHandleType.Pinned);
		    hout = GCHandle.Alloc(fftDataOut, GCHandleType.Pinned);

		    for (int i = 0; i < (Convert.ToInt32(visibleSignal * Fvz)); i++) {
			fftDataIn[i] = dataToDisplay[i];
			fftDataOut[i] = dataToDisplay[i];
			fftDataIn[i + (Convert.ToInt32(visibleSignal * Fvz))] = dataToDisplay[i];
			fftDataOut[i + (Convert.ToInt32(visibleSignal * Fvz))] = dataToDisplay[i];
		    }

		    Marshal.Copy(fftDataIn, 0, pin, (Convert.ToInt32(visibleSignal * Fvz)) * 2);
		    Marshal.Copy(fftDataOut, 0, pout, (Convert.ToInt32(visibleSignal * Fvz)) * 2);

		    try {
			fplan1 = fftwf.dft_1d((Convert.ToInt32(visibleSignal * Fvz)), pin, pout, fftw_direction.Forward, fftw_flags.Estimate);

			fftwf.execute(fplan1);

			Marshal.Copy(pout, fftDataOut, 0, (Convert.ToInt32(visibleSignal * Fvz)) * 2);

			for (int i = 0; i < (Convert.ToInt32(visibleSignal * Fvz)); i++) {
			    dataToDisplay[i] = Math.Abs(fftDataOut[i + 1]);
			}
		    }
		    catch (Exception thisSometimesFails) {

		    }

		    /*
		    try {
			IntPtr pin;
			pin = fftwf.malloc(1024 * 8);
		    }
		    catch (Exception missingDll) {
			System.Console.WriteLine(missingDll.ToString());
		    }
		    */
		    /*
				    for (int k = 0; k < dataToDisplay.Length-2; k = k + 2) {
					dataToDisplay[k] = Math.Abs((dataToDisplay[k] + dataToDisplay[k + 1]) / 2);
				    }
		    */

		}
	    }
	    else {
		// Playback mode
		// We will do most of the heavy lifting here
		// Get the value of the trackbar, get the piece of data, put it into toDisplay, party.

		//Console.WriteLine(hScrollBar1.Value.ToString() + " " + podatkiPlayback.Count.ToString() + " " + ((2*podatkiPlayback.Count)/Convert.ToInt32(visibleSignal * Fvz)).ToString());
		if (signalMode == 0) {
		    // Raw signal

		    // Prepare flatline
		    dataToDisplay = new float[(Convert.ToInt32(visibleSignal * Fvz))];
		    for (int i = 0; i < dataToDisplay.Length; i++) {
			dataToDisplay[i] = ((float)0.0);
		    }

		    int barValue = hScrollBar1.Value;
		    int offsetFromLast = ((hScrollBar1.Maximum - barValue) * (Convert.ToInt32(visibleSignal * Fvz)))/100;
		    LinkedListNode<float> currentNode = podatkiPlayback.Last;
		    while (currentNode != null && offsetFromLast > 0) {
			currentNode = currentNode.Previous;
			offsetFromLast--;
		    }
		    int r = dataToDisplay.Length - 1;
		    while (currentNode != null && r >= 0) {
			dataToDisplay[r] = currentNode.Value;
			int j = 0;
			while (currentNode != null && j < underSampling) {
			    currentNode = currentNode.Previous;
			    j++;
			}
			r--;
		    }


		}
		else {
		    // FFT
		    // Prepare flatline
		    dataToDisplay = new float[(Convert.ToInt32(visibleSignal * Fvz))];
		    for (int i = 0; i < dataToDisplay.Length; i++) {
			dataToDisplay[i] = ((float)0.0);
		    }

		    int barValue = hScrollBar1.Value;
		    int offsetFromLast = ((hScrollBar1.Maximum - barValue) * (Convert.ToInt32(visibleSignal * Fvz))) / 100;
		    LinkedListNode<float> currentNode = podatkiPlayback.Last;
		    while (currentNode != null && offsetFromLast > 0) {
			currentNode = currentNode.Previous;
			offsetFromLast--;
		    }
		    int r = dataToDisplay.Length - 1;
		    while (currentNode != null && r >= 0) {
			dataToDisplay[r] = currentNode.Value;
			int j = 0;
			while (currentNode != null && j < underSampling) {
			    currentNode = currentNode.Previous;
			    j++;
			}
			r--;
		    }
		    // FFT here
		    fftwf.free(pin);
		    fftwf.free(pout);
		    if (hin.IsAllocated == true && hout.IsAllocated == true) {
			try {
			    hin.Free();
			    hout.Free();
			}
			catch (Exception gr) {
			}
		    }
		    pin = fftwf.malloc((Convert.ToInt32(visibleSignal * Fvz)) * 8);	    // Float needs more than int.
		    pout = fftwf.malloc((Convert.ToInt32(visibleSignal * Fvz)) * 8);
		    fftDataIn = new float[(Convert.ToInt32(visibleSignal * Fvz)) * 2];
		    fftDataOut = new float[(Convert.ToInt32(visibleSignal * Fvz)) * 2];
		    hin = GCHandle.Alloc(fftDataIn, GCHandleType.Pinned);
		    hout = GCHandle.Alloc(fftDataOut, GCHandleType.Pinned);

		    for (int i = 0; i < (Convert.ToInt32(visibleSignal * Fvz)); i++) {
			fftDataIn[i] = dataToDisplay[i];
			fftDataOut[i] = dataToDisplay[i];
			fftDataIn[i + (Convert.ToInt32(visibleSignal * Fvz))] = dataToDisplay[i];
			fftDataOut[i + (Convert.ToInt32(visibleSignal * Fvz))] = dataToDisplay[i];
		    }

		    Marshal.Copy(fftDataIn, 0, pin, (Convert.ToInt32(visibleSignal * Fvz)) * 2);
		    Marshal.Copy(fftDataOut, 0, pout, (Convert.ToInt32(visibleSignal * Fvz)) * 2);

		    try {
			fplan1 = fftwf.dft_1d((Convert.ToInt32(visibleSignal * Fvz)), pin, pout, fftw_direction.Forward, fftw_flags.Estimate);

			fftwf.execute(fplan1);

			Marshal.Copy(pout, fftDataOut, 0, (Convert.ToInt32(visibleSignal * Fvz)) * 2);
			
			for (int i = 0; i < (Convert.ToInt32(visibleSignal * Fvz)); i++) {
			    dataToDisplay[i] = Math.Abs(fftDataOut[i + 1]);
			}
		    }
		    catch (Exception thisSometimesFailsToo) {

		    }
		}

	    }



	    this.Invalidate();

	}

	public int getMode() {
	    return displayMode;
	}

	public void setRecordMode() {
	    hScrollBar1.Enabled = false;
	    displayMode = 0;
	}

	public void setPlaybackMode() {
	    podatkiPlayback = new LinkedList<float>();
	    LinkedListNode<float> currentNode = podatki.Last;
	    while (currentNode != null) {
		podatkiPlayback.AddFirst(currentNode.Value);
		currentNode = currentNode.Previous;
	    }
	    hScrollBar1.Enabled = true;
	    hScrollBar1.Minimum = 0;
	    //hScrollBar1.Maximum = Convert.ToInt32(podatkiPlayback.Count);
	    hScrollBar1.Maximum = 100*((podatkiPlayback.Count) / (Convert.ToInt32(visibleSignal * Fvz)));
	    hScrollBar1.Value = hScrollBar1.Maximum;
	    displayMode = 1;
	}

	// Objects, objects everywhere
	public void setSamplingFrequency(int freq) {
	    if (freq > 0) {
		Fvz = freq;
	    }
	}
	public int getSamplingFrequency() {
	    return Fvz;
	}

	public void setFramerate(int fr) {
	    if (fr>0 && fr<35){
		maxFPS = fr;
	    }
	}
	public int getFramerate() {
	    return maxFPS;
	}

	public void setVisibleSignal(float portion) {
	    if (portion > (float)0.0) {
		visibleSignal = portion;
	    }
	}
	public float getVisibleSignal() {
	    return visibleSignal;
	}

	public void setUndersampling(int us) {
	    if (us > 0) {
		underSampling = us;
	    }
	}
	public int getUndersampling() {
	    return underSampling;
	}

	public void setSignalLengthMax(int len) {
	    if (len > 10) {
		hardLimitSamples = len;
	    }
	}
	public int getSignalLengthMax() {
	    return hardLimitSamples;
	}

	public void setSignalSelect(int mode) {
	    if (mode == 0 || mode == 1) {
		signalMode = mode;
	    }
	}
	public int getSignalSelect() {
	    return signalMode;
	}

	public void setColorSidePanel(Color c) {
	    sidePanel = c;
	}
	public Color getColorSidePanel() {
	    return sidePanel;
	}

	public void setColorBottomPanel(Color c) {
	    bottomPanel = c;
	}
	public Color getColorBottomPanel() {
	    return bottomPanel;
	}

	public void setColorWaterMark(Color c) {
	    waterMark = c;
	}
	public Color getColorWaterMark() {
	    return waterMark;
	}

	public void setColorSideText(Color c) {
	    sideText = c;
	}
	public Color getColorSideText() {
	    return sideText;
	}

	public void setColorBottomText(Color c) {
	    bottomText = c;
	}
	public Color getColorBottomText() {
	    return bottomText;
	}

	public void setColorZeroLine(Color c) {
	    zeroLine = c;
	}
	public Color getColorZeroLine() {
	    return zeroLine;
	}
    }
}
