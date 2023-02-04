using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemScript : MonoBehaviour
{
    public ParticleSystem particles; // Particle system that bursts on models destruction
    public GameObject model; // Mesh that's rendered
    public int HealthPool; // Amount of health the item recovers
    public int HealthStep; // Amount of health added to the player each cycle
    public float TimePerStep; // Amount of time between each health step
    public float ShrinkAmount; // The speed the object shrinks, 1 means it doesn't shrink and lower makes it grow;
    public int MaxParticles; // Maximum amount of particles emitted when item is consumed
    public int MinParticles; // Minimum amount of particles emitted when item is consumed
    public float SelfDestructDelay; // The amount of time from the model being hiddem to the parent gameobject destroying itself
    private float timer;

    void Start()
    {
        timer = TimePerStep;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            healthTimer(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
            TimePerStep = 0;
    }

    private void healthTimer(GameObject Player)
    {
        TimePerStep -= Time.deltaTime;
        if(TimePerStep <= 0 && HealthPool > 0)
        {
            deliverHealth(Player);
            TimePerStep = timer;
            if (HealthPool <= 0)
                RemoveItem();
        }
    }

    private void deliverHealth(GameObject Player)
    {
        bool Healed = Player.GetComponent<CharacterStats>().RecoverHealth(HealthStep);
        if (Healed)
        {
            HealthPool -= HealthStep;
            Vector3 shrink = new Vector3(ShrinkAmount, ShrinkAmount, ShrinkAmount);
            model.transform.localScale = model.transform.localScale / ShrinkAmount;
        }
    }

    private void RemoveItem()
    {
        model.SetActive(false);
        int particlesNumber = Random.Range(MinParticles, MaxParticles);
        particles.transform.position = model.transform.position;
        particles.Emit(particlesNumber);
        Invoke("destroySelf", SelfDestructDelay);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
}
