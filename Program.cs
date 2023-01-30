using GeneticAlgorithm;

TablePoints.AddPoint(194, 11);
TablePoints.AddPoint(19, 25);
TablePoints.AddPoint(345, 11);
TablePoints.AddPoint(200, 111);
TablePoints.AddPoint(290, 89);

Console.WriteLine($"Exibindo a distância entre {TablePoints.Count()} pontos.\n");
Console.WriteLine(TablePoints.Print());
Console.WriteLine(Environment.NewLine);

ConfigurationGA.SizePopilation = 10;
ConfigurationGA.NumberOfCompetitors = 3;

Individual individualOne = new Individual();
Individual individualTwo = new Individual();

GenetcAlgorithm GA = new GenetcAlgorithm();
Individual[] newList = new Individual[2];

Console.WriteLine(individualOne);
Console.WriteLine(individualTwo);

newList = GA.CrossoverPMX(individualOne, individualTwo);

Console.WriteLine(newList[0]);
Console.WriteLine(newList[1]);
Console.WriteLine(".");