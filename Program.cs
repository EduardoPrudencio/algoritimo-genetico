using GeneticAlgorithm;

TablePoints.AddPoint(194, 11);
TablePoints.AddPoint(19, 25);
TablePoints.AddPoint(345, 11);
TablePoints.AddPoint(200, 111);
TablePoints.AddPoint(290, 89);

Console.WriteLine($"Exibindo a distância entre {TablePoints.Count()} pontos.\n");
Console.WriteLine(TablePoints.Print());
Console.WriteLine(Environment.NewLine);

Console.WriteLine("Criando população\n");

foreach (var item in Utils.RandomNumbers(0, 10))
{
    Console.Write($"{item} ");
}

Individual ind = new();

Console.WriteLine("\nExibindo individuo");
Console.WriteLine(ind);

ConfigurationGA.SizePopilation = 5;

Console.WriteLine("\nExibindo população\n");
Population pop = new Population();
Console.WriteLine(pop.ToString());

Console.WriteLine(".");