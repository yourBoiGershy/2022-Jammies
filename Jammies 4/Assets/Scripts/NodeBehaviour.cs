using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeBehaviour : MonoBehaviour
{
    private static int id = -1;
    private static Node currentNode;
    private static GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = id.ToString();
        id++;
        currentNode = NodeSpawner.nodes[0];
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector2(-540, -290);
    }

    public void OnButtonPress()
    {
        Node nextNode = NodeSpawner.nodes[int.Parse(gameObject.name)];
        if (currentNode.Adjacent(nextNode.id))
        {
            // display battle preview menu
            if (true) // DEBUGGING
            {
                GameObject node = GameObject.Find(nextNode.id.ToString());
                player.transform.position = node.transform.position;
                currentNode = nextNode;
            }
        }
        else
        {
            // do nothing
            // or display pop up telling player they cannot move to this node/stage/etc
        }


        //string nodes = "";
        //string enemies = "";
        //Debug.Log(node.nextNodes + ", " + node.enemies + ", " + node.nodeType);
        /*
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
        */

        //string name = EventSystem.current.currentSelectedGameObject.name;
 
    }
}
