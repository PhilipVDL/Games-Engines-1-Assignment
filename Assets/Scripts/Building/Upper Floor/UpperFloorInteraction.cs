using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperFloorInteraction : MonoBehaviour
{
    public GameObject street, gFloor, uFloor, fFloor;
    public bool spawned;
    private float floorHeight = 6.5f;
    private float floorDistance = 20;

    ColorChangeScript colorChange;

    //compass
    public int compass;
    #region directions
    //0 = up
    //1 = north
    //2 = east
    //3 = south
    //4 = west
    #endregion

    //variables
    public int falseFloors;

    private void Start()
    {
        street = GameObject.Find("Reference Street");
        uFloor = GameObject.Find("Reference Upper Floor");
        colorChange = GameObject.FindGameObjectWithTag("Player").GetComponent<ColorChangeScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawned)
        {
            spawned = true;
            WipeWorld();
            SpawnRooms();
            ColorChangeUpper();
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
        //this
        Vector3 baseRot = transform.rotation.eulerAngles;
        Vector3 halfRot = new Vector3(baseRot.x, baseRot.y + 180, baseRot.z);
        Quaternion halfQuat = Quaternion.Euler(halfRot);

        //above
        Vector3 abovePos = new Vector3(transform.position.x, transform.position.y + floorHeight, transform.position.z);
        GameObject aboveRoom = Instantiate(uFloor, abovePos, halfQuat);
        aboveRoom.name = "Upper Floor";
        aboveRoom.transform.SetParent(transform);
        aboveRoom.GetComponent<UpperFloorInteraction>().compass = 0;

        //ceiling of above
        Vector3 ceilingPos = new Vector3(transform.position.x, transform.position.y + (floorHeight * 2), transform.position.z);
        GameObject ceiling = Instantiate(uFloor, ceilingPos, transform.rotation);
        ceiling.name = "Upper Floor";
        ceiling.transform.SetParent(aboveRoom.transform);

        //below
        Vector3 belowPos = new Vector3(transform.position.x, transform.position.y - floorHeight, transform.position.z);
        GameObject belowRoom = Instantiate(gFloor, belowPos, halfQuat);
        belowRoom.name = "Ground Floor";
        transform.SetParent(belowRoom.transform);
        belowRoom.GetComponent<GroundFloorInteraction>().upperSpawned = true;

        //street
        Vector3 streetPos = new Vector3(transform.position.x, transform.position.y - floorHeight - 0.01f, transform.position.z);
        GameObject newStreet = Instantiate(street, streetPos, Quaternion.identity);
        newStreet.name = "street";
        belowRoom.transform.SetParent(newStreet.transform);

        //north/south
        for (int i = 0; i < 2; i++)
        {
            int sign;
            int rot;
            int compVal;

            if (i > 0)
            {
                sign = -1;
                rot = 180;
                compVal = 1;
            }
            else
            {
                sign = 1;
                rot = 0;
                compVal = 3;
            }

            Vector3 nsPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (floorDistance * sign));
            Vector3 nsRot = new Vector3(0, rot, 0);
            Quaternion nsQuat = Quaternion.Euler(nsRot);
            GameObject nsRoom = Instantiate(uFloor, nsPos, nsQuat);
            nsRoom.name = "Upper Floor";
            nsRoom.transform.SetParent(transform);
            nsRoom.GetComponent<UpperFloorInteraction>().compass = compVal;
        }

        //east/west
        for (int k = 0;k< 2; k++)
        {
            int sign;
            int rot;
            int compVal;

            if (k > 0)
            {
                sign = -1;
                rot = -90;
                compVal = 2;
            }
            else
            {
                sign = 1;
                rot = 90;
                compVal = 4;
            }

            Vector3 ewPos = new Vector3(transform.position.x + (floorDistance * sign), transform.position.y, transform.position.z);
            Vector3 ewRot = new Vector3(0, rot, 0);
            Quaternion ewQuat = Quaternion.Euler(ewRot);
            GameObject ewRoom = Instantiate(uFloor, ewPos, ewQuat);
            ewRoom.name = "Upper Floor";
            ewRoom.transform.SetParent(transform);
            ewRoom.GetComponent<UpperFloorInteraction>().compass = compVal;
        }

    }

    void ColorChangeUpper()
    {
        colorChange.UpperColor(compass);
    }
}