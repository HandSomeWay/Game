using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(ModeController.ModeX)
        {
            this.gameObject.transform.position = new Vector3(0f, 1.25f, -1f);
            this.gameObject.transform.localEulerAngles = new Vector3(15f, 0f, 0f);

        }
        else
        {
            this.gameObject.transform.position = new Vector3(0f, 1, -1f);
            this.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
