using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Waypoint placement;
    [SerializeField] Transform target;
    [SerializeField] Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        //set location (temporary)
        transform.position = placement.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //look for target if none
        if(target==null){

        }

        //look at current target
        gun.LookAt(target);
    }
}
