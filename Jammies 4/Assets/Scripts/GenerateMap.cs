using UnityEngine;
public class GenerateMap : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public GameObject canvas;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject node1 = Instantiate(myPrefab, new Vector3(50, 50, 0), Quaternion.identity, canvas.transform);
        node1.name = "node1";
        GameObject node2 = Instantiate(myPrefab, new Vector3(100, 50, 0), Quaternion.identity, canvas.transform);
        node2.name = "node2";
        GameObject node3 = Instantiate(myPrefab, new Vector3(150, 50, 0), Quaternion.identity, canvas.transform);
        node3.name = "node3";
    }
}