using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.x).ToList();
        }
    }

    public void MoveRoad()
    {
        //yield return new WaitForSeconds(3);
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newX = roads[roads.Count - 1].transform.position.x + offset;
        movedRoad.transform.position = new Vector3(newX, 0, 0);
        
        roads.Add(movedRoad);
    }
}
