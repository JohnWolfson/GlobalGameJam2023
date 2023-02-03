using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleRandom : MonoBehaviour
{
    public ParticleSystem particles;
    public float MaxTime; // Maximum amount of time before a particle effect is played
    public float MinTime; // Minimum amount of time before a particle effect is played
    public float Timer; // Time till next burst

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            fireParticles();
        }
    }

    private void fireParticles()
    {
        particles.Play();
        Timer = Random.Range(MinTime, MaxTime);
    }
}
