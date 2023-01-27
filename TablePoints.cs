using System.Collections;

    namespace GeneticAlgorithm
    {
    public static class TablePoints
    {
        private static ArrayList X = new ArrayList();
        private static ArrayList Y = new ArrayList();
        private static double[,] tableDist;
        private static int pointCount = 0;
        public static void AddPoint(int x, int y)
        {
            X.Add(x);
            Y.Add(y);
            pointCount++;
            GenerateTable();
        }
        public static void GenerateTable()
        {
            tableDist = new double[pointCount, pointCount];

            for (int i = 0; i < pointCount; i++)
            {
                for (int j = 0; j < pointCount; j++)
                {
                    int xValueOne = int.Parse(X[i].ToString());
                    int xValueTwo = int.Parse(X[j].ToString());
                    double xPowValue = Math.Pow((xValueOne - xValueTwo), 2);    

                    int yValueOne = int.Parse(Y[i].ToString());
                    int yValueTwo = int.Parse(Y[j].ToString());
                    double yPowValue = Math.Pow((yValueOne - yValueTwo), 2);    

                    tableDist[i,j] = Math.Sqrt(xPowValue + yPowValue);
                }
            }

            ConfigurationGA.SizeChomosome = pointCount;
        }
        public static double[,] GetTableDist() => tableDist;
        public static double GetDist(int x, int y) => tableDist[x,y];
        public static int Count() => pointCount;
        public static string Print()
        {
            string data = string.Empty;

            for (int i = 0; i < pointCount; i++)
            {
                for (int j = 0; j < pointCount; j++)
                {
                    data += string.Format("{0:0.#}", double.Parse(tableDist[i,j].ToString()))+ "          ";
                }
                data += Environment.NewLine;
            }

            data += Environment.NewLine + "............................................................................................"
            + Environment.NewLine;
            
            return data;
        }
        public static int[] GetCoordinates(int point)
        {
            int[] arrayCordinates = new int[2];
            arrayCordinates[0] = int.Parse(X[point].ToString());
            arrayCordinates[1] = int.Parse(Y[point].ToString());

            return arrayCordinates;
        }
        public static void Clear()
        {
            X.Clear();
            Y.Clear();

            pointCount = 0;
            tableDist = null;
        }

    }
}