namespace GeneticAlgorithm
{
    public class Population
    {
        public Individual[] _population;

        public Population()
        {
            
        }
        public void CalculateFitnes(){}
        public void Evaluate(){}
        public void RefleshIndexOfIndividual(){}
        public Individual[] GetPopulation(){throw new NotImplementedException();}
        public void SetIndividual(int position, Individual individual){}
        public double GetAvaragePopulation(){return 0;}
        public void OrderPopulation(){}
        public Individual GetBest(){throw new NotImplementedException();}
        public Individual GetBad(){throw new NotImplementedException();}
        public override string ToString()
        {
            base.ToString();
            return string.Empty;
        }

    }
}