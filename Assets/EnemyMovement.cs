using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Waypoint> path;
    [SerializeField] [Tooltip("In seconds")] float travelDelay = .1f;
    [SerializeField] float speed = 10f;
    bool travelling;
    float startTime;
    float journeyLength;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        travelling = false;
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        path = new List<Waypoint>(pathfinder.GetFinalPath());
        StartCoroutine(CheckForNextWaypoint());
    }

    private void startMoving()
    {
        //if path list is not empty and enemy is not currently moving somewhere, start travelling in update function
        if (path.Any() && (travelling == false) )
        {
            //setup values for lerp
            travelling = true;
            startTime = Time.time;
            initPos = transform.position;
            journeyLength = Vector3.Distance(transform.position, path[0].transform.position);
        }
    }

    IEnumerator CheckForNextWaypoint()
    {
        //check every second for a waypoint destination, toggle travelling bool
        while (true)
        {
            startMoving();
            yield return new WaitForSeconds(travelDelay); 
        }
    }

    private void moveTo(float startTime, Waypoint waypoint)
    {
        //interpolate between current position on journey and destination

        //check if destination is same as current position
        if(transform.position != waypoint.transform.position)
        {
            //float journeyLength = Vector3.Distance(transform.position, waypoint.transform.position); //should be moved elsewhere so it does not run every frame

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(initPos, waypoint.transform.position, fracJourney);
        }
        else
        {
            //destination has been reached, remove index 0 from list
            print("Reached destination waypoint: " + waypoint);
            path.RemoveAt(0);
            travelling = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (travelling)
        {
            //continue lerp progress
            moveTo(startTime, path[0]);
        }
    }
}
