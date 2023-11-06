using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleScript : MonoBehaviour
{

    private bool doOnce = true;
    [HideInInspector] public GameObject mainCanvas;
    [HideInInspector] public HUDscript hudScript;
    public string subText;
    private int charPos;
    public float perCharDelay = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && doOnce)
        {
            StartCoroutine(subChar());
            doOnce = false;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas");
        hudScript = mainCanvas.GetComponent<HUDscript>();


    }



    IEnumerator subChar()
    {
        hudScript.subtitleText += subText[charPos];
        charPos += 1;
        if (charPos < subText.Length)
        {
            yield return new WaitForSeconds(perCharDelay);
            StartCoroutine(subChar());
        }
        else
        {
            yield return new WaitForSeconds(2);
            hudScript.subtitleText = "";
        }
    }
}
