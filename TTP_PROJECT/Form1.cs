using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTP_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            Console.WriteLine("hola mundo");
            InitializeComponent();
        }

        public class Alfa{
            public void Beta()
            {
                while (true)
                {
                    Console.WriteLine("Alpha.Beta is runnig");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Threads start here");
            Alfa alfa = new Alfa();
            Thread ot = new Thread(new ThreadStart(alfa.Beta));
            ot.Start();
            while(!ot.IsAlive);
            Thread.Sleep(10);
            ot.Abort();
            ot.Join();
            Console.WriteLine();
            Console.WriteLine("Alpha has finished");
            try 
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                ot.Start();
            }
            catch (ThreadStateException) 
            {
                Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
                Console.WriteLine("Expected since aborted threads cannot be restarted.");
            }
            
        }

        
    }
}
