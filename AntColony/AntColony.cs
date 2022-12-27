using System;
using System.Collections.Generic;

namespace AntColony
{
    public class AntAlgorithm
    {
        private int _numCities;
        private int _numAnts;
        private double _bestLength, _rho, Q;

        private int[] _bestTrail;
        private int[][] _dists;
        private Ant[] Ants = null;
        private double[][] _pheromones;
        private static Random random = new Random(0);

        private int _numIter = 1000;


        public AntAlgorithm(int numCities, int numAnts, int alpha, int beta, double Q, double rho, int numIter, int[][] dists = null)
        {
            Ant.Alpha = alpha;
            Ant.Beta = beta;
            _numCities = numCities;
            _numAnts = numAnts;
            _rho = rho;
            _numIter = numIter;
            this.Q = Q;
            if (dists != null)
                _dists = dists;
            else
                _dists = GraphMaker.MakeGraphDistances(_numCities);
                InitializeComponents();
        }

        private void InitializeComponents()
        {             
             InitAnts();
            _pheromones = InitPheromones();
        }

        public IEnumerable<double> Run()
        {
                _bestTrail = BestTrail();
                _bestLength = Length(_bestTrail);

                int iter = 0;
                while (iter < _numIter)
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
                iter++;
                }
        }

        public (double, int[]) GetBest() => (_bestLength, _bestTrail);

        public int[][] GetGraph() => _dists;
        private void InitAnts()
        {
            Ants = new Ant[_numAnts];
            for (int k = 0; k <= _numAnts - 1; k++)
            {
                int start = random.Next(0, _numCities);
                Ants[k] = new Ant(RandomTrail(start));
            }
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
                result += Utils.Distance(_dists,trail[i], trail[i + 1]);
            result += Utils.Distance(_dists, trail[0], trail[trail.Length - 1]);
            return result;
        }

        private  int[] BestTrail()
        {
            double _bestLength = Length(Ants[0].Trail);
            int idx_bestLength = 0;
            for (int k = 1; k <= Ants.Length - 1; k++)
            {
                double len = Length(Ants[k].Trail);
                if (len < _bestLength)
                {
                    _bestLength = len;
                    idx_bestLength = k;
                }
            }          
            int[] _bestTrail_Renamed = new int[_numCities];
            Ants[idx_bestLength].Trail.CopyTo(_bestTrail_Renamed, 0);
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
            for (int k = 0; k <= Ants.Length - 1; k++)
            {
                int start = random.Next(0, _numCities);
                Ants[k].CreateTrail(start, _pheromones, _dists);
            }
        }

        private  void UpdatePheromones()
        {
            for (int i = 0; i <= _pheromones.Length - 1; i++)
            {
                for (int j = i + 1; j <= _pheromones[i].Length - 1; j++)
                {
                    for (int k = 0; k <= Ants.Length - 1; k++)
                    {
                        double length = Length(Ants[k].Trail);
                        // length of ant k trail
                        double decrease = (1.0 - _rho) * _pheromones[i][j];
                        double increase = 0.0;
                        if (EdgeInTrail(i, j, Ants[k].Trail) == true)
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
    }
}

