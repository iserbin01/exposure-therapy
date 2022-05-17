using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class userSetup : MonoBehaviour
{
    private int id = 0;
    private int session = 0;
    private SessionManager manager;
    FadeScreen fade;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        fade = GameObject.Find("Overlay").GetComponent<FadeScreen>();
        StartCoroutine(fade.FadeIn());
        yield return new WaitUntil(() => fade.faded == true);

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
                    if(id > 0 && session > 0){
                        manager = GameObject.Find("SessionInfo").GetComponent<SessionManager>();
                        manager.id = id;
                        manager.session = session;
                        manager.nextScene = "ElevatorScene";
                        StartCoroutine(FadeAndLoad("RoomScene"));
                    };
                    break;
                case "ElevatorBtn":
                    if(id > 0 && session > 0){
                        manager = GameObject.Find("SessionInfo").GetComponent<SessionManager>();
                        manager.id = id;
                        manager.session = session;
                        manager.nextScene = "RoomScene";
                        StartCoroutine(FadeAndLoad("ElevatorScene"));
                    }
                    break;
                default : break;


                }
            }
        }
    }
    IEnumerator FadeAndLoad(string sceneName){
        print("Fading");
        StartCoroutine(fade.FadeOut());
        yield return new WaitUntil(() => fade.faded == true);
        SceneManager.LoadScene(sceneName);
    }
}

