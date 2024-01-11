using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roads;
    public GameObject root;
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
        GameObject prefeb = Instantiate(root);
        float newX = roads[roads.Count - 1].transform.position.z + offset;
        GameObject.Destroy(movedRoad);
        //movedRoad.transform.position = new Vector3(0, 0, newX);
        prefeb.transform.position= new Vector3(0, 0, newX);

       // roads.Add(movedRoad);
        roads.Add(prefeb);
    }
}
