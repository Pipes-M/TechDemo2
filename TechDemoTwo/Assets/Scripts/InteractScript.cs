using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class interactScript : MonoBehaviour
{

    public bool isLookedAt;
    [HideInInspector] public GameObject player;
    [HideInInspector] public PlayerController playerScript;
    [HideInInspector] public GameObject playerseenobject;
    public string keyNumb;
    [HideInInspector] public kayPad mainKeyPad;
    public bool isInteracted;
    public int tooltipType = 1;
    [HideInInspector] public GameObject mainCanvas;
    [HideInInspector] public HUDscript hudScript;
    private string starttoolTipT;
    private bool doOnce;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        playerseenobject = playerScript.seenObject;
        mainKeyPad = GameObject.Find("MainPad").GetComponent<kayPad>();
        mainCanvas = GameObject.Find("Canvas");
        hudScript = mainCanvas.GetComponent<HUDscript>();
        if (tooltipType == 2)
        {
            starttoolTipT = "Pick up";
        }
        else
        {
            starttoolTipT = "Interact";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.seenObject == gameObject)
        {
            GetComponent<Outline>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && keyNumb == "")
            {
                isInteracted = true;
                
            }
            if (Input.GetMouseButtonDown(0) && keyNumb != "")
            {
                mainKeyPad.inputCode(keyNumb);
                isInteracted = true;
                
            }
            hudScript.textMesh.enabled = true;
            hudScript.tooltipText = starttoolTipT;
            doOnce = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
            isInteracted = false;
            if (doOnce)
            {
                hudScript.textMesh.enabled = false;
                doOnce = false;
            }
            
        }
        //Debug.Log(playerScript.seenObject);
        //GetComponent<Outline>().enabled = isLookedAt;
        //if (isLookedAt && Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log(gameObject.name + " interacted");
        //}

    }


    public void LookedAt()
    {
        Debug.Log(gameObject.name + " interacted");
    }
}
