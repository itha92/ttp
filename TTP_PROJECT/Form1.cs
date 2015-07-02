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
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //intialize matrixes
            double[,] matrix1 = new double[,]{{20,15},{24,30}};
            
            double[,] matrix2 = new double[,]{{12,20},{19,10}};
            
            //agent class will get quadrant
            Agent agent1 = new Agent(matrix1);
            Agent agent2 = new Agent(matrix2);

            Console.WriteLine("Matrix 1:");
            agent1.PrintMatrix();
            Console.WriteLine("Matrix 2:");
            agent2.PrintMatrix();


            Console.WriteLine("Quadrant 1: " + agent1.quadrant[0] + "," + agent1.quadrant[1]);
            Console.WriteLine("Quadrant 2: " + agent2.quadrant[0] + "," + agent2.quadrant[1]);

            bool keep = true;
            int turn = 1;
            var agreement = false;
            while (keep)
            {

                if (turn == 1)
                {
                    agreement = agent1.SendProposalto(agent2);
                    if (!agreement)
                    {
                        //enviar proposal a agente 2
                        turn = 2;

                    }
                    else
                    {
                        //terminar programa
                        keep = false;
                    }
                }
                else
                {
                    turn = 1;
                }

                
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
