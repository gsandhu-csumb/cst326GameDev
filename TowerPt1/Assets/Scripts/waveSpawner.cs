using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public float nextWave;
    public float waveStart;
    public int[] wave;
    public int indexerWave;
    public Transform enemy;
    public Transform spawn1;
    public Transform spawn2;
    void Start()
    {
        waveStart = 0f; nextWave = 1.5f; indexerWave = 0;
    }
    void Update()
    {
        if (waveStart <= 0f)
        {
            SpawnWave();
            waveStart = nextWave;
        }
        waveStart -= Time.deltaTime;
    }
    void SpawnWave(){
        SpawnEnemy1();
        indexerWave++;}
    void SpawnEnemy1(){Instantiate(enemy, spawn1.position, spawn2.rotation);}
}
