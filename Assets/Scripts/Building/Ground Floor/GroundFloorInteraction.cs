using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorInteraction : MonoBehaviour
{
    public GameObject uFloor;
    public bool inside;
    public bool upperSpawned;
    public GameObject falseFloorStack;
    private float floorHeight = 6.5f;

    private void Start()
    {
        falseFloorStack = transform.parent.transform.GetChild(1).gameObject;
    }

    //when not inside, but not in upper
    //destroy upper floor
    //enable false floors

    private void OnTriggerEnter(Collider other)
    {
        if (!upperSpawned)
        {
            SpawnUpper();
        }
    }

    void SpawnUpper()
    {
        //upper floor
        falseFloorStack.SetActive(false); //disable false floors
        Vector3 upperPos = new Vector3(transform.position.x, transform.position.y + floorHeight, transform.position.z); //pos for upper
        Vector3 upperRot = new Vector3(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z); //rot for upper
        Quaternion upperQuat = Quaternion.Euler(upperRot); //convert to Quaternion
        GameObject newUpper = Instantiate(uFloor, upperPos, upperQuat);
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
    }
}