using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public int session, id;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<SessionManager>().Length != 1)
     {
         Destroy(this.gameObject);
     }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update(){
    }
}
