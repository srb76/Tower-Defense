using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Waypoint> path;
    [SerializeField] [Tooltip("In seconds")] float travelDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        path = pathfinder.GetFinalPath();
        StartCoroutine(TravelAlongPath());
    }

    IEnumerator TravelAlongPath()
    {
        print("Enemy starting travel, path length is "+path.Count);
        foreach (Waypoint waypoint in path)
        {
            print("Travelling: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(travelDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
