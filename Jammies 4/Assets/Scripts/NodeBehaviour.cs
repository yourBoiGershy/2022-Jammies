using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeBehaviour : MonoBehaviour
{
    private static int id = -1;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = id.ToString();
        id++;
    }

    public void OnButtonPress()
    {
        Node node = NodeSpawner.nodes[int.Parse(gameObject.name)];
        string nodes = "";
        string enemies = "";
        //Debug.Log(node.nextNodes + ", " + node.enemies + ", " + node.nodeType);

        if (node.nextNodes != null)
        {
            for (int i = 0; i < node.nextNodes.Length; i++)
            {
                nodes += node.nextNodes[i].id + ", ";
            }
        }

        if (node.enemies != null)
        {
            for (int j = 0; j < node.enemies.Length; j++)
            {
                enemies += node.enemies[j].enemyType + ", ";
            }
        }
        Debug.Log("Next nodes: " + nodes);
        Debug.Log("Enemies: " + enemies);
        Debug.Log("Node type: " + node.nodeType);


        //string name = EventSystem.current.currentSelectedGameObject.name;
 
    }
}
