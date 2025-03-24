

## Resources 
- <https://github.com/MisterBooo/LeetCodeAnimation>

```csharp
    // preorder traversal
    //    50
    //   /  \
    //  30   70
    public void Preorder(Node node)
    {
        if (node == null)
            return;

        Console.Write(node.Data + " "); // Visit root
        Preorder(node.Left);            // Visit left subtree
        Preorder(node.Right);           // Visit right subtree
    }
    
    // Postorder Traversal (Recursive)
    //    50
    //   /  \
    //  30   70
    public void Postorder(Node node)
    {
        if (node == null)
            return;

        Postorder(node.Left);   // Visit left subtree
        Postorder(node.Right);  // Visit right subtree
        Console.Write(node.Data + " "); // Visit root
    }
    
    // Depth-First Search (DFS) - Inorder Traversal (Left → Root → Right)
    //    50
    //   /  \
    //  30   70
    public void DFS(Node node)
    {
        if (node == null)
            return;

        DFS(node.Left);   // Visit left subtree
        Console.Write(node.Data + " "); // Visit root
        DFS(node.Right);  // Visit right subtree
    }
    
    // Inorder Traversal using a Stack (Iterative)
    //    50
    //   /  \
    //  30   70
    public void Inorder(Node root)
    {
        if (Root == null) return;

        Stack<Node> stack = new Stack<Node>();
        Node current = root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            Console.Write(current.Data + " ");
            current = current.Right;
        }
    }
    
    //DFS Variants
    // DFS can be implemented in different ways:
    // Preorder DFS (Root → Left → Right) → Similar to Preorder Traversal.
    // Postorder DFS (Left → Right → Root) → Similar to Postorder Traversal.
    // Inorder DFS (Left → Root → Right) → Similar to Inorder Traversal.
    
    // Breadth-First Search (BFS) or Level Order Traversal
    //       1
    //      / \
    //     2   3
    //    / \
    //   4   5

    public void BFS(Node node)
    {
        if (node == null)
            return;

        // Start with the root node and put it in a queue.
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        // Process nodes level by level:
        while (queue.Count > 0)
        {
            // Dequeue (remove) a node from the front of the queue.
            Node current = queue.Dequeue();
            // Print the node.
            Console.Write(current.Data + " ");

            // Enqueue (add) its left child (if any).
            if (current.Left != null)
                queue.Enqueue(current.Left);

            // Enqueue (add) its right child (if any).
            if (current.Right != null)
                queue.Enqueue(current.Right);
        }
    }
    
    
    // BST
    //    50
    //   /  \
    //  30   70
    // /  \  /  \
    // 20  40 60  80
    // Insert a node into the BST using recursion
    public Node Insert(Node root, int data)
    {
        if (root == null)
            return new Node(data);

        if (data < root.Data)
            root.Left = Insert(root.Left, data);
        else if (data > root.Data)
            root.Right = Insert(root.Right, data);

        return root;
    }
    
    // Insert a node iteratively
    //    50
    //   /  \
    //  30   70
    // Tree after inserting 70

    public Node Insert(int data, Node root)
    {
        Node newNode = new Node(data);
        if (root == null)
        {
            return newNode; // Return new root if tree was empty
        }

        Node current = root, parent = null;
        while (current != null)
        {
            parent = current;
            if (data < current.Data)
                current = current.Left;
            else if (data > current.Data)
                current = current.Right;
            else
                return root; // No duplicates, return unchanged root
        }

        if (data < parent.Data)
            parent.Left = newNode;
        else
            parent.Right = newNode;
    
        return root; // Always return the root of the tree
    }

    // Search for a value in the BST using recursion
    //     50
    //   /  \
    //  30   70
    //  /
    // 20
    public bool Search(Node root, int key)
    {
        if (root == null)
            return false;

        if (root.Data == key)
            return true;
        else if (key < root.Data)
            return Search(root.Left, key);
        else
            return Search(root.Right, key);
    }
    
    // Search a node iteratively
    public bool Search(int key, Node root)
    {
        Node current = root;
        while (current != null)
        {
            if (key == current.Data)
                return true;
            else if (key < current.Data)
                current = current.Left;
            else
                current = current.Right;
        }
        return false;
    }
```

