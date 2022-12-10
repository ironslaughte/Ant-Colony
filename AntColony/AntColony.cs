using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntColony
{
    public class AntColony
    {
        private int _numCities;
        private int _numAnts;
        private int _alpha;
        private int _beta;
        private double _bestLength, _rho, Q;

        private int[] _bestTrail;
        private int[][] _dists;
        private int[][] _ants;
        private double[][] _pheromones;
        private static Random random = new Random(0);

        private const int MaxTime = 1000;


        public AntColony(int numCities, int numAnts, int alpha, int beta, double Q, double rho)
        {
            _numCities = numCities;
            _numAnts = numAnts;
            _alpha = alpha;
            _beta = beta;
            _rho = rho;
            this.Q = Q;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _dists = MakeGraphDistances(_numCities);
            _ants = InitAnts();
            _pheromones = InitPheromones();
        }

        public IEnumerable<double> Run()
        {
                _bestTrail = BestTrail();
                _bestLength = Length(_bestTrail);

                int time = 0;
                while (time < MaxTime)
                {
                    UpdateAnts();
                    UpdatePheromones();

                    int[] curr_bestTrail = BestTrail();
                    double curr_bestLength = Length(curr_bestTrail);
                    if (curr_bestLength < _bestLength)
                    {
                        _bestLength = curr_bestLength;
                        _bestTrail = curr_bestTrail;
                        yield return _bestLength;
                    }
                    time += 1;
                }
        }

        public (double, int[]) GetBest() => (_bestLength, _bestTrail);

        public int[][] GetGraph() => _dists;
        private  int[][] InitAnts()
        {
            int[][] ants = new int[_numAnts][];
            for (int k = 0; k <= _numAnts - 1; k++)
            {
                int start = random.Next(0, _numCities);
                ants[k] = RandomTrail(start);
            }
            return ants;
        }

        private  int[] RandomTrail(int start)
        {
            int[] trail = new int[_numCities];

            for (int i = 0; i <= _numCities - 1; i++)
                trail[i] = i;

            for (int i = 0; i <= _numCities - 1; i++)
            {
                int r = random.Next(i, _numCities);
                int tmp = trail[r];
                trail[r] = trail[i];
                trail[i] = tmp;
            }

            int idx = IndexOfTarget(trail, start);
            int temp = trail[0];
            trail[0] = trail[idx];
            trail[idx] = temp;

            return trail;
        }

        private  int IndexOfTarget(int[] trail, int target)
        {
            for (int i = 0; i <= trail.Length - 1; i++)
                if (trail[i] == target)
                    return i;

            throw new Exception("Target not found in IndexOfTarget");
        }

        private  double Length(int[] trail)
        {
            double result = 0.0;
            for (int i = 0; i <= trail.Length - 2; i++)
                result += Distance(trail[i], trail[i + 1]);
            result += Distance(trail[0], trail[trail.Length - 1]);
            return result;
        }

        private  int[] BestTrail()
        {
            double _bestLength = Length(_ants[0]);
            int idx_bestLength = 0;
            for (int k = 1; k <= _ants.Length - 1; k++)
            {
                double len = Length(_ants[k]);
                if (len < _bestLength)
                {
                    _bestLength = len;
                    idx_bestLength = k;
                }
            }
            int _numCities = _ants[0].Length;           
            int[] _bestTrail_Renamed = new int[_numCities];
            _ants[idx_bestLength].CopyTo(_bestTrail_Renamed, 0);
            return _bestTrail_Renamed;
        }

        private  double[][] InitPheromones()
        {
            double[][] pheromones = new double[_numCities][];
            for (int i = 0; i <= _numCities - 1; i++)
                pheromones[i] = new double[_numCities];

            for (int i = 0; i <= pheromones.Length - 1; i++)
            {
                for (int j = 0; j <= pheromones[i].Length - 1; j++)
                    pheromones[i][j] = 0.01;
                    
            }
            return pheromones;
        }

        private  void UpdateAnts()
        {           
            for (int k = 0; k <= _ants.Length - 1; k++)
            {
                int start = random.Next(0, _numCities);
                int[] newTrail = BuildTrail(k, start);
                _ants[k] = newTrail;
            }
        }

        private  int[] BuildTrail(int k, int start)
        {          
            int[] trail = new int[_numCities];
            bool[] visited = new bool[_numCities];
            trail[0] = start;
            visited[start] = true;
            for (int i = 0; i <= _numCities - 2; i++)
            {
                int cityX = trail[i];
                int next = NextCity(k, cityX, visited);
                trail[i + 1] = next;
                visited[next] = true;
            }
            return trail;
        }

        private  int NextCity(int k, int cityX, bool[] visited)
        {
            double[] probs = MoveProbs(cityX, visited);

            double[] cumul = new double[probs.Length + 1];
            for (int i = 0; i <= probs.Length - 1; i++)
                cumul[i + 1] = cumul[i] + probs[i];

            double p = random.NextDouble();

            for (int i = 0; i <= cumul.Length - 2; i++)
                if (p >= cumul[i] && p < cumul[i + 1])
                    return i;

            throw new Exception("Failure to return valid city in NextCity");
        }

        private  double[] MoveProbs(int cityX, bool[] visited)
        {
            double[] taueta = new double[_numCities];
            double sum = 0.0;
            for (int i = 0; i <= taueta.Length - 1; i++)
            {
                if (i == cityX)
                    taueta[i] = 0.0;
                else if (visited[i] == true)
                    taueta[i] = 0.0;    
                else
                {
                    taueta[i] = Math.Pow(_pheromones[cityX][i], _alpha) * Math.Pow((1.0 / Distance(cityX, i)), _beta);
                    if (taueta[i] < 0.0001)
                        taueta[i] = 0.0001;
                    else if (taueta[i] > (double.MaxValue / (_numCities * 100)))
                        taueta[i] = double.MaxValue / (_numCities * 100);
                }
                sum += taueta[i];
            }

            double[] probs = new double[_numCities];
            for (int i = 0; i <= probs.Length - 1; i++)
                probs[i] = taueta[i] / sum;
            return probs;
        }

        private  void UpdatePheromones()
        {
            for (int i = 0; i <= _pheromones.Length - 1; i++)
            {
                for (int j = i + 1; j <= _pheromones[i].Length - 1; j++)
                {
                    for (int k = 0; k <= _ants.Length - 1; k++)
                    {
                        double length = Length(_ants[k]);
                        // length of ant k trail
                        double decrease = (1.0 - _rho) * _pheromones[i][j];
                        double increase = 0.0;
                        if (EdgeInTrail(i, j, _ants[k]) == true)
                            increase = (Q / length);

                        _pheromones[i][j] = decrease + increase;

                        if (_pheromones[i][j] < 0.0001)
                            _pheromones[i][j] = 0.0001;
                        else if (_pheromones[i][j] > 100000.0)
                            _pheromones[i][j] = 100000.0;

                        _pheromones[j][i] = _pheromones[i][j];
                    }
                }
            }
        }

        private  bool EdgeInTrail(int cityX, int cityY, int[] trail)
        {
            int lastIndex = trail.Length - 1;
            int idx = IndexOfTarget(trail, cityX);

            if (idx == 0 && trail[1] == cityY)
            {
                return true;
            }
            else if (idx == 0 && trail[lastIndex] == cityY)
            {
                return true;
            }
            else if (idx == 0)
            {
                return false;
            }
            else if (idx == lastIndex && trail[lastIndex - 1] == cityY)
            {
                return true;
            }
            else if (idx == lastIndex && trail[0] == cityY)
            {
                return true;
            }
            else if (idx == lastIndex)
            {
                return false;
            }
            else if (trail[idx - 1] == cityY)
            {
                return true;
            }
            else if (trail[idx + 1] == cityY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private  int[][] MakeGraphDistances(int _numCities)
        {
            int[][] dists = new int[_numCities][];
            for (int i = 0; i <= dists.Length - 1; i++)
                 dists[i] = new int[_numCities];
            for (int i = 0; i <= _numCities - 1; i++)
            {
                for (int j = i + 1; j <= _numCities - 1; j++)
                {
                    int d = random.Next(1, 9);
                    // [1,8]
                    dists[i][j] = d;
                    dists[j][i] = d;
                }
            }
            return dists;
        }

        private double Distance(int cityX, int cityY) => _dists[cityX][cityY];
    }
}

