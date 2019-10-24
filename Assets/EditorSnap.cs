using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Tooltip("How far the object will snap to in the editor")] float gridSize = 10f;
    [SerializeField] float yPos = 0f;
    TextMesh textMesh;
    //string xCoord, zCoord;

    void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = yPos;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
    
        transform.position = snapPos;

        string coordLabel = snapPos.x / 10f + "," + snapPos.z / 10f;
        textMesh.text = coordLabel;
        gameObject.name = coordLabel;
    }
}
