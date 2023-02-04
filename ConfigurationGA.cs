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
        public static bool Elitism { get => _elitism; set {_elitism = value;}}
        public static int SizeElitism { get => _sizeElitism; set {_sizeElitism = value;}}
        public static double RateCrossover { get => _rateCrossover; set => _rateCrossover = value;}
        public static double RateMutation { get => _rateMutation; set => _rateMutation = value;}
        public static int NumberOfCompetitors { get => _numberOfCompetitors; set{_numberOfCompetitors = value;}}
        public static Mutation MutationType { get => _mutationType; set {_mutationType = value;}}
    }

    public enum Mutation
    {
        NewIndividuo,
        InPopulation,
        InGenesPopulation,
    }

}