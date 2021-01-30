using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Adjust_Canvas_Height : MonoBehaviour
{
    private float resoX;
    private float resoY;

    private CanvasScaler canvas_scaler;

    private void Start()
    {
        canvas_scaler = GetComponent<CanvasScaler>();
        resoX = (float)Screen.currentResolution.width;
        resoY = (float)Screen.currentResolution.height;

        canvas_scaler.referenceResolution = new Vector2(resoX, resoY);

    }
}

