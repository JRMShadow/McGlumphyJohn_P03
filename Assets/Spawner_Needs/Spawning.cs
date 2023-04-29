using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [Header("Spawning Data")]
    public Transform spawnpoint;
    public GameObject spawns;

    [Header("Loop")]
    public bool stopLoop = false;
    public float amounttoSpawn;

    [Header("Time Delay")]
    public float spawntime;
    public float spawndelay;

    private bool triggered = false;
    private float start = 0;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(triggered != true)
        {
            InvokeRepeating("SpawnObject", spawntime, spawndelay);
            triggered = true;
        }
    }

    public void SpawnObject()
    {
        Instantiate(spawns, spawnpoint.position, spawnpoint.rotation);
        start++;
        if(start >= amounttoSpawn)
        {
            stopLoop = true;
            start = 0;
        }
        if(stopLoop)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
