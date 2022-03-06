using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    // The GameObject to instantiate.
    public GameObject entityToSpawn;
    public GameObject canvas;

    public static Node[] nodes;

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        
        // random placeholder enemies (generic & special)
        Enemy enemy1 = new Enemy("e1", 1, 1);
        Enemy enemy2 = new Enemy("e2", 2, 3);
        Enemy enemy3 = new Enemy("e3", 5, 2);
        Enemy enemyMobile = new Enemy("mobile", 3, 2);
        Enemy enemyStrong = new Enemy("strong", 8, 10);
        Enemy enemySpread = new Enemy("spread", 5, 6);
        Enemy boss = new Enemy("boss", 30, 300);

        // random placeholder sets of enemies
        Enemy[] enemies1 = { enemy1, enemy2 };
        Enemy[] enemies2 = { enemy3, enemy1 };
        Enemy[] enemies3 = { enemy1, enemy2, enemy3 };
        Enemy[] stageHard1 = { enemy2, enemyMobile };
        Enemy[] stageHard2 = { enemy3, enemy1, enemySpread };
        Enemy[] stageHard3 = { enemy1, enemyStrong };
        Enemy[] stageBoss = { enemy1, enemy2, enemy3, enemyMobile, enemyStrong, enemySpread, boss };

        // somehow specify how enemy waves will appear? will there be enemy waves? time delay or after finished current wave?
        // or that will be specified elsewhere??
        // also specify # of each enemy
        // doesn't have to show up in preview menu, but information has to be passed when actually playing the stage

        Node nodeEnd = new Node(13, stageBoss, NodeType.Boss);
        Node node12 = new Node(12, new Node[] { nodeEnd }, enemies3, NodeType.Normal);
        Node node11 = new Node(11, new Node[] { nodeEnd }, enemies2, NodeType.Normal);
        Node node10 = new Node(10, new Node[] { node12 }, enemies2, NodeType.Normal);
        Node node9 = new Node(9, new Node[] { node11 }, NodeType.Heal);
        Node node8 = new Node(8, new Node[] { node11 }, stageHard2, NodeType.Hard);
        Node node7 = new Node(7, new Node[] { node10 }, enemies3, NodeType.Normal);
        Node node6 = new Node(6, new Node[] { node10 }, stageHard1, NodeType.Hard);
        Node node5 = new Node(5, new Node[] { node9 }, NodeType.Heal);
        Node node4 = new Node(4, new Node[] { node8 }, stageHard3, NodeType.Hard);
        Node node3 = new Node(3, new Node[] { node6, node7 }, enemies1, NodeType.Normal);
        Node node2 = new Node(2, new Node[] { node4, node5, node6 }, enemies2, NodeType.Normal);
        Node nodeStart = new Node(1, new Node[] { node2, node3 }, NodeType.Heal);



        nodes = new Node[] { nodeStart, node2, node3, node4, node5, node6, node7, node8, node9, node10, node11, node12, nodeEnd };

        Instantiate(entityToSpawn, new Vector2(-540, -290), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-250, -270), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-490, -50), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(0, -240), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-120, -100), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-250, 20), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(-300, 200), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(300, -180), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(110, -20), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(0, 220), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(470, 0), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(250, 240), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
        Instantiate(entityToSpawn, new Vector2(540, 290), Quaternion.identity, canvas.transform).transform.localScale = new Vector2(3, 3);
    }
}