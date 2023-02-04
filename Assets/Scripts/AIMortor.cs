using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class AIMortor : MonoBehaviour
{
    public EncounterManager encounterManager;
    public Animator mortarAnimator;
    public NavMeshAgent mortarAgent;
    public GameObject corpse;
    public float spotDistance = 15.0f;
    public int health = 100;
    public bool forceGoToWaypointOnWake = true;
    public Transform waypointToForce;
    public Transform mortarLaunchPoint;
    public GameObject mortarProjectile;
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

        if (mortarAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            mortarAgent.isStopped = true;
        }

        if (mortarAnimator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            mortarAgent.isStopped = false;
            if(Vector3.Distance(mortarAgent.destination, transform.position) < 2){
                mortarAnimator.SetTrigger("Shooting");
            }
        }

        if (mortarAnimator.GetCurrentAnimatorStateInfo(0).IsName("InCover"))
        {
            mortarAgent.isStopped = true;
            mortarAnimator.ResetTrigger("Shooting");
        }

        if (mortarAnimator.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
        {
            mortarAgent.isStopped = true;
            var lookPos = encounterManager.playerLastSeenPos - transform.position;
            lookPos.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }

    public void PlayerSpotted(){
        ActorTriggered = true;
        if(forceGoToWaypointOnWake){
            mortarAgent.SetDestination(waypointToForce.position);
        }else{
            var waypointChosen = Random.Range(0, encounterManager.waypoints.Length);
            mortarAgent.SetDestination(encounterManager.waypoints[waypointChosen].position);
        }
        mortarAnimator.SetTrigger("PlayerSpotted");
    }

    public void GenerateWaypoint(){
        float furthestDistance = 0;
        Transform furthestWaypoint = null;
        foreach(Transform waypoint in encounterManager.waypoints)
        {
            float ObjectDistance = Vector3.Distance(encounterManager.playerLastSeenPos, waypoint.transform.position);
            if (ObjectDistance > furthestDistance)
            {
                furthestWaypoint = waypoint;
                furthestDistance = ObjectDistance;
            }
        }
        mortarAgent.SetDestination(furthestWaypoint.position);
    }

    public void LaunchMortar(){
        var mortarShot = Instantiate(mortarProjectile, mortarLaunchPoint.position, mortarLaunchPoint.rotation);
        mortarShot.GetComponent<MortarProjectile>().target = encounterManager.playerLastSeenPos;
    }

    public void GiveCoveringFire(){
        mortarAnimator.SetTrigger("CoveringFire");
    }

    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            encounterManager.playerSpottedActors.RemoveListener(PlayerSpotted);
            encounterManager.coveringFireActors.RemoveListener(GiveCoveringFire);
            mortarAnimator.SetTrigger("Died");
        }
    }
}
