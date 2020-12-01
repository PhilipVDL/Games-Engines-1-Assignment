using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    private Transform[] decoSpawns;
    private bool[] spawnSlots;
    public GameObject lamp, chair, table;

    public int minLamp, minChair, minTable;
    public int maxLamp, maxChair, maxTable;
    private int lampCount, chairCount, tableCount, totalCount;

    private void Start()
    {
        decoSpawns = new Transform[transform.childCount];
        spawnSlots = new bool[decoSpawns.Length];
        for(int i = 0; i < decoSpawns.Length; i++)
        {
            decoSpawns[i] = transform.GetChild(i);
        }

        DecorationCounts();
        SpawnDecorations();
    }

    void DecorationCounts()
    {
        lampCount = Random.Range(minLamp, maxLamp + 1);
        chairCount = Random.Range(minChair, maxChair + 1);
        tableCount = Random.Range(minTable, maxTable + 1);
        totalCount = lampCount + chairCount + tableCount;

        Debug.Log(lampCount);
        Debug.Log(chairCount);
        Debug.Log(tableCount);
    }

    void SpawnDecorations()
    {
        int lampSpawns = 0;
        int chairSpawns = 0;
        int tableSpawns = 0;
        int spawnCount = 0;

        for(int i = 0; i < decoSpawns.Length; i++)
        {
            if (!spawnSlots[i])
            {
                if (Random.Range(0, 1f) > 0.5f)
                {
                    if (lampSpawns < lampCount)
                    {
                        Instantiate(lamp, decoSpawns[i].position, decoSpawns[i].rotation);
                        lampSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                        Debug.Log("first lamp");
                    }
                    else if (chairSpawns < chairCount)
                    {
                        Instantiate(chair, decoSpawns[i].position, decoSpawns[i].rotation);
                        chairSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                        Debug.Log("first chair");
                    }
                    else if (tableSpawns < tableCount)
                    {
                        Instantiate(table, decoSpawns[i].position, decoSpawns[i].rotation);
                        tableSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                        Debug.Log("first table");
                    }
                }
            }
        }

        if(spawnCount < totalCount)
        {
            for (int j = 0; j < decoSpawns.Length; j++)
            {
                if (!spawnSlots[j])
                {
                    if (lampSpawns < lampCount)
                    {
                        Instantiate(lamp, decoSpawns[j].position, decoSpawns[j].rotation);
                        lampSpawns++;
                        spawnCount++;
                        spawnSlots[j] = true;
                        Debug.Log("second lamp");
                    }
                    else if (chairSpawns < chairCount)
                    {
                        Instantiate(chair, decoSpawns[j].position, decoSpawns[j].rotation);
                        chairSpawns++;
                        spawnCount++;
                        spawnSlots[j] = true;
                        Debug.Log("second chair");
                    }
                    else if (tableSpawns < tableCount)
                    {
                        Instantiate(table, decoSpawns[j].position, decoSpawns[j].rotation);
                        tableSpawns++;
                        spawnCount++;
                        spawnSlots[j] = true;
                        Debug.Log("second table");
                    }
                }
            }
        }
    }
}