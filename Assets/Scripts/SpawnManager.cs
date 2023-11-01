using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadManager roadManager;

    // Start is called before the first frame update
    void Start()
    {
        roadManager = GetComponent<RoadManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTriggerEntered()
    {
        roadManager.MoveRoad();
    }
}
