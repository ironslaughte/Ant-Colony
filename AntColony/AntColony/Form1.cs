using System;
using System.Windows.Forms;

namespace AntColony
{
    public partial class Form1 : Form
    {
        AntColony antColony;
        int numCities, numAnts, alpha, beta;
        double Q, rho;
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                ParseParams();
                RunAntColony();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RunAntColony()
        {
            antColony = new AntColony(numCities, numAnts, alpha, beta, Q, rho);
            int[][] graph = antColony.GetGraph();
            ShowGraph(graph);
            richTextBoxResAlg.Text = "";
            foreach (var bestLen in antColony.Run())
                richTextBoxResAlg.Text += "New Best Length of " + bestLen.ToString() + "\n";
            var BestTrail = antColony.GetBest();
            ShowAnswer(BestTrail);
        }

        private void ShowGraph(int[][] graph)
        {
            labelGraph.Text = "   ";
            for (int i = 0; i < graph.Length; i++)
                labelGraph.Text += $"{i + 1} ";
            labelGraph.Text += "\n";
            for (int i = 0; i < graph.Length; i++)
            {
                labelGraph.Text += $"{i + 1}: ";
                for (int j = 0; j < graph[i].Length; j++)
                    labelGraph.Text += $"{graph[i][j]} ";
                labelGraph.Text += "\n";
            }
        }

        private void ShowAnswer((double, int[]) bestTrail)
        {
            richTextBoxResAlg.Text += "Best trail length = " + bestTrail.Item1.ToString() + "\n" + "Best Trail way:";
            for (int i = 0; i < bestTrail.Item2.Length; i++)
            {
                richTextBoxResAlg.Text += (bestTrail.Item2[i]+1).ToString() + ";";
                if (i > 0 && i % 20 == 0)
                    richTextBoxResAlg.Text += "\n";
            }
            richTextBoxResAlg.Text += (bestTrail.Item2[0] + 1).ToString() + ";";
        }

        private void ParseParams()
        {
            numAnts = Int32.Parse(textBoxNumAnts.Text);
            numCities = Int32.Parse(textBoxNumCities.Text);
            alpha = Int32.Parse(textBoxAlpha.Text);
            beta = Int32.Parse(textBoxBeta.Text);
            Q = Double.Parse(textBoxQ.Text);
            rho = Double.Parse(textBoxRho.Text);
            CheckCorrectInputParams();
        }

        private void CheckCorrectInputParams()
        {
            if (numCities <= 2 || numAnts < 1 || alpha <= 1 || beta <= 1 || Q <= 0 || rho <= 0 || numCities > 10)
            {
                throw new ArgumentException("Параметры введены не корректно");
            }
        }
    }
}
