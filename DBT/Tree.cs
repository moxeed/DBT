namespace DBT
{
    internal class Tree
    {
        public static Dictionary<int, Node> Nodes { get; set; }

        static Tree()
        {
            Nodes = new Dictionary<int, Node>();
        }

        public static Node? Get(int key) {
            Nodes.TryGetValue(key, out Node? node);
            return node;
        }

        public static void Add(Node node)
        {
            Nodes[node.Id] = node;
        }
    }
}
