using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityscapeSpawn : MonoBehaviour
{
    public GameObject street, gFloor, fFloor;
    GameObject[] floors;
    public int falseFloors;
    public bool spawned;

    private void Awake()
    {
        spawned = false;
        floors = new GameObject[falseFloors];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !spawned)
        {
            //spawn street
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 50);
            GameObject newStreet = Instantiate(street, pos, transform.rotation);
            //spawn ground floor
            Vector3 streetPos = new Vector3(newStreet.transform.position.x, newStreet.transform.position.y, newStreet.transform.position.z);
            GameObject groundFloor = Instantiate(gFloor, streetPos, newStreet.transform.rotation);
            groundFloor.transform.SetParent(newStreet.transform);
            //spawn false floors
            for(int i = 0; i < falseFloors -1; i++)
            {
                Vector3 nextLevel = new Vector3(streetPos.x, streetPos.y + (6.5f * (i + 1)) + (6.5f/2), streetPos.z);
                GameObject nextFloor = Instantiate(fFloor, nextLevel, newStreet.transform.rotation);
                floors[i] = nextFloor;
                if(i == 0)
                {
                    nextFloor.transform.SetParent(newStreet.transform);
                }
                else
                {
                    nextFloor.transform.SetParent(floors[i - 1].transform);
                }
            }
            spawned = true;
        }
    }
}
