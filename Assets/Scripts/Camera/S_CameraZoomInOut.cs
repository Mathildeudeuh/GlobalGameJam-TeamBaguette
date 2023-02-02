using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraZoomInOut : MonoBehaviour
{
    public bool shouldZoomIn = false;
    public bool shouldZoomOut = false;

    void UpOnTriggerEnter2D(Collider col)
    {
        if (col.gameObject.tag == "ZoomInTrigger")
            shouldZoomIn = true;

        else if (col.gameObject.tag == "ZoomOutTrigger")
            shouldZoomOut = true;
    }

    void ZoomIn()
    {

    }
    void ZoomOut()
    {

    }

    void Update ()
    {
        if (shouldZoomIn)
            ZoomIn();

        else if (shouldZoomOut)
            ZoomOut();

    }
}
