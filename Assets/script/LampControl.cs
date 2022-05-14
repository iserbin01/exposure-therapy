using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LampControl : MonoBehaviour
{
    private bool pressed;
    string filePath;
    string results;
    StreamWriter writer;
    FileStream stream;
    FileInfo file;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LampTasks());
    }

      IEnumerator LampTasks()
    {
        filePath = getPath();
        file = new FileInfo(filePath);
        // stream = file.Open(FileMode.Append)
        // writer = new StreamWriter(filePath);
        if(!file.Exists){
            writer= file.CreateText();
            writer.WriteLine("Date,Task1,Task2,Task3,Task4,Task5,Task6,Task7,Task8,Task9,Task10");
        } else {
            writer = file.AppendText();
        }
        
        results = System.DateTime.Now.ToString("dd-MM-yy   hh:mm:ss");
        Debug.Log("Starting session");
        for(int i = 0; i < 10; i++){
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
            StartCoroutine(Task());
        }
        yield return new WaitForSeconds(2.0f);
        writer.WriteLine(results);
        writer.Flush();
        writer.Close();
        
    }
      IEnumerator Task()
    {
        float startTime;
        float endTime;
        Debug.Log("Lamp is on");
        GameObject.Find("lamp_on").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("lamp_off").GetComponent<MeshRenderer>().enabled = false;
        startTime = Time.time;
        yield return new WaitUntil(() => Input.GetKeyDown("l"));
        endTime = Time.time;
        GameObject.Find("lamp_off").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("lamp_on").GetComponent<MeshRenderer>().enabled = false;
        results += ","+(endTime-startTime);
        Debug.Log("Lamp is off");
        Debug.Log("task took " +(endTime-startTime) +" seconds.");
    }
     private string getPath()
    {
        #if UNITY_EDITOR
                return Application.dataPath + "/Data/"  + "results.csv";
                //"Participant " + "   " + DateTime.Now.ToString("dd-MM-yy   hh-mm-ss") + ".csv";
        #elif UNITY_ANDROID
                return Application.persistentDataPath+"results.csv";
        #elif UNITY_IPHONE
                return Application.persistentDataPath+"/"+"results.csv";
        #else
                return Application.dataPath +"/"+"results.csv";
        #endif
    }
}
