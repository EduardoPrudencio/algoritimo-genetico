namespace GeneticAlgorithm
{
    public class Population
    {
        public Individual[] _population;

        public Population()
        {
           _population = new Individual[ConfigurationGA.SizePopilation];
           
           for (int i = 0; i < ConfigurationGA.SizePopilation; i++)
           {
             _population[i] = new Individual();
             _population[i].IndexOfVector = i; 

           }   

           CalculateFitnes();
        }
        public void CalculateFitnes()
        {
            for (int i = 0; i < ConfigurationGA.SizePopilation; i++)
            {
                _population[i].CalcFitness();
            }
        }
        public void Evaluate()
        {
            RefreshIndexOfIndividual();
            CalculateFitnes();
        }
        public void RefreshIndexOfIndividual()
        {
            for (int i = 0; i < ConfigurationGA.SizePopilation; i++)
            {
                _population[i].IndexOfVector = i;
            }
        }
        public Individual[] GetPopulation()
        {
            return _population;
        }
        public void SetIndividual(int position, Individual individual)
        {
            _population[position] = individual;
        }
        public double GetAvaragePopulation()
        {
            double sum = 0;

            foreach (Individual individual in _population)
                 sum = individual.Fitness;

            return sum / ConfigurationGA.SizePopilation;
        }
        public void OrderPopulation()
        {
            Individual individualAux;

            for (int i = 0; i < ConfigurationGA.SizePopilation; i++)
            {
                for (int j = 0; j < ConfigurationGA.SizePopilation; j++)
                {
                    if(_population[i].Fitness < _population[j].Fitness)
                    {
                        individualAux = _population[i];
                        _population[i] = _population[j];
                        _population[j] = individualAux;
                    } 
                }      
            }        
        }
        public Individual GetBest()
        {
            OrderPopulation();
            return _population[0];
        }
        public Individual GetBad()
        {
            OrderPopulation();
            return _population[_population.Count() -1];
        }
        public override string ToString()
        {
            base.ToString();
            string result = string.Empty;

            for (int i = 0; i < ConfigurationGA.SizePopilation; i++)
            {
                result += $"{_population[i].ToString()}\n";
            }

            return result;
        }
    }
}