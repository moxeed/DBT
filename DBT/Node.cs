namespace DBT
{
    internal class Node
    {
        public static int id = 1;
        public int Start = int.MaxValue;
        public int End = int.MinValue;

        public int Id { get; set; }
        public Node? Parent { get; set; }
        public List<Node> Children { get; set; }
        public List<int> Keys { get; set; }

        public Node(int parentId)
        {
            Id = id++;
            Keys = new List<int>(); 
            Children = new List<Node>();

            Parent = Tree.Get(parentId);
            Parent?.AddChild(this);
            Tree.Add(this);
        }

        public void AddChild(Node node) 
        {
            Children.Insert(0, node);
            var start = (Keys.Max() - Keys.Min()) / Children.Count + Keys.Max();
            node.Reset(start, start);
        }

        public void Reset(int start, int end) 
        {
            Start = start;
            End = end;

            var keys = Keys.Select(x => x);
            Keys.Clear();

            foreach (var key in keys) {
                Insert(key, Id);
            }
        }

        public Node? Find(int key) {
            Console.WriteLine($"Find {Id}:{key}");
            if (!IsInRange(key))
            {
                if (Parent != null)
                 return Parent.Find(key);

                return null;    
            }

            foreach (var child in Children) 
            {
                if (child.IsInRange(key)) 
                {
                    return child.Find(key);
                }
            }

            return this;
        }

        public void Insert(int key, int sourceId) {
            Console.WriteLine($"Insert {Id}:{key} Source {sourceId}");

            if (Parent == null || Parent.Id == sourceId) {
                Insert(key);
                return;
            }

            if (!IsInRange(key))
            {
                Parent.Insert(key, Id);
                return;
            }

            Insert(key);
        }

        private bool Insert(int key) 
        {
            foreach (var child in Children) {
                if (key > child.Start) {
                    child.Insert(key, Id);
                    return true;
                }
            }

            Keys.Add(key);
            Start = Math.Min(Start, key);
            End = Math.Max(Start, key);
            return true;
        }

        public bool IsInRange(int key) => key >= Start && key <= End;
    }
}
