using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light lightMain;
    private bool lightOn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lightTimer());
    }

    // Update is called once per frame
    void Update()
    {
        //lightMain.enabled = lightOn;
    }

    IEnumerator lightTimer()
    {
        lightMain.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.2f, 3f));
        lightMain.enabled = false;
        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        StartCoroutine(lightTimer());
    }
    
}
