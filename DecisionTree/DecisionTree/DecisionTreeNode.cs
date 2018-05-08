namespace DecisionTree
{
    class DecisionTreeNode
    {
        public bool IsHead { get; set; }
        public bool IsLeft { get; private set; }
        public DecisionTreeNode RightChild { get; set; } //the rule was executed (>)
        public DecisionTreeNode LeftChild { get; set; } //the rule wasn`t executed (<=)
        public int AmountOfElements { get; private set; }//how much elements this node has inside
        public Rule Rule { get; set; }
        public Data[] Elements { get; set; }
        public bool IsLeaf
        {
            get {
                if (RightChild == null && LeftChild == null)
                    return true;
                else
                    return false;
            }
        }

        public DecisionTreeNode() { }

        public DecisionTreeNode(Data[] elements)
        {
            Elements = elements;
            AmountOfElements = Elements.Length;
        }

        public DecisionTreeNode(Data[] elements, bool isLeft):this(elements)
        {
            IsLeft = isLeft;
        }

        public DecisionTreeNode(DecisionTreeNode copyNode)
        {
            IsHead = copyNode.IsHead;
            IsLeft = copyNode.IsLeft;
            AmountOfElements = copyNode.AmountOfElements;
            Elements = new Data[AmountOfElements];
            for (int i=0;i< AmountOfElements;i++)
                Elements[i] = new Data(copyNode.Elements[i]);
            if(copyNode.Rule != null)
                Rule = new Rule(copyNode.Rule);
        }

        private bool Compute(double[] rule)
        {
            //compute which side has a new child: left or right
            return true;
        }
    }
}
