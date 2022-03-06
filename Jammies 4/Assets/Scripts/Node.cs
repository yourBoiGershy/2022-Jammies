using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Normal,
    Hard,
    Boss,
    Heal
}

public class Node
{
    public int id;
    public Node[] nextNodes;
    public Enemy[] enemies;
    public NodeType nodeType;
    public int xPos;
    public int yPos;

    private readonly bool[,] adjacency = new bool[,]
    {
        {false, true,   true,   false,  false,  false,  false,  false, false, false, false, false, false},
        {false, false,  false,  true,   true,   true,   false,  false, false, false, false, false, false},
        {false, false,  false,  false,  false,  true,   true,   false, false, false, false, false, false },
        {false, false,  false,  false,  false,  false,  false,  true,  false, false, false, false, false },
        {false, false,  false,  false,  false,  false,  false,  false, true,  false, false, false, false },
        {false, false,  false,  false,  false,  false,  false,  false, false, true,  false, false, false },
        {false, false,  false,  false,  false,  false,  false,  false, false, true,  false, false, false },
        {false, false,  false,  false,  false,  false,  false,  false, false, false, true,  false, false },
        {false, false,  false,  false,  false,  false,  false,  false, false, false, false, true,  false },
        {false, false,  false,  false,  false,  false,  false,  false, false, false, false, true,  false },
        {false, false,  false,  false,  false,  false,  false,  false, false, false, false, false, true },
        {false, false,  false,  false,  false,  false,  false,  false, false, false, false, false, true },
        {false, false,  false,  false,  false,  false,  false,  false, false, false, false, false, false }
    };

    public Node(int ident, Node[] nodes, NodeType type)
    {
        id = ident;
        if (nodes != null && nodes.Length > 0)
        {
            nextNodes = new Node[nodes.Length];
            nodes.CopyTo(nextNodes, 0);
        }
        enemies = null;
    }

    public Node(int ident, Enemy[] en, NodeType type)
    {
        id = ident;
        nextNodes = null;
        if (en != null && en.Length > 0)
        {
            enemies = new Enemy[en.Length];
            en.CopyTo(enemies, 0);
        }
        nodeType = type;
    }

    public Node(int ident, Node[] nodes, Enemy[] en, NodeType type)
    {
        id = ident;
        if (nodes != null && nodes.Length > 0)
        {
            nextNodes = new Node[nodes.Length];
            nodes.CopyTo(nextNodes, 0);
        }
        if (en != null && en.Length > 0)
        {
            enemies = new Enemy[en.Length];
            en.CopyTo(enemies, 0);
        }
        nodeType = type;
    }

    public bool Adjacent(int check)
    {
        return adjacency[id, check];
    }
}
