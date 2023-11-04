using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class kayPad : MonoBehaviour
{
    public string inputedCode;
    public string endCode = "1234";
    public bool codeCorrect;
    [HideInInspector] public GameObject player;
    private PlayerController playerScript;
    public GameObject camLocObj;
    private Vector3 camOrigPos;
    private Quaternion camOrigRot;
    public GameObject keyexitCanvas;
    public TextMeshPro codeScreen;
    public Material normCol;
    public Material correctCol;
    public Material incorrectCol;
    public GameObject LED;
    private bool canInput = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        LED.GetComponent<Renderer>().material = normCol;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<interactScript>().isInteracted)
        {
            codePlayerLock(true);
        }
        if (inputedCode.Length == 0)
        {
            codeScreen.text = "____";
        }
        else
        {
            codeScreen.text = inputedCode;
        }

    }

    public void codePlayerLock(bool locked)
    {
        gameObject.GetComponent<BoxCollider>().enabled = !locked;
        playerScript.canMove = !locked;
        keyexitCanvas.SetActive(locked);
        if (locked)
        {
            camOrigPos = playerScript.playerCamera.transform.position;
            camOrigRot = playerScript.playerCamera.transform.rotation;
            playerScript.playerCamera.transform.position = camLocObj.transform.position;
            playerScript.playerCamera.transform.rotation = camLocObj.transform.rotation;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            UnityEngine.Cursor.visible = true;
            playerScript.mouseRay = true;
        }
        else
        {
            playerScript.playerCamera.transform.position = camOrigPos;
            playerScript.playerCamera.transform.rotation = camOrigRot;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
            playerScript.mouseRay = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }


    public void inputCode(string inpNumber)
    {
        if (canInput)
        {
            if (inpNumber == "b")
            {
                inputedCode = inputedCode.Substring(0, inputedCode.Length - 1);
            }
            else if (inpNumber == "c")
            {
                inputedCode = inputedCode.Substring(0, inputedCode.Length - inputedCode.Length);
            }
            else if (inpNumber == "e" && inputedCode == endCode)
            {
                Debug.Log("correct password!!!");
                codeCorrect = true;
                LED.GetComponent<Renderer>().material = correctCol;
            }
            else if (inpNumber == "e" && inputedCode != endCode)
            {
                Debug.Log("INcorrect password!!!");
                StartCoroutine(delayIncorCol());
            }
            else if (inputedCode.Length < 4 && inpNumber != "e")
            {
                inputedCode += inpNumber;
            }
            Debug.Log(inputedCode);
        }
        
    }

    IEnumerator delayIncorCol()
    {
        LED.GetComponent<Renderer>().material = incorrectCol;
        canInput = false;
        yield return new WaitForSeconds(3);
        LED.GetComponent<Renderer>().material = normCol;
        canInput = true;
        inputCode("c");
    }
}
