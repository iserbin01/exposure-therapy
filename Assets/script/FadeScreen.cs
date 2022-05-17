using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    private float opacity = 0;
    private float FULL_OPACITY = 1;
    private Image image;
    public bool faded = false;

    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame

    public IEnumerator FadeOut(){
        while (opacity < FULL_OPACITY){
            opacity+= (FULL_OPACITY*.05F);
            image.color = new Color(0,0, 0, opacity);
            yield return new WaitForSeconds(.05F);
        }
        faded = true;
    }
    public IEnumerator FadeIn(){
        while (opacity > 0){
            opacity-= (FULL_OPACITY*.05F);
            image.color = new Color(0,0, 0, opacity);
            yield return new WaitForSeconds(.05F);
        }
        faded = false;
    }
}
