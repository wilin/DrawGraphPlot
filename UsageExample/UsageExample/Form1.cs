using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace UsageExample {
    public partial class Form1 : Form {

	Thread fluffy;
	Color[] barve = {Color.Red, Color.Green, Color.Blue, Color.White, Color.Black,
			    Color.Lime, Color.Yellow, Color.Orange, Color.Cyan };

	public Form1() {
	    InitializeComponent();

	    this.Show();

	    var proc = Process.GetCurrentProcess();

	    graphDisplay1.BackColor = Color.Cyan;

	    Random random = new Random();

	    var zacetek = proc.TotalProcessorTime;
	    List<float> tempPodatki = new List<float>();
	    for (int i = 0; i <= 500000; i++) {
		tempPodatki.Add((float)(random.NextDouble()*2.0-1.0));
		//System.Console.WriteLine(tempPodatki[i].ToString());
	    }
	    
	    graphDisplay1.addData(tempPodatki);
	    var konec = proc.TotalProcessorTime;
	    Console.Write("Generiranje List-a in dodajanje v LinkedList: ");
	    Console.WriteLine(konec - zacetek);

	    zacetek = proc.TotalProcessorTime;
	    for (int i = 0; i <= 500000; i++) {
		graphDisplay1.addData((float)(random.NextDouble()*2.0-1.0));
	    }

	    konec = proc.TotalProcessorTime;
	    Console.Write("Generiranje in dodajanje sproti: ");
	    Console.WriteLine(konec - zacetek);

	    // Some more testing text addition

	    
	    graphDisplay1.Invalidate();

	    fluffy = new Thread(automaticDataAdd);
	    fluffy.Start();

	}

	private void button1_Click(object sender, EventArgs e) {
	    Random random = new Random();
	    for (int i = 0; i < 5000; i++) {
		graphDisplay1.addData((float)(random.NextDouble() * 2.0 - 1.0));
	    }
	}

	private void automaticDataAdd() {
	    Random random = new Random();
	    for (;;) {
		graphDisplay1.addData((float)(random.NextDouble() * 2.0 - 1.0));
		Thread.Sleep(10);
	    }
	}

	public void thisExits() {
	    try {
		fluffy.Resume();
	    }
	    catch (Exception e) {

	    }
	    fluffy.Abort();
	    Application.Exit();
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
	    thisExits();
	}

	private void button2_Click(object sender, EventArgs e) {
	    try {
		fluffy.Resume();
	    }
	    catch (Exception ns) {
		System.Console.WriteLine("Thread not suspended");
	    }
	}

	private void button4_Click(object sender, EventArgs e) {
	    thisExits();
	}

	private void button3_Click(object sender, EventArgs e) {
	    fluffy.Suspend();
	}

	private void button5_Click(object sender, EventArgs e) {
	    // Signal mode
	    graphDisplay1.setSignalSelect(0);
	}

	private void button6_Click(object sender, EventArgs e) {
	    // FFT view
	    graphDisplay1.setSignalSelect(1);
	}

	private void button7_Click(object sender, EventArgs e) {
	    // Start recording mode
	    graphDisplay1.setRecordMode();
	}


	private void button8_Click(object sender, EventArgs e) {
	    // Start playback mode
	    graphDisplay1.setPlaybackMode();
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.BackColor = barve[comboBox1.SelectedIndex];
	}

	private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.setColorSidePanel(barve[comboBox2.SelectedIndex]);
	}

	private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.setColorBottomPanel(barve[comboBox3.SelectedIndex]);
	}

	private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.setColorWaterMark(barve[comboBox4.SelectedIndex]);
	}

	private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.setColorSideText(barve[comboBox5.SelectedIndex]);
	}

	private void comboBox6_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.setColorBottomText(barve[comboBox6.SelectedIndex]);
	}

	private void comboBox7_SelectedIndexChanged(object sender, EventArgs e) {
	    graphDisplay1.setColorZeroLine(barve[comboBox7.SelectedIndex]);
	}

	private void groupBox1_Enter(object sender, EventArgs e) {

	}

	private void button9_Click(object sender, EventArgs e) {
	    try {
		byte[] bytes = System.IO.File.ReadAllBytes("c:/sample2.wav");	// Mono!
		/*
		for (int i = 44; i < bytes.Length; i++) {
		    graphDisplay1.addData(bytes[i]);
		}
		*/
		for (int i = 44; i < bytes.Length - 2; i = i + 2) {	    // Int16 is 2 bytes :p
		    graphDisplay1.addData(BitConverter.ToInt16(bytes, i));
		}
	    }
	    catch (Exception nope) {

	    }
	}

	private void button10_Click(object sender, EventArgs e) {
	    // Increase visible portion
	    graphDisplay1.setVisibleSignal(graphDisplay1.getVisibleSignal() + (float)0.001);
	}

	private void button11_Click(object sender, EventArgs e) {
	    // Decrease visible portion
	    graphDisplay1.setVisibleSignal(graphDisplay1.getVisibleSignal() - (float)0.001);
	}

	private void button12_Click(object sender, EventArgs e) {
	    // Enable scaling
	    graphDisplay1.setScaling(true);
	}

	private void button13_Click(object sender, EventArgs e) {
	    graphDisplay1.setScaling(false);
	}



    }
}
