using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    private bool on;
    
    // Start is called before the first frame update
    void Start()
    {
        on = this.transform.parent.gameObject.GetComponent<MeshRenderer>().enabled;
        this.enabled = on;
    
    }

    // Update is called once per frame
    void Update()
    {
        print("light is "+on);
        on = this.transform.parent.gameObject.GetComponent<MeshRenderer>().enabled;
        this.enabled = on;
    }
}
