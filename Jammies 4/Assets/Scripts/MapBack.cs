using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapBack : MonoBehaviour
{
    public void BackGame(){
        SceneManager.LoadScene("Menu");
    }
}
