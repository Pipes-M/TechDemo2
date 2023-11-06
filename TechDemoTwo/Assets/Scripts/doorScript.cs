using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public GameObject keypad;
    [HideInInspector] public kayPad keyPadScript;
    private Vector3 initialPosition;
    public Vector3 endPosition;
    private bool isMoving = true;
    private float startTime;
    public float moveDuration = 2.0f;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
        keyPadScript = keypad.GetComponent<kayPad>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyPadScript.codeCorrect && isMoving)
        {
            elapsedTime = Time.deltaTime + elapsedTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            Debug.Log(elapsedTime);
            
            transform.position = Vector3.Lerp(initialPosition, endPosition, t);

            if (t >= 1.0f)
            {
                isMoving = false;
            }
        }
    }
}
