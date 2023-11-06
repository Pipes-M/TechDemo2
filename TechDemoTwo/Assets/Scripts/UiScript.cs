using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    public string tooltipText;
    public string subtitleText;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI subTitle;
    public GameObject viewpage;
    public TextMeshProUGUI docReadBetter;
    public string docWords;
    public RawImage rawimgTexture;
    [HideInInspector] public GameObject player;
    [HideInInspector] public PlayerController playerScript;
    public GameObject invScreen;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = tooltipText;
        subTitle.text = subtitleText;
        //Debug.Log(tooltipText);
    }

    public void viewPage()
    {
        viewpage.SetActive(true);
        playerScript.canMove = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }

    public void textReadPage()
    {
        docReadBetter.text = docWords;
        
    }

    public void exitPage()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        playerScript.canMove = true;
        viewpage.SetActive(false);
    }

    public void invOpen(bool active)
    {
        invScreen.SetActive(active);
    }
}
