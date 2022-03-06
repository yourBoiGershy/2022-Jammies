using UnityEngine;
using UnityEngine.UI;

public class NodeSpawner : MonoBehaviour
{
    // The GameObject to instantiate.
    public GameObject entityToSpawn;
    public GameObject canvas;
    public Sprite[] sprites;

    public static Node[] nodes;

    void Awake()
    {
        // random placeholder enemies (generic & special)

        string enemy1 = "Regular Enemy";
        string enemy2 = "Moving Enemy";
        string enemy3 = "High Damage Enemy";
        string enemy4 = "Twinshot Boss";
        string enemy5 = "Shotgun Boss";
        string enemy6 = "Big Bad Boss";
        

        // random placeholder sets of enemies
        /*
        Enemy[] enemies1 = { enemy1, enemy2 };
        Enemy[] enemies2 = { enemy3, enemy1 };
        Enemy[] enemies3 = { enemy1, enemy2, enemy3 };
        Enemy[] stageHard1 = { enemy2, enemyMobile };
        Enemy[] stageHard2 = { enemy3, enemy1, enemySpread };
        Enemy[] stageHard3 = { enemy1, enemyStrong };
        Enemy[] stageBoss = { enemy1, enemy2, enemy3, enemyMobile, enemyStrong, enemySpread, boss };
        */

        // somehow specify how enemy waves will appear? will there be enemy waves? time delay or after finished current wave?
        // or that will be specified elsewhere??
        // also specify # of each enemy
        // doesn't have to show up in preview menu, but information has to be passed when actually playing the stage

        Node nodeEnd = new Node(12, enemy6, NodeType.Boss);
        Node node12 = new Node(11, new Node[] { nodeEnd }, enemy3, NodeType.Normal);
        Node node11 = new Node(10, new Node[] { nodeEnd }, enemy2, NodeType.Normal);
        Node node10 = new Node(9, new Node[] { node12 }, enemy1, NodeType.Normal);
        Node node9 = new Node(8, new Node[] { node11 }, NodeType.Heal);
        Node node8 = new Node(7, new Node[] { node11 }, enemy4, NodeType.Hard);
        Node node7 = new Node(6, new Node[] { node10 }, enemy1, NodeType.Normal);
        Node node6 = new Node(5, new Node[] { node10 }, enemy5, NodeType.Hard);
        Node node5 = new Node(4, new Node[] { node9 }, enemy2 ,NodeType.Normal);
        Node node4 = new Node(3, new Node[] { node8 }, enemy1, NodeType.Hard);
        Node node3 = new Node(2, new Node[] { node6, node7 }, enemy3, NodeType.Normal);
        Node node2 = new Node(1, new Node[] { node4, node5, node6 }, enemy2, NodeType.Normal);
        Node nodeStart = new Node(0, new Node[] { node2, node3 }, enemy1,NodeType.Normal);

        nodes = new Node[] { nodeStart, node2, node3, node4, node5, node6, node7, node8, node9, node10, node11, node12, nodeEnd };
    }

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        Instantiate(entityToSpawn, new Vector2(-540, -290), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-250, -270), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-490, -50), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(0, -240), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-120, -100), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        GameObject button5 = Instantiate(entityToSpawn, new Vector2(-250, 20), Quaternion.identity, canvas.transform);
        button5.transform.localScale = new Vector2(3, 3);
        button5.GetComponent<Image>().sprite = sprites[0];
        Instantiate(entityToSpawn, new Vector2(-300, 200), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        GameObject button7 = Instantiate(entityToSpawn, new Vector2(300, -180), Quaternion.identity, canvas.transform);
        button7.transform.localScale = new Vector2(3, 3);
        button7.GetComponent<Image>().sprite = sprites[0];
        GameObject button8 = Instantiate(entityToSpawn, new Vector2(110, -20), Quaternion.identity, canvas.transform);
        button8.transform.localScale = new Vector2(3, 3);
        button8.GetComponent<Image>().sprite = sprites[2];
        Instantiate(entityToSpawn, new Vector2(0, 220), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(470, 0), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(250, 240), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        GameObject button12 = Instantiate(entityToSpawn, new Vector2(540, 290), Quaternion.identity, canvas.transform);
        button12.transform.localScale = new Vector2(3, 3);
        button12.GetComponent<Image>().sprite = sprites[1];
    }
}