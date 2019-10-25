using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] [Tooltip("In seconds")] float travelDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //path = Pathfinder.GetPath();
        StartCoroutine(TravelAlongPath());
    }

    IEnumerator TravelAlongPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(travelDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
