namespace GeneticAlgorithm
{
    public class GenetcAlgorithm
    {
        public delegate Individual[] Crossover(Individual fatherOne, Individual fatherTwo);
        public delegate Individual Selection(Population population);
     
        private double _rateCrossover;
        private double _rateMutation;
        private Crossover _crossover;
        private Selection _selection;

        // public GeneticAlgorithm
        // {
        //     //_crossover = CrossoverPMX();
        //     //_selection = Tournament();

        //     //_rateCrossover = ConfigurationGA.RateCrossover;
        //     //_rateMutation = ConfigurationGA.RateMutation;
        // }

        public Population ExecuteGA(Population population)
        {
            return null;
        }

        public Individual[] CrossoverPMX(Individual fatherOne, Individual fatherTwo)
        {
            Individual[] newIdividual = new Individual[2];
            
            int[] parentOne = new int[ConfigurationGA.SizeChomosome];
            int[] parentTwo=  new int[ConfigurationGA.SizeChomosome];

            int[] offSpringOneVector = new int[ConfigurationGA.SizeChomosome];
            int[] offSpringTwoVector = new int[ConfigurationGA.SizeChomosome];

            int[] replacementOne = new int[ConfigurationGA.SizeChomosome];
            int[] replacementTwo = new int[ConfigurationGA.SizeChomosome];

            int firstPoint = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);
            int secondPoint = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);

            if(firstPoint == secondPoint)
            {
                secondPoint = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);
            }

            if(secondPoint < firstPoint)
            {
                int temp = secondPoint;
                secondPoint = firstPoint;
                firstPoint = temp;
            }

            Console.WriteLine("P1: " + firstPoint + " P2: " + secondPoint);

            newIdividual[0] = new Individual();
            newIdividual[1] = new Individual();

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
            {
                parentOne[i] = offSpringOneVector[i] = fatherOne.GetGene(i);
                parentTwo[i] = offSpringTwoVector[i] = fatherTwo.GetGene(i);
            }

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
            {
                replacementOne[i] = replacementTwo[i] = -1;
            }

            for (int i = firstPoint; i <= secondPoint; i++)
            {
                offSpringOneVector[i] = parentTwo[i];
                offSpringTwoVector[i] = parentOne[i];

                replacementOne[parentTwo[i]] = parentOne[i];
                replacementTwo[parentOne[i]] = parentTwo[i];
            }

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
            {
                if(i >= firstPoint && i <= secondPoint) continue;

                int n1 = parentOne[i];
                int m1 = replacementOne[n1];

                int n2 = parentTwo[i];
                int m2 = replacementTwo[n1];

                while(m1 != -1)
                {
                    n1 = m1;
                    m1 = replacementOne[m1];
                }

                while(m1 != -1)
                {
                    n2 = m2;
                    m2 = replacementOne[m2];
                }

                offSpringOneVector[i] = n1;
                offSpringTwoVector[i] = n2;

            }

            for (int i = 0; i < ConfigurationGA.SizeChomosome; i++)
            {
                newIdividual[0].SetGene(i, offSpringOneVector[i]);
                newIdividual[1].SetGene(i, offSpringTwoVector[i]);
            }

            newIdividual[0].CalcFitness();
            newIdividual[1].CalcFitness();

            return newIdividual;
        }
        public Individual Mutation(Individual individual)
        {
            if(ConfigurationGA.Random.NextDouble() <= _rateMutation)
            {
                int genePositionOne = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);
                int genePositionTwo = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);
            
                if(genePositionOne == genePositionTwo)
                {
                    if(genePositionTwo < ConfigurationGA.SizeChomosome -2)
                    {
                        genePositionTwo++;
                    }
                }

                individual.Mutate(genePositionOne, genePositionTwo);
                return individual;
            }
            
            return individual;
        }
        public Population Mutation(Population population)
        {
            for (int i = 0; i < ConfigurationGA.SizePopilation; i++)
            {
                if(ConfigurationGA.Random.NextDouble() <= _rateMutation)
                {
                    int genePositionOne = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);
                    int genePositionTwo = ConfigurationGA.Random.Next(0, ConfigurationGA.SizeChomosome -1);
                
                    if(genePositionOne == genePositionTwo)
                    {
                        if(genePositionTwo < ConfigurationGA.SizeChomosome -2)
                        {
                            genePositionTwo++;
                        }
                        else
                        {
                            genePositionTwo -= 2;
                        }
                    }

                    population.GetPopulation()[1].Mutate(genePositionOne, genePositionTwo);
                }
            }

            return population;
        }
        public Population MutationGenesOfPopulation(Population population)
        {
            throw new NotImplementedException();
        }
        public Individual Tournament(Population population)
        {
            Individual[] competitors = new Individual[ConfigurationGA.NumberOfCompetitors];
            Individual aux = new Individual();
            aux.SetFitness(float.PositiveInfinity);

            for (int i = 0; i < ConfigurationGA.NumberOfCompetitors; i++)
            {
                competitors[i] = new Individual();
                competitors[i] = population.GetPopulation()[ConfigurationGA.Random.Next(0, ConfigurationGA.SizePopilation -1)];
            }

            for (int i = 0; i < ConfigurationGA.NumberOfCompetitors; i++)
            {
                if(competitors[i].Fitness < aux.Fitness) 
                {
                    aux = competitors[i];
                    aux.CalcFitness();
                }
            }
            
            return aux;
        }

    }
}