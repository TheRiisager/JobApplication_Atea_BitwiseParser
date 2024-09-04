namespace BitwiseParser
{
    class Not(string identifier, string[] inputs) : INode<Not>
    {
        public string Identifier { get; } = identifier;

        public string[] Inputs { get; set; } = inputs;

        public OperationType Type {get;} = OperationType.ASSIGNMENT;

        public static Not FromLine(string line)
        {
            if(!line.Contains("NOT"))
            {
                throw new Exception("Line is not an NOT operation");
            }

            string[] lineArr = line.Split(' ');

            return new Not(lineArr[3], [lineArr[1]]);
        }

        public ushort Output()
        {
            Console.WriteLine("processing output: " + Inputs[0] + " " + Type);
            INode val = INode.nodes[Inputs[0]];
            return (ushort)~val.Output();
        }
    }
}