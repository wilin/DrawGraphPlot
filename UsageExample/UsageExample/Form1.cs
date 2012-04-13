using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace UsageExample {
    public partial class Form1 : Form {
	public Form1() {
	    InitializeComponent();


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
		graphDisplay1.addData((float)(random.NextDouble()*1.0-1.0));
	    }

	    konec = proc.TotalProcessorTime;
	    Console.Write("Generiranje in dodajanje sproti: ");
	    Console.WriteLine(konec - zacetek);

	    graphDisplay1.Invalidate();

	}
    }
}
