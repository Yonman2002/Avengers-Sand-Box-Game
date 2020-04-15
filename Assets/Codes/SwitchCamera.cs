using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera[] cameras;
    private int curCamera = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SwitchCam"))
        {
            cameras[curCamera].gameObject.SetActive(false);
            curCamera = (curCamera + 1) % 3;
            cameras[curCamera].gameObject.SetActive(true);
        }
    }
}
