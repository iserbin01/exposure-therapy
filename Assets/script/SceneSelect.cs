using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown("1")){
            SceneManager.LoadScene("ElevatorScene");
        }
        if (Input.GetKeyDown("2")){
            SceneManager.LoadScene("RoomScene");
        }
    }

    
}
