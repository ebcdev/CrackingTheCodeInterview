
    public class RouteBetweenNodes_1 : IExcercise
    {
        public RouteBetweenNodes_1()
        {
        }

        public bool FindRouteBetweenNodes(Node a, Node b)
        {
            Queue<Node> queque = new Queue<Node>();
            queque.Enqueue(a);
            while (queque.Count > 0)
            {
                var node = queque.Dequeue();
                if (node == b)
                {
                    return true;
                }
                node.Subnodes.ForEach(subnode => queque.Enqueue(subnode));
            }
            return false;
        }

        public void RunExcercise()
        {
            Console.WriteLine("Finding a router between 1 and 7");
            Node node1 = new Node { Value = 1 };
            Node node2 = new Node { Value = 2 };
            Node node3 = new Node { Value = 3 };
            Node node4 = new Node { Value = 4 };
            Node node5 = new Node { Value = 5 };
            Node node7 = new Node { Value = 7 };

            node1.Subnodes.AddRange(new Node[] { node3, node7 });
            node2.Subnodes.Add(node5);
            node3.Subnodes.Add(node4);
            node4.Subnodes.Add(node7);

            Console.WriteLine($"Is there a route between 1 and 7? R={this.FindRouteBetweenNodes(node1, node7)}");




        }
    }

    public class Node
    {
        public int Value { get; set; }
        public List<Node> Subnodes { get; set; }

        public Node()
        {
            Subnodes = new List<Node>();
        }
    }
