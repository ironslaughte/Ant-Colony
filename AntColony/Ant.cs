using System;

namespace AntColony
{
    public class Ant
    {
        private int[] _trail;
        public int[] Trail => _trail;

        public static int Alpha { get; set; }
        public static int Beta { get; set; }   

        Random random = new Random();
        public Ant(int[] trail)
        {
            _trail = trail;
        }

        public void CreateTrail(int start, double[][] pheromones, int[][] dists)
        {
            _trail = new int[_trail.Length];
            bool[] visited = new bool[_trail.Length];
            _trail[0] = start;
            visited[start] = true;
            for (int i = 0; i <= _trail.Length - 2; i++)
            {
                int cityX = _trail[i];
                int next = NextCity(cityX, visited,pheromones,dists);
                _trail[i + 1] = next;
                visited[next] = true;
            }
        }

        private int NextCity(int cityX, bool[] visited, double[][] pheromones, int[][] dists)
        {
            double[] probs = CalculateProbs(cityX, visited, pheromones,dists);

            double[] cumul = new double[probs.Length + 1];
            for (int i = 0; i <= probs.Length - 1; i++)
                cumul[i + 1] = cumul[i] + probs[i];

            double p = random.NextDouble();

            for (int i = 0; i <= cumul.Length - 2; i++)
                if (p >= cumul[i] && p < cumul[i + 1])
                    return i;

            throw new Exception("Failure to return valid city in NextCity");
        }

        private double[] CalculateProbs(int cityX, bool[] visited, double[][] pheromones, int[][] dists)
        {
            double[] taueta = new double[_trail.Length];
            double sum = 0.0;
            for (int i = 0; i <= taueta.Length - 1; i++)
            {
                if (i == cityX)
                    taueta[i] = 0.0;
                else if (visited[i] == true)
                    taueta[i] = 0.0;
                else
                {
                    taueta[i] = Math.Pow(pheromones[cityX][i], Alpha) * Math.Pow((1.0 / Utils.Distance(dists,cityX, i)), Beta);
                    if (taueta[i] < 0.0001)
                        taueta[i] = 0.0001;
                    else if (taueta[i] > (double.MaxValue / (_trail.Length * 100)))
                        taueta[i] = double.MaxValue / (_trail.Length * 100);
                }
                sum += taueta[i];
            }

            double[] probs = new double[_trail.Length];
            for (int i = 0; i <= probs.Length - 1; i++)
                probs[i] = taueta[i] / sum;
            return probs;
        }
    }
}
