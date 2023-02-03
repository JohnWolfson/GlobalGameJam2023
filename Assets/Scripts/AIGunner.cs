using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class AIGunner : MonoBehaviour
{
    public EncounterManager encounterManager;
    public Animator gunnerAnimator;
    public NavMeshAgent gunnerAgent;
    public GameObject corpse;
    public float spotDistance;
    Transform player;
    bool ActorTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        encounterManager.playerSpottedActors.AddListener(PlayerSpotted);
        encounterManager.coveringFireActors.AddListener(GiveCoveringFire);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < spotDistance){
            if (!Physics.Linecast(transform.position, player.position))
            {
                if(ActorTriggered){
                    encounterManager.playerLastSeenPos = player.position;
                }else{
                    encounterManager.PlayerSpotted();
                    encounterManager.playerLastSeenPos = player.position;
                }
            }
        }
    }

    public void PlayerSpotted(){
        ActorTriggered = true;
        gunnerAnimator.SetTrigger("PlayerSpotted");
    }

    public void GiveCoveringFire(){

    }
}
