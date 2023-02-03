using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class AIBomber : MonoBehaviour
{
    public EncounterManager encounterManager;
    public Animator bomberAnimator;
    public NavMeshAgent bomberAgent;
    public GameObject explosion;
    public float explodeDistance = 2.0f;
    bool ActorTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        encounterManager.playerSpottedActors.AddListener(PlayerSpotted);
    }

    // Update is called once per frame
    void Update()
    {
        if (bomberAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            bomberAgent.isStopped = true;
        }

        if (bomberAnimator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            bomberAgent.isStopped = false;
            bomberAgent.SetDestination(encounterManager.playerLastSeenPos);
            if(Vector3.Distance(encounterManager.playerLastSeenPos, transform.position) < explodeDistance){
                bomberAnimator.SetTrigger("Explode");
                bomberAgent.isStopped = true;
            }
        }

        if (bomberAnimator.GetCurrentAnimatorStateInfo(0).IsName("Explode"))
        {
            bomberAgent.isStopped = true;
        }
    }

    public void PlayerSpotted(){
        ActorTriggered = true;
        bomberAnimator.SetTrigger("PlayerSpotted");
    }

    public void BomberExplode(){
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
