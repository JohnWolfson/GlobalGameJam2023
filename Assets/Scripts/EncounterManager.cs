using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class EncounterManager : MonoBehaviour
{
    public Vector3 playerLastSeenPos;
    public UnityEvent coveringFireActors;
    public UnityEvent playerSpottedActors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoveringFire()
    {
        coveringFireActors.Invoke();
    }

    public void PlayerSpotted()
    {
        playerSpottedActors.Invoke();
    }
}
