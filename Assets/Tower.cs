﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Waypoint attached;
    // Start is called before the first frame update
    void Start()
    {
        //set location (temporary)
        transform.position = attached.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
