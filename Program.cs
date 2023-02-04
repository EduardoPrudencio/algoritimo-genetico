using GeneticAlgorithm;

Console.WriteLine("Criando cidades...\n");
TablePoints.AddPoint(194, 11);
TablePoints.AddPoint(19, 25);
TablePoints.AddPoint(345, 11);
TablePoints.AddPoint(200, 111);
TablePoints.AddPoint(290, 89);

Console.WriteLine("Criando poopulação...\n");
ConfigurationGA.SizePopilation = 50;
Population population = new Population();

Console.WriteLine("Processando...\n");
ConfigurationGA.RateCrossover = 0.600;
ConfigurationGA.RateMutation = 0.001;
ConfigurationGA.NumberOfCompetitors = 3;
ConfigurationGA.MutationType = Mutation.NewIndividuo;
ConfigurationGA.Elitism = true;
ConfigurationGA.SizeElitism = 3;
ConfigurationGA.SizePopilation = 5;

Console.WriteLine($"Exibindo a distância entre {TablePoints.Count()} pontos.\n");
Console.WriteLine(TablePoints.Print());

GenetcAlgorithmMain GA = new();

for (int i = 0; i < 100; i++)
{
    population = GA.ExecuteGA(population);
    double mediaPopulation = population.GetAvaragePopulation();
}


Console.WriteLine("Best => " + population.GetBest());