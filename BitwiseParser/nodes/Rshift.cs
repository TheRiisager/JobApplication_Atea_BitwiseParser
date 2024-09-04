namespace BitwiseParser
{
    class Rshift(string identifier, string[] inputs, ushort value) : INode<Rshift>
    {
        public ushort Value {get;} = value;
        public string Identifier { get; } = identifier;

        public string[] Inputs { get; set; } = inputs;

        public OperationType Type {get;} = OperationType.ASSIGNMENT;

        public ushort Output()
        {
            Console.WriteLine("processing output: " + Inputs[0] + " " + Type + " " + Value);
            INode left = INode.nodes[Inputs[0]];
            return (ushort)(left.Output() >>> Value);
        }

        public static Rshift FromLine(string line)
        {
            if(!line.Contains("RSHIFT"))
            {
                throw new Exception("Line is not an Rshift operation");
            }

            string[] lineArr = line.Split(' ');

            return new Rshift(lineArr[4], [lineArr[0]], ushort.Parse(lineArr[2]));
        }
    }
}