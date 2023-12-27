using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public GameObject CoinToSpawn; // Coin prefeb to spawn

    public Transform[] PositionL;
    public Transform[] PositionM;
    public Transform[] PositionR;


    private void Awake()
    {
        SpawnCoin();
        SpawnCoin();
        
    }
    private void SpawnCoin()
    {
        int x = Random.Range(0, 3);

        if(x == 0)
        {
            GameObject spawnedObject = Instantiate(CoinToSpawn, PositionL[0].position, Quaternion.identity);
            spawnedObject.transform.SetParent(PositionL[0]);
            GameObject spawnedObject1 = Instantiate(CoinToSpawn, PositionL[1].position, Quaternion.identity);
            spawnedObject1.transform.SetParent(PositionL[1]);
            GameObject spawnedObject2 = Instantiate(CoinToSpawn, PositionL[2].position, Quaternion.identity);
            spawnedObject2.transform.SetParent(PositionL[2]);
        }
        else if(x == 1)
        {
            GameObject spawnedObject = Instantiate(CoinToSpawn, PositionM[0].position, Quaternion.identity);
            spawnedObject.transform.SetParent(PositionM[0]);
            GameObject spawnedObject1 = Instantiate(CoinToSpawn, PositionM[1].position, Quaternion.identity);
            spawnedObject1.transform.SetParent(PositionM[1]);
            GameObject spawnedObject2 = Instantiate(CoinToSpawn, PositionM[2].position, Quaternion.identity);
            spawnedObject2.transform.SetParent(PositionM[2]);
        }
        else {
            GameObject spawnedObject = Instantiate(CoinToSpawn, PositionR[0].position, Quaternion.identity);
            spawnedObject.transform.SetParent(PositionR[0]);
            GameObject spawnedObject1 = Instantiate(CoinToSpawn, PositionR[1].position, Quaternion.identity);
            spawnedObject1.transform.SetParent(PositionR[1]);
            GameObject spawnedObject2 = Instantiate(CoinToSpawn, PositionR[2].position, Quaternion.identity);
            spawnedObject2.transform.SetParent(PositionR[2]);
        }
        
    }
}
