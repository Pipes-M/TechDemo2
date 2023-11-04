using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    public string tooltipText;
    public TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = tooltipText;
        Debug.Log(tooltipText);
    }
}
