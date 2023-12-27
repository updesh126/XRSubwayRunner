using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // An array of objects to spawn
    public Transform[] parentPoints; // AN array of positons
    public Vector3 spawnOffset = Vector3.zero;

    private void Awake()
    {
        SpawnObj();
        SpawnObj();
    }
    private  void SpawnObj()
    {
        int randomIndexP = Random.Range(0, parentPoints.Length);
        int randomIndexO = Random.Range(0, objectsToSpawn.Length);
        Vector3 spawnPosition = parentPoints[randomIndexP].position + spawnOffset;
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndexO], spawnPosition, parentPoints[randomIndexP].rotation);
        spawnedObject.transform.SetParent(parentPoints[randomIndexP]);
    }

}
