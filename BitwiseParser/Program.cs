namespace BitwiseParser;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"input.txt");
        string text = File.ReadAllText(path);
        string[] array = StringParser.SplitLines(text).ToArray();

        foreach(var line in array)
        {
            if(string.IsNullOrEmpty(line))
            {
                break;
            }
            Console.WriteLine("processing line: " + line);
            INode node = line switch
                    {
                        string a when a.Contains("AND") => And.FromLine(line),
                        string a when a.Contains("OR") => Or.FromLine(line),
                        string a when a.Contains("NOT") => Not.FromLine(line),
                        string a when a.Contains("RSHIFT") => Rshift.FromLine(line),
                        string a when a.Contains("LSHIFT") => Lshift.FromLine(line),
                        _ => Assign.FromLine(line),
                    };
            string id = line.Split(' ').Last();
            INode.nodes.Add(id, node);
        }
        Console.WriteLine("Done!");

        Console.WriteLine(INode.nodes["a"].Output());
    }
}