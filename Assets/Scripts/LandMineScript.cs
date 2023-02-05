using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineScript : MonoBehaviour
{
    public GameObject Model;
    public ParticleSystem Particles;
    public Light MineLight; // The light object inside the mine
    public float Range;
    public int Damage; // Amount of damage dealt to the player
    public float DetonateDelay; // The amount of time between the player being detected and the min exploding
    public float SelfDestructDelay; // The amount of time from the model being hiddem to the parent gameobject destroying itself
    public bool PlayerDetected;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !PlayerDetected)
        {
            PlayerDetected = true;
            player = other.gameObject;
            MineLight.GetComponent<LandMineLight>().Alarmed = true;
            Invoke("detonate", DetonateDelay);
        }
    }

    private void detonate()
    {
        Model.SetActive(false);
        Particles.gameObject.SetActive(true);
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if(playerDistance <= Range)    
            player.GetComponent<CharacterStats>().TakeDamage(Damage);
        Invoke("destroySelf", SelfDestructDelay);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
}
