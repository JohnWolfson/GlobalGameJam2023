using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class AIShield : MonoBehaviour
{
    public EncounterManager encounterManager;
    public Animator shieldAnimator;
    public NavMeshAgent shieldAgent;
    public GameObject corpse;
    public float spotDistance = 15.0f;
    public Transform player;
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
            if (Physics.Linecast(transform.position, player.position))
            {
                if(ActorTriggered){
                    encounterManager.playerLastSeenPos = player.position;
                }else{
                    encounterManager.PlayerSpotted();
                    encounterManager.playerLastSeenPos = player.position;
                }
            }
        }

        if (shieldAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            shieldAgent.isStopped = true;
        }
    }

    public void PlayerSpotted(){
        ActorTriggered = true;
        shieldAnimator.SetTrigger("PlayerSpotted");
    }

    public void GiveCoveringFire(){
        
    }

    public void TakeDamage(int damage){
        
    }
}
