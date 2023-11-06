using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invScript : MonoBehaviour
{
    [HideInInspector] public GameObject mainCanvas;
    [HideInInspector] public HUDscript hudScript;
    private bool openInv;

    // Start is called before the first frame update
    void Start()
    {
        mainCanvas = GameObject.Find("Canvas");
        hudScript = mainCanvas.GetComponent<HUDscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            openInv = !openInv;
            hudScript.invOpen(openInv);
        }
    }
}
