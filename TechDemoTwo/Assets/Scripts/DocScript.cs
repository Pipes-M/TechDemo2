
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class DocScript : MonoBehaviour
{
    public Texture docimage;
    [HideInInspector] public GameObject mainCanvas;
    [HideInInspector] public HUDscript hudScript;
    private bool doOnce = true;
    public string documentWords;

    // Start is called before the first frame update
    void Start()
    {
        mainCanvas = GameObject.Find("Canvas");
        hudScript = mainCanvas.GetComponent<HUDscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<interactScript>().isInteracted == true && doOnce)
        {
            hudScript.viewPage();
            hudScript.docWords = documentWords;
            hudScript.rawimgTexture.texture = docimage;
            Debug.Log(documentWords);
            GetComponent<interactScript>().isInteracted = false;
        }
    }
}
