namespace GeneticAlgorithm
{
    public class Individual
    {
        private int[] _chromosome;
        private double _fitness;
        private int _indexOfVector = 0;

        public Individual() 
        {
            _chromosome = new int[ConfigurationGA.SizeChomosome];
            List<int> _genes = Utils.RandomNumbers(0, ConfigurationGA.SizeChomosome);

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
            {
                _chromosome[i] = _genes[i];
            }

            CalcFitness();
        }
        public int IndexOfVector
        { 
            get {return _indexOfVector;}
            set {_indexOfVector = value;}
        }
        public double Fitness { 
            get {return _fitness;} 
            set {_fitness = value;} 
        }
        public void Evaluate()
        {
            CalcFitness();
        }
        public int[] GetChromosome()
        {
            return _chromosome;
        }
        public void CalcFitness()
        {
            double _totalDist = 0.0;

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
            {
                if(i < ConfigurationGA.SizeChomosome -1)
                {
                    _totalDist += TablePoints.GetDist(GetGene(i), GetGene(i + 1));
                }
                else
                {
                    _totalDist += TablePoints.GetDist(GetGene(i), GetGene(0));
                }
            }

            SetFitness(_totalDist);
        }
        public void SetGene(int position, int gene)
        {
            _chromosome[position] = gene;
        }
        public int GetGene(int position)
        {
            return _chromosome[position];
        }
        public void SetFitness(double fitness)
        {
            _fitness = fitness;
        }
        public void Mutate(int pointOne, int pointTwo)
        {
            if(pointOne < ConfigurationGA.SizeChomosome && pointTwo < ConfigurationGA.SizeChomosome && pointOne != pointTwo)
              {
                int temp = _chromosome[pointOne];
                _chromosome[pointOne] = _chromosome[pointTwo];
                _chromosome[pointTwo] = _chromosome[temp];
              }
        }
        
        public override string ToString()
        {
            base.ToString();

            string result = string.Empty;
            result += "Rota: ";

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
              result += (GetGene(i) +1).ToString() + " -> ";

            result += "Distância: " + _fitness;

            return result;
        }
    }
}