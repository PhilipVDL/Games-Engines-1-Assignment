using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorInteraction : MonoBehaviour
{
    public GameObject uFloor;
    public bool upperSpawned;
    public GameObject falseFloorStack;
    private float floorHeight = 6.5f;
    ColorChangeScript colorChange;

    private void Start()
    {
        if(transform.parent.transform.childCount > 1)
        {
            falseFloorStack = transform.parent.transform.GetChild(1).gameObject;
        }
        colorChange = GetComponentInChildren<ColorChangeScript>();
    }

    private void Update()
    {
        ColorChangeGround();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!upperSpawned)
        {
            SpawnUpper();
        }
    }

    public void SpawnUpper()
    {
        //upper floor
        falseFloorStack.SetActive(false); //disable false floors
        Vector3 upperPos = new Vector3(transform.position.x, transform.position.y + floorHeight, transform.position.z); //pos for upper

        Vector3 baseRot = transform.rotation.eulerAngles;
        Vector3 halfRot = new Vector3(baseRot.x, baseRot.y + 180, baseRot.z);
        Quaternion halfQuat = Quaternion.Euler(halfRot);
        GameObject newUpper = Instantiate(uFloor, upperPos, halfQuat);
        newUpper.transform.SetParent(transform.parent);

        //upper's roof
        Vector3 upperRoofPos = new Vector3(transform.position.x, transform.position.y + (2 * floorHeight), transform.position.z);
        Vector3 upperRoofRot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Quaternion upperRoofQuat = Quaternion.Euler(upperRoofRot);
        GameObject newRoof = Instantiate(uFloor, upperRoofPos, upperRoofQuat);
        newRoof.transform.SetParent(newUpper.transform);
        upperSpawned = true;
    }

    public void DespawnUpper()
    {
        if(transform.parent.transform.childCount > 2)
        {
            Destroy(transform.parent.transform.GetChild(2).gameObject);
            falseFloorStack.SetActive(true);
            upperSpawned = false;
        }
        else if(transform.parent.transform.childCount > 1)
        {
            if(falseFloorStack == null)
            {
                falseFloorStack = transform.parent.transform.GetChild(1).gameObject;
            }
            if(falseFloorStack != null)
            {
                falseFloorStack.SetActive(true);
            }
            upperSpawned = false;
        }
    }

    public void ColorChangeGround()
    {
        colorChange.GroundColor();
    }
}