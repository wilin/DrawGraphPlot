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
	    fluffy.Resume();
	}

	private void button4_Click(object sender, EventArgs e) {
	    thisExits();
	}

	private void button3_Click(object sender, EventArgs e) {
	    fluffy.Suspend();
	}
    }
}
