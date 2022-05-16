using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class userSetup : MonoBehaviour
{
    public int id = 0;
    public int session = 0;
    void Start()
    {
    }
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("joystick button 0") ||Input.GetKeyDown("h")){
            
            print("Ray casted");
            RaycastHit result;
            if (Physics.Raycast(this.gameObject.transform.position,this.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+ result.collider.gameObject.name);

                switch(result.collider.gameObject.name){
                case "IdUp":
                    if(id < 99){
                        id++;
                        GameObject.Find("IdLabel").GetComponent<TextMeshPro>().text = "User ID:" + id;
                    }
                    break;
                case "IdDown":
                    if(id > 0){
                        id--;
                        GameObject.Find("IdLabel").GetComponent<TextMeshPro>().text = "User ID:" + id;
                    }
                    break;
                    
                case "SessionUp":
                    if(session < 99){
                        session++;
                        GameObject.Find("SessionLabel").GetComponent<TextMeshPro>().text = "Session:" + session;
                    }
                    break;
                case "SessionDown":
                    if(session > 0){
                        session--;
                        GameObject.Find("SessionLabel").GetComponent<TextMeshPro>().text = "Session:" + session;
                    }
                    break;
                case "RoomBtn":
                    GameObject.Find("SessionInfo").GetComponent<SessionManager>().id = id;
                    GameObject.Find("SessionInfo").GetComponent<SessionManager>().session = session;
                    StartCoroutine(FadeAndLoad("RoomScene"));
                    break;
                case "ElevatorBtn":
                    GameObject.Find("SessionInfo").GetComponent<SessionManager>().id = id;
                    GameObject.Find("SessionInfo").GetComponent<SessionManager>().session = session;
                    StartCoroutine(FadeAndLoad("ElevatorScene"));
                    break;
                default : break;


                }
            }
        }
    }
    IEnumerator FadeAndLoad(string sceneName){
        print("Fading");
        FadeScreen fade = GameObject.Find("Overlay").GetComponent<FadeScreen>();
        StartCoroutine(fade.FadeOut());
        yield return new WaitUntil(() => fade.faded == true);
        print(fade.faded);
        SceneManager.LoadScene(sceneName);
    }
}

