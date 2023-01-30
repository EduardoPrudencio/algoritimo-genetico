namespace GeneticAlgorithm
{
    public static class ConfigurationGA
    {
        private static int _sizeChomosome = 0;
        private static int _sizePopilation = 100;
        private static Random _rand = new Random((int)DateTime.Now.Ticks);
        private static bool _elitism = false;
        private static int _sizeElitism = 3;
        private static double _rateCrossover = 0.8;
        private static double _rateMutation = 0.01;
        private static int _numberOfCompetitors = 3;
        private static Mutation _mutationType = Mutation.NewIndividuo;

        public static int SizeChomosome { get {return _sizeChomosome;} set {_sizeChomosome = value;} }
        public static int SizePopilation { get { return _sizePopilation;} set { _sizePopilation = value;}}
        public static Random Random { get => _rand;}
        public static bool Elitism { get => _elitism; }
        public static int SizeElitism { get => _sizeElitism;}
        public static double RateCrossover { get => _rateCrossover;}
        public static double RateMutation { get => _rateMutation;}
        public static int NumberOfCompetitors { get => _numberOfCompetitors; set{_numberOfCompetitors = value;}}
        public static Mutation MutationType { get => _mutationType;}
    }

    public enum Mutation
    {
        NewIndividuo,
        InPopulation,
        InGenesPopulation,
    }

}