namespace GeneticAlgorithm
{
    public static class Utils
    {
        public static List<int> RandomNumbers(int start, int end)
        {
          List<int> numbers = new List<int>(end);

          for (int i = start; i < end; i++)
          {
            numbers.Add(i);
          }

          for (int i = 0; i < numbers.Count; i++)
          {
            int a = ConfigurationGA.Random.Next(numbers.Count);
            int temp = numbers[i];
            numbers[i] = numbers[a];
            numbers[a] = temp;
          }

            return numbers.GetRange(0, end);
        }
    }
}