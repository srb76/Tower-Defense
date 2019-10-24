using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    void Start()
    {
        LoadWaypoints();
        ColorPath();
    }

    private void LoadWaypoints()
    {
        var waypoints = FindObjectsOfType<Waypoint>(); //array of waypoints
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            //add to dict
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping grid at: " + waypoint + ", skipping...");
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }

        print(grid.Count);
    }

    private void ColorPath()
    {
        //color start and end
        grid[startWaypoint.GetGridPos()].SetTopColor(Color.green);
        grid[endWaypoint.GetGridPos()].SetTopColor(Color.red);
    }
}
