using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public SpawnManager spawnManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpawnTrigger")
            spawnManager.spawnTriggerEntered();
    }
}
