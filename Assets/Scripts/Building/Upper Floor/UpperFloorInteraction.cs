using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperFloorInteraction : MonoBehaviour
{
    public GameObject street, gFloor, uFloor, fFloor;
    public bool spawned;
    public bool reverse;
    private float floorHeight = 6.5f;
    private float floorDistance = 20;

    //variables
    public int falseFloors;
    float falseFloorHeight = 6.5f;
    GameObject[] floors;
    GameObject firstFloor;

    private void Start()
    {
        street = GameObject.Find("Reference Street");
        uFloor = GameObject.Find("Reference Upper Floor");
        floors = new GameObject[falseFloors];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawned)
        {
            spawned = true;
            WipeWorld();
            SpawnRooms();
        }
    }

    void WipeWorld()
    {
        transform.SetParent(null); //unparents this room
        gameObject.tag = "Untagged";

        GameObject[] streets = GameObject.FindGameObjectsWithTag("Street");
        foreach (GameObject go in streets)
        {
            if (go.name == "Reference Street")
            {
                //do nothing
            }
            else
            {
                Destroy(go); //destroys all streets except the reference
            }
        }

        GameObject[] uppers = GameObject.FindGameObjectsWithTag("uFloor");
        foreach(GameObject go in uppers)
        {
            if(go.name == "Reference Upper Floor")
            {
                //do nothing
            }
            else
            {
                Destroy(go); //destroys all uppers except this and the reference
            }
        }

        gameObject.tag = "uFloor";
    }

    void SpawnRooms()
    {
        //above
        Vector3 abovePos = new Vector3(transform.position.x, transform.position.y + floorHeight, transform.position.z);
        Vector3 aboveRot;
        if (!reverse)
        {
            aboveRot = new Vector3(0, 0, 0);
        }
        else
        {
            aboveRot = new Vector3(0, 180, 0);
        }
        
        Quaternion aboveQuat = Quaternion.Euler(aboveRot);
        GameObject aboveRoom = Instantiate(uFloor, abovePos, aboveQuat);
        aboveRoom.name = "Upper Floor";
        aboveRoom.transform.SetParent(transform);
        if (!reverse)
        {
            aboveRoom.GetComponent<UpperFloorInteraction>().reverse = true;
        }

        //below
        Vector3 belowPos = new Vector3(transform.position.x, transform.position.y - floorHeight, transform.position.z);
        Vector3 belowRot;
        if (!reverse)
        {
            belowRot = new Vector3(0, 0, 0);
        }
        else
        {
            belowRot = new Vector3(0, 180, 0);
        }

        Quaternion belowQuat = Quaternion.Euler(belowRot);
        GameObject belowRoom = Instantiate(gFloor, belowPos, belowQuat);
        belowRoom.name = "Ground Floor";
        transform.SetParent(belowRoom.transform);

        //street
        Vector3 streetPos = new Vector3(transform.position.x, transform.position.y - floorHeight - 0.01f, transform.position.z);
        GameObject newStreet = Instantiate(street, streetPos, Quaternion.identity);
        newStreet.name = "street";
        belowRoom.transform.SetParent(newStreet.transform);

        /*
        //false for below
        for (int j = 0; j < falseFloors - 1; j++)
        {
            Vector3 nextLevel = new Vector3(streetPos.x, streetPos.y + (falseFloorHeight * (j + 1)) + (falseFloorHeight / 2), streetPos.z);
            GameObject nextFloor = Instantiate(fFloor, nextLevel, newStreet.transform.rotation);
            nextFloor.name = "false floor";
            floors[j] = nextFloor;
            if (j == 0)
            {
                nextFloor.transform.SetParent(newStreet.transform);
                firstFloor = nextFloor;
            }
            else
            {
                nextFloor.transform.SetParent(floors[j - 1].transform); //stacks self as child chain
            }
        }
        firstFloor.SetActive(false);
        */
        

        //north/south
        for (int i = 0; i < 2; i++)
        {
            int sign;
            int rot;

            if (i > 0)
            {
                sign = -1;
                rot = 180;
            }
            else
            {
                sign = 1;
                rot = 0;
            }

            Vector3 nsPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (floorDistance * sign));
            Vector3 nsRot = new Vector3(0, rot, 0);
            Quaternion nsQuat = Quaternion.Euler(nsRot);
            GameObject nsRoom = Instantiate(uFloor, nsPos, nsQuat);
            nsRoom.name = "Upper Floor";
            nsRoom.transform.SetParent(transform);
        }

        //east/west
        for (int k = 0;k< 2; k++)
        {
            int sign;
            int rot;

            if (k > 0)
            {
                sign = -1;
                rot = -90;
            }
            else
            {
                sign = 1;
                rot = 90;
            }

            Vector3 ewPos = new Vector3(transform.position.x + (floorDistance * sign), transform.position.y, transform.position.z);
            Vector3 ewRot = new Vector3(0, rot, 0);
            Quaternion ewQuat = Quaternion.Euler(ewRot);
            GameObject ewRoom = Instantiate(uFloor, ewPos, ewQuat);
            ewRoom.name = "Upper Floor";
            ewRoom.transform.SetParent(transform);
        }

    }
}