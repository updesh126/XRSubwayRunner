using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 106f;

    // Start is called before the first frame update
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad()
    {
        //yield return new WaitForSeconds(3);
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newX = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newX);

        roads.Add(movedRoad);
    }
}
