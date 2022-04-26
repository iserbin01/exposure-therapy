using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampControl : MonoBehaviour
{
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LampTasks());
    }

      IEnumerator LampTasks()
    {
        Debug.Log("Starting session");
        for(int i = 0; i < 10; i++){
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
            StartCoroutine(Task());
        }
        
    }
      IEnumerator Task()
    {
        float startTime;
        float endTime;
        Debug.Log("Lmap is on");
        GameObject.Find("lamp_on").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("lamp_off").GetComponent<MeshRenderer>().enabled = false;
        startTime = Time.time;
        yield return new WaitUntil(() => Input.GetKeyDown("l"));
        endTime = Time.time;
        GameObject.Find("lamp_off").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("lamp_on").GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("Lamp is off");
        Debug.Log("task took " +(endTime-startTime) +" seconds.");
    }
}
