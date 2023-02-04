using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class EncounterManager : MonoBehaviour
{
    public Vector3 playerLastSeenPos;
    public UnityEvent playerSpottedActors;
    public UnityEvent coveringFireActors;
    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerSpotted()
    {
        playerSpottedActors.Invoke();
    }

    public void CoveringFire()
    {
        coveringFireActors.Invoke();
    }
}
