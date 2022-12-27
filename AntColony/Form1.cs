using K_means;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AntColony
{
    public partial class Form1 : Form
    {
        AntAlgorithm antColony;
        int numCities, numAnts, alpha, beta, numIter;
        double Q, rho;
        int[][] dists;
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
            if(comboBox1.SelectedIndex == 0) 
                antColony = new AntAlgorithm(numCities, numAnts, alpha, beta, Q, rho, numIter);
            else
                antColony = new AntAlgorithm(dists.Length, numAnts, alpha, beta, Q, rho, numIter, dists);
            int[][] graph = antColony.GetGraph();
            ShowGraph(graph);
            richTextBoxResAlg.Text = "";
            foreach (var bestLen in antColony.Run())
                richTextBoxResAlg.Text += "Новая лучшая длина пути: " + bestLen.ToString() + "\n";
            var BestTrail = antColony.GetBest();
            ShowAnswer(BestTrail);
        }

        private void InitializeDists(List<string[]> data)
        {
            dists = new int[data.Count][];
            for (int i = 0; i < data.Count; i++)
            {
                dists[i] = new int[data[i].Length];
                for (int j = 0; j < data[i].Length; j++)
                    dists[i][j] = int.Parse(data[i][j]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                var data = FileReader.Read("Graph.txt");
                InitializeDists(data);
                textBoxNumCities.Enabled = false;
            }
            else
                textBoxNumCities.Enabled = true;
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
            richTextBoxResAlg.Text += "Лучшая длина пути = " + bestTrail.Item1.ToString() + "\n" + "Лучший путь:";
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
            numIter = Int32.Parse(textBoxNumIter.Text);
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
