namespace BitwiseParser
{
    class Or(string identifier, string[] inputs) : INode<Or>
    {
        public string Identifier { get; } = identifier;

        public string[] Inputs { get; set; } = inputs;

        public OperationType Type {get;} = OperationType.ASSIGNMENT;

        public static Or FromLine(string line)
        {
            if(!line.Contains("OR"))
            {
                throw new Exception("Line is not an Or operation");
            }

            string[] lineArr = line.Split(' ');

            return new Or(lineArr[4], [lineArr[0], lineArr[2]]);
        }

        public ushort Output()
        {
            Console.WriteLine("processing output: " + Inputs[0] + " " + Type + " " + Inputs[1]);
            INode left = INode.nodes[Inputs[0]];
            INode right = INode.nodes[Inputs[1]];
            return (ushort)(left.Output() | right.Output());
        }
    }
}