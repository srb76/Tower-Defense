using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class EditorSnap : MonoBehaviour
{
    TextMesh textMesh;
    Vector3 snapPos;
    Waypoint waypoint;

    void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel(snapPos);
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        snapPos.x = waypoint.GetGridPos().x * 10f;
        snapPos.y = waypoint.GetYPos();
        snapPos.z = waypoint.GetGridPos().y * 10f;
        transform.position = snapPos;
    }

    private void UpdateLabel(Vector3 snapPos)
    {
        string coordLabel = snapPos.x / 10f + "," + snapPos.z / 10f;
        textMesh.text = coordLabel;
        gameObject.name = coordLabel;
    }
}
