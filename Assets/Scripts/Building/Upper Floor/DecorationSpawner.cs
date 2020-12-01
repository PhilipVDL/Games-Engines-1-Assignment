using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    private Transform[] decoSpawns;
    private bool[] spawnSlots;
    public GameObject lamp, chair, table;

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
        lampCount = Random.Range(0, maxLamp + 1);
        chairCount = Random.Range(0, chairCount + 1);
        tableCount = Random.Range(0, tableCount + 1);
        totalCount = lampCount + chairCount + tableCount;
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
                    }
                    else if (chairSpawns < chairCount)
                    {
                        Instantiate(chair, decoSpawns[i].position, decoSpawns[i].rotation);
                        chairSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                    }
                    else if (tableSpawns < tableCount)
                    {
                        Instantiate(table, decoSpawns[i].position, decoSpawns[i].rotation);
                        tableSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                    }
                }
            }
        }

        if(spawnCount < totalCount)
        {
            for (int i = 0; i < decoSpawns.Length; i++)
            {
                if (!spawnSlots[i])
                {
                    if (lampSpawns < lampCount)
                    {
                        Instantiate(lamp, decoSpawns[i].position, decoSpawns[i].rotation);
                        lampSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                    }
                    else if (chairSpawns < chairCount)
                    {
                        Instantiate(chair, decoSpawns[i].position, decoSpawns[i].rotation);
                        chairSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                    }
                    else if (tableSpawns < tableCount)
                    {
                        Instantiate(table, decoSpawns[i].position, decoSpawns[i].rotation);
                        tableSpawns++;
                        spawnCount++;
                        spawnSlots[i] = true;
                    }
                }
            }
        }
    }
}