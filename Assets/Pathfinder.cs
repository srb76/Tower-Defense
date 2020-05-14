using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();
    Waypoint center; //waypoint being searched around

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    bool isExploring = false;

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

    private void FindPath()
    {
        //special condition
        if (startWaypoint.Equals(endWaypoint))
        {
            isExploring = false;
            print("Already at destination!");
            return;
        }

        queue.Enqueue(startWaypoint);
        startWaypoint.isExplored = true;

        while(queue.Count > 0 && isExploring)
        {
            //pop off queue
            center = queue.Dequeue();
            print("Searching from: " + center); //remove me

            //check if destination reached
            //checkDestination();
            //check neighbors
            ExploreNeighbours();
        }
    }

    private bool checkDestination(Waypoint point)
    {
        if (point == endWaypoint)
        {
            print("Found destination.");
            isExploring = false;
            return true;
        }
        else
            return false;
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            if (isExploring)
            {
                Vector2Int exploringPos = center.GetGridPos() + direction;
                QueueNeighbors(exploringPos);
            }
        }
    }

    private void QueueNeighbors(Vector2Int exploringPos)
    {
        if (grid.ContainsKey(exploringPos))
        {
            Waypoint neighbor = grid[exploringPos];
            //neighbor.SetTopColor(Color.blue);
            if (!neighbor.isExplored || queue.Contains(neighbor))
            {
                queue.Enqueue(neighbor);
                neighbor.isExplored = true;
                neighbor.exploredFrom = center;
                //print("Queueing " + neighbor);

                //check destination here?
                if (checkDestination(neighbor))
                {
                    GetPath(neighbor);
                }
            }
        }
    }

    private void GetPath(Waypoint neighbor)
    {
        Waypoint cur = neighbor;
        while(cur.exploredFrom != null)
        {
            path.Insert(0, cur);
            cur = cur.exploredFrom;
        }

        //add starting position
        path.Insert(0, startWaypoint);
    }

    public List<Waypoint> GetFinalPath()
    {
        isExploring = true;
        LoadWaypoints();
        //ColorPath();
        FindPath();
        //PrintPath();

        return path;
    }

    private void PrintPath()
    {
        string pathToDest = "";
        foreach (Waypoint waypoint in path)
        {
            pathToDest += ("(" + waypoint.name + "), ");
        }

        print(pathToDest);
    }

    private void ColorPath()
    {
        //color start and end
        grid[startWaypoint.GetGridPos()].SetTopColor(Color.green);
        grid[endWaypoint.GetGridPos()].SetTopColor(Color.red);
    }

    public List<Waypoint> GetPath()
    {
        return path;
    }
}
