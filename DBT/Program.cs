using DBT;

while (true) 
{
    var cmd = Console.ReadLine();

    switch (cmd) 
    {
        case "add":
            Console.WriteLine("id");
            var parentId = int.Parse(Console.ReadLine() ?? "0");
            new Node(parentId);

            Console.WriteLine("ok");
            break;

        case "insert":
            Console.WriteLine("id");
            var id = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("key");
            var key = int.Parse(Console.ReadLine() ?? "0");

            Tree.Get(id)?.Insert(key, -1);
            Console.WriteLine("ok");
            break;

        case "find":
            Console.WriteLine("id");
            id = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("key");
            key = int.Parse(Console.ReadLine() ?? "0");

            var res = Tree.Get(id)?.Find(key);
            Console.WriteLine(res?.Id);
            Console.WriteLine("ok");
            break;

        case "print":
            Console.WriteLine("id");
            id = int.Parse(Console.ReadLine() ?? "0");

            var node = Tree.Get(id);
            Console.WriteLine($"{id} - {node?.Parent?.Id} - {node?.Start} - {node?.End} - {node?.Keys.Count}");
            break;
    }
}
