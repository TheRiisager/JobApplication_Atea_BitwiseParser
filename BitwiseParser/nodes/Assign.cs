namespace BitwiseParser
{
    class Assign(string identifier, string[] inputs, bool isInputRef) : INode<Assign>
    {
        public bool IsInputRef {get;} = isInputRef;
        public string Identifier { get; } = identifier;

        public string[] Inputs { get; set;} = inputs;

        public OperationType Type {get;} = OperationType.ASSIGNMENT;
        
        public ushort Output()
        {
            Console.WriteLine("processing output: " + Inputs[0] + " " + Type + " " + Identifier);
            string value = Inputs[0];
            if(IsInputRef)
            {
                return INode.nodes[value].Output();
            }

            return ushort.Parse(value);
        }

        public static Assign FromLine(string line)
        {
            if (new[] {"AND", "OR", "NOT", "RSHIFT", "LSHIFT"}.Any(c => line.Contains(c)))
            {
                throw new Exception("Line is not an Assignment operation");
            }
            string[] lineArr = line.Split(' ');

            bool isRef = false;
            try
            {
                ushort.Parse(lineArr[0]);
            } catch
            {
                isRef = true;
            }

            return new Assign(lineArr[2], [lineArr[0]], isRef);
        }
    }
}