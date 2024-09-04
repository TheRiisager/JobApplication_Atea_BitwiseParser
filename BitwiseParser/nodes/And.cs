namespace BitwiseParser
{
    class And(string identifier, string[] inputs, bool isLeftValue, bool isRightValue) : INode<And>
    {
        public bool IsLeftValue {get;} = isLeftValue;

        public bool IsRightValue {get;} = isRightValue;
        public string Identifier { get; } = identifier;

        public string[] Inputs { get; set; } = inputs;

        public OperationType Type {get;} = OperationType.AND;

        public ushort Output()
        {
            Console.WriteLine("processing output: " + Inputs[0] + " " + Type + " " + Inputs[1]);
            if(IsLeftValue)
            {
                return (ushort)(ushort.Parse(Inputs[0]) & INode.nodes[Inputs[1]].Output());
            }

            if(IsRightValue)
            {
                 return (ushort)(INode.nodes[Inputs[0]].Output() & ushort.Parse(Inputs[1]));
            }
            return (ushort)(INode.nodes[Inputs[0]].Output() & INode.nodes[Inputs[1]].Output());
        }

        public static And FromLine(string line)
        {
            if(!line.Contains("AND"))
            {
                throw new Exception("Line is not an And operation");
            }

            string[] lineArr = line.Split(' ');
            bool leftValue = true;
            bool rightValue = true;
            try
            {
                ushort.Parse(lineArr[0]);
            } catch
            {
                leftValue = false;
            }
            try
            {
                ushort.Parse(lineArr[0]);
            } catch
            {
                rightValue = false;
            }

            return new And(lineArr[4], [lineArr[0], lineArr[2]], leftValue, rightValue);
        }
    }
}