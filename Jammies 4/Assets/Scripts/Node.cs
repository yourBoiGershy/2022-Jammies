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
    public int id; // for debugging only (iirc???)
    public Node[] nextNodes;
    public Enemy[] enemies;
    public NodeType nodeType;

    public Node(int ident)
    {
        id = ident;
    }

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
}
