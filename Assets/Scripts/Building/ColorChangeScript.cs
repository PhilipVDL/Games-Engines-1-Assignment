using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    Light mySpot;
    Light myPoint;
    //Color purple = new Color(148, 87, 226,255);
    Color32 purple = new Color32(148, 87, 226, 255);
    

    private void Start()
    {
        mySpot = transform.GetChild(0).GetComponent<Light>();
        myPoint = transform.GetChild(1).GetComponent<Light>();
    }

    public void UpperColor(int colorID)
    {
        switch (colorID)
        {
            case 0:
                mySpot.color = Color.red;
                myPoint.color = Color.red;
                break;
            case 1:
                mySpot.color = Color.green;
                myPoint.color = Color.green;
                break;
            case 2:
                mySpot.color = Color.blue;
                myPoint.color = Color.blue;
                break;
            case 3:
                mySpot.color = Color.cyan;
                myPoint.color = Color.cyan;
                break;
            case 4:
                mySpot.color = Color.yellow;
                myPoint.color = Color.yellow;
                break;
        }
    }

    public void GroundColor()
    {
        mySpot.color = purple;
        myPoint.color = purple;
    }
}