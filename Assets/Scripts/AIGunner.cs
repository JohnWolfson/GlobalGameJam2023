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
    public ParticleSystem gunParticles;
    public GameObject corpse;
    public float spotDistance = 15.0f;
    public bool forceGoToWaypointOnWake = true;
    public Transform waypointToForce;
    Transform player;
    bool ActorTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        encounterManager.playerSpottedActors.AddListener(PlayerSpotted);
        encounterManager.coveringFireActors.AddListener(GiveCoveringFire);
        var emission = gunParticles.emission;
        emission.enabled = false;
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

        if (gunnerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            gunnerAgent.isStopped = true;
        }

        if (gunnerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            gunnerAgent.isStopped = false;
            if(Vector3.Distance(gunnerAgent.destination, transform.position) < 2){
                gunnerAnimator.SetTrigger("Shooting");
            }
        }

        if (gunnerAnimator.GetCurrentAnimatorStateInfo(0).IsName("InCover"))
        {
            gunnerAgent.isStopped = true;
            gunnerAnimator.ResetTrigger("Shooting");
        }

        if (gunnerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
        {
            gunnerAgent.isStopped = true;
            var lookPos = encounterManager.playerLastSeenPos - transform.position;
            lookPos.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }

    public void PlayerSpotted(){
        ActorTriggered = true;
        if(forceGoToWaypointOnWake){
            gunnerAgent.SetDestination(waypointToForce.position);
        }else{
            var waypointChosen = Random.Range(0, encounterManager.waypoints.Length);
            gunnerAgent.SetDestination(encounterManager.waypoints[waypointChosen].position);
        }
        gunnerAnimator.SetTrigger("PlayerSpotted");
    }

    public void GenerateWaypoint(){
        var waypointChosen = Random.Range(0, encounterManager.waypoints.Length);
        gunnerAgent.SetDestination(encounterManager.waypoints[waypointChosen].position);
    }

    public void StartShootingGun(){
        var emission = gunParticles.emission;
        emission.enabled = true;
    }

    public void StopShootingGun(){
        var emission = gunParticles.emission;
        emission.enabled = false;
    }

    public void GiveCoveringFire(){
        gunnerAnimator.SetTrigger("CoveringFire");
    }

    public void TakeDamage(int damage){
        
    }
}
