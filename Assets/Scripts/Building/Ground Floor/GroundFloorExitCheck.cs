using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorExitCheck : MonoBehaviour
{
    GroundFloorInteraction gScript;

    private void Start()
    {
        gScript = GetComponentInParent<GroundFloorInteraction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gScript.DespawnUpper();
    }
}