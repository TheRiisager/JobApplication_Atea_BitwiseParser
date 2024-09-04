namespace BitwiseParser
{
    interface INode {
        public static Dictionary<string, INode> nodes = [];
        string Identifier {get;}
        string[] Inputs {get; set;}
        OperationType Type {get;}

        public ushort Output();
    }

    interface INode<T> : INode
    {
        static abstract public T FromLine(string line);
    }
}