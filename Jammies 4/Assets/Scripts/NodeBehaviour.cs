using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeBehaviour : MonoBehaviour
{
    public static GameObject player;
    private static int id = -1;
    private static Node currentNode;

    private Text infoBox;
    private Text rewardBox;
    private Text moveBox;
    private Text infoHeader;
    private Text rewardHeader;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = id.ToString();
        id++;
        currentNode = NodeSpawner.nodes[0];
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector2(-540, -290);
    }

    public void Return()
    {
        player.transform.position = GameObject.Find(currentNode.id.ToString()).transform.position;
    }

    public void OnButtonPress()
    {
        Node nextNode = NodeSpawner.nodes[int.Parse(gameObject.name)];
        if (nextNode.Equals(NodeSpawner.nodes[0]))
            return;
        
        GameObject nextNodeObject = GameObject.Find(nextNode.id.ToString());

        infoBox = GameObject.Find("InfoText").GetComponent<Text>();
        rewardBox = GameObject.Find("RewardText").GetComponent<Text>();
        moveBox = GameObject.Find("MoveText").GetComponent<Text>();
        infoHeader = GameObject.Find("InfoHeader").GetComponent<Text>();
        rewardHeader = GameObject.Find("RewardHeader").GetComponent<Text>();

        string infoHeaderText = nextNode.nodeType.ToString() + " Stage";
        string infoText = "";
        string rewardText = "";
        if(nextNode.nodeType == NodeType.Heal)
        {
            infoText += "Repairs your ship to full durability.";
        }
        else
        {
            switch (nextNode.nodeType)
            {
                case NodeType.Normal:
                    rewardText += "+1 STAT point";
                    break;
                case NodeType.Hard:
                    infoText += "Enemies with unique abilities await.\nDefeat them to obtain their abilities.";
                    // get unique reward from node object
                    //rewardText += 
                    break;
                case NodeType.Boss:
                    infoText += "DANGER\n\n";
                    break;
                default:
                    for (int i = 0; i < nextNode.enemies.Length; i++)
                        infoText += nextNode.enemies[i] + "\n";
                    break;
            }
        }

        infoBox.text = infoText;
        rewardBox.text = rewardText;
        infoHeader.text = infoHeaderText;
        rewardHeader.text = "Reward";

        if (currentNode.Adjacent(nextNode.id))
        {
            moveBox.text = "Fight";
            // display battle preview menu
            if (true) // DEBUGGING
            {
                
                player.transform.position = nextNodeObject.transform.position;
                // if player presses move/battle/fight/??? and wins, set currentNode to nextNode
                // currentNode = nextNode;
            }
        }
        else
        {
            moveBox.text = "LOCKED";
            // do nothing
            // or display pop up telling player they cannot move to this node/stage/etc
        }

        ToggleCanvas.Show();
    }
}
