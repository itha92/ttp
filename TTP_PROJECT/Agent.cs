using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTP_PROJECT
{
    class Agent
    {

        public double[,] matrix;
        public int[] quadrant;//max value of matrix
        public int quantum = 1;
        public bool status = false;
        public List<Proposal> prevOffers = new List<Proposal>();
        public int x1 = 0;
        public int x2 = 0;
        public double val = 0;

        public Agent(double[,] matrix)
        {
            this.matrix = matrix;
            this.quadrant = FindCuadrant(matrix);
        }

        public class Proposal
        {
            public int x;
            public int y;
            public int n;

            public Proposal(int x, int y, int n)
            {
                this.x = x;
                this.y = y;
                this.n = n;
            }

        }
        
        public void PrintMatrix()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("[" + matrix[i,j] + "]");
                }
                Console.WriteLine();
            }
        }

        public int[] FindCuadrant(double[,] m)
        {
            double n = 0;
            int[] p = new int[2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (m[i, j] > n)
                    {
                        n = m[i, j];
                        p[0] = i;
                        p[1] = j;
                    }
                }
            }

            FindPlanB();

            return p;
        }

        public void FindPlanB()
        {
            List<double> n = new List<double>();
            double n1 = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (this.matrix[i, j] > n1)
                    {

                        n.Add(this.matrix[i, j]);
                    }
                }
            }
            this.val = n[2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (this.matrix[i, j] == this.val)
                    {
                        this.x1 = i;
                        this.x2 = j;
                    }
                }
            }
        }


        /**
         *1 Inicializar propuestas en ambos agentes
         *2 Buscar el maximo de la matriz
         *3 Guardar el cuadrante del maximo (para presentar en la propuesta)
         *4 Enviar la propuesta A (inicializar con mi maximo) (cuadrante y compensacion)
         *5 Comparar (revisa 2 cosas: la informacion que me enviaron ( si es menor que mi maximo, se rechaza; si es mayor Aceptar) revisar la siguiente propuesta anterior con la posible siguiente
         * (si la segunda propuesta es menor que mi segundo maximo, cambiar a segundo maximo y comenzar agente local de nuevo)
         * 
         * si la propuesta del Agente A es mayor que la propuesta del Agente B, yo envío compensacion (quantum)
         * sino , si B > A, entonces yo acepto propuesta, identifico el valor de la garantia (propia) y lo envio
         *  
         * esperar que responda. Recibir garantía
         * 
         * al recibir la garantía responder EEEEExito.
         * 
         * si responde No 
         */



        public bool SendProposalto(Agent a)
        {
            //1. check for the best quadrant
            //1.5 check for the second best quadrant
            //2. before sending, check for similar quadrants, y que siempre sea mayor que los demas (el que stas enviando)
            //3. send wanted quadrant to agent 2 with quantum
            //4. 
            //
            this.prevOffers.Add(new Proposal(a.quadrant[0],a.quadrant[1],a.quantum));
            Proposal p = new Proposal(a.quadrant[0], a.quadrant[1], a.quantum);
            bool accept = false;
            if ((this.matrix[p.x,p.y]+p.n) < this.matrix[this.quadrant[0],this.quadrant[1]])
            {
                accept = false;
                if (CheckPlanB(a))
                {
                    Console.WriteLine("Enviar warranty");
                    //send warranty
                }else
                {
                    //armar new  proposal;
                    Console.WriteLine("Armar nueva propuesta");
                    this.quantum += 1;
                    accept = false;

                    Console.WriteLine("Plan B, Agente 1:" + matrix[this.x1, this.x2] + "val:" + this.val);

                }
            }


            return accept;
        }

        public bool CheckPlanB(Agent a)
        {
            if (this.matrix[a.quadrant[0],a.quadrant[1]]+a.quantum > this.val)
            {
                return true;
            }
            return false;
        }

        public int ReceiveProposal(int[] quadrant, int quantum)
        {
            return 0;
        }

        public double SendWarranty()
        {
            return 0;
        }

        public bool ReceiveWarranty(double n)
        {
            return false;
        }
    }
}
