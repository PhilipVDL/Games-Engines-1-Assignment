using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    Light myLight;
    //Color purple = new Color(148, 87, 226,255);
    Color32 purple = new Color32(148, 87, 226, 255);
    

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    public void UpperColor(int colorID)
    {
        switch (colorID)
        {
            case 0:
                myLight.color = Color.red;
                break;
            case 1:
                myLight.color = Color.green;
                break;
            case 2:
                myLight.color = Color.blue;
                break;
            case 3:
                myLight.color = Color.cyan;
                break;
            case 4:
                myLight.color = Color.yellow;
                break;
            default:
                myLight.color = Color.blue;
                break;
        }
    }

    public void GroundColor()
    {
        myLight.color = purple;
    }
}