using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class CityscapeSpawn : MonoBehaviour
{
    public GameObject street, gFloor, fFloor;
    GameObject[] floors;
    public int falseFloors;
    public bool spawned;

    //variables
    float gridDistance = 50;
    float falseFloorHeight = 6.5f;
    int gridRange = 1;

    private void Awake()
    {
        spawned = false;
        floors = new GameObject[falseFloors];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !spawned)
        {
            CleanSlate();
            SpawnCityscape();
            spawned = true;
        }
    }

    void CleanSlate()
    {
        gameObject.tag = "Untagged";
        GameObject[] streets = GameObject.FindGameObjectsWithTag("Street");
        foreach(GameObject go in streets)
        {
            Destroy(go);
        }
        gameObject.tag = "Street";
    }

    void SpawnCityscape()
    {
        for (int xPos = -gridRange; xPos <= gridRange; xPos++)
        {
            for (int zPos = -gridRange; zPos <= gridRange; zPos++)
            {
                if (xPos == 0 && zPos == 0)
                {
                    //do nothing
                }
                else
                {
                    SpawnStreet(xPos, zPos);
                }
            }
        }
    }

    void SpawnStreet(int x, int z)
    {
        //street
        Vector3 pos = new Vector3(transform.position.x + (x * gridDistance), transform.position.y, transform.position.z + (z * gridDistance));
        GameObject newStreet = Instantiate(street, pos, transform.rotation);
        newStreet.name = "street";
        //ground floor
        Vector3 streetPos = new Vector3(newStreet.transform.position.x, newStreet.transform.position.y + 0.01f, newStreet.transform.position.z);
        GameObject groundFloor = Instantiate(gFloor, streetPos, newStreet.transform.rotation);
        groundFloor.name = "ground floor";
        groundFloor.transform.SetParent(newStreet.transform);
        //false floors
        for (int i = 0; i < falseFloors - 1; i++)
        {
            Vector3 nextLevel = new Vector3(streetPos.x, streetPos.y + (falseFloorHeight * (i + 1)) + (falseFloorHeight / 2), streetPos.z);
            GameObject nextFloor = Instantiate(fFloor, nextLevel, newStreet.transform.rotation);
            nextFloor.name = "false floor";
            floors[i] = nextFloor;
            if (i == 0)
            {
                nextFloor.transform.SetParent(newStreet.transform);
            }
            else
            {
                nextFloor.transform.SetParent(floors[i - 1].transform);
            }
        }
    }
}