using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Advent_2020_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataPath = "trueData.txt";
            string[] lines = File.ReadAllLines(dataPath);
            var input = lines[1].Split(',');
            Dictionary<int, int> busPos = new();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "x")
                {
                    busPos.Add(int.Parse(input[i]), i); //Keys are the bus names and values are the required offset of the arrival time.
                }
            }
            long incrementSize = 1;
            long timestamp = 0;
            foreach (var busID in busPos.Keys)
            {
                int offset = busPos[busID];
                while ((timestamp + offset) % busID != 0)
                {
                    timestamp += incrementSize;
                    //Console.WriteLine($"Checked timestep: {timestamp} for bus {busID} using offset: {offset} and incrementSize: {incrementSize}");
                }
                Console.WriteLine($"Found match for {busID} at {timestamp}");
                incrementSize *= busID; //Stepsize is the LCM of the previous bus-IDs since that is the timestamp when the pattern repeats with the next valid prevous buses.
            }
            Console.WriteLine($"Final answer: {timestamp}");
        }
    }
}
