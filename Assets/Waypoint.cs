﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    const int gridSize = 10;
    const int yPos = 0;
    Vector2Int gridPos;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
                                Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public int GetYPos()
    {
        return yPos;
    }

    public void SetTopColor(Color color)
    {
        var topMaterial = transform.Find("Top").GetComponent<MeshRenderer>().material;
        topMaterial.color = color;
        
    }
}
