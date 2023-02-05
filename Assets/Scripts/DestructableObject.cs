using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    [Header("Options")]
    public GameObject Model;
    public bool UseGameObject;
    public bool UseParticles; // If checked then the script will use the particles on object death, if not then it will instantiate a object
    public int HP; // Health of the game object
    public float Delay;

    [Header("GameObjects")]
    public ParticleSystem particles; // Particles system that bursts on game objects destruction
    public GameObject prefab; // GameObject to instantiate
    
    [Header("Instantiate")]

    [Header("Particles")]
    public int MaxParticles; // Max number of particles that are emitted on the game objects destruction
    public int MinParticles; // Min number of particles that are emitted on the game objects destruction

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            NoHealth();
    }

    private void NoHealth()
    {
        if (UseParticles)
            useParticleSystem();
        else if(UseGameObject)
            instantiateNewObject();
        Model.SetActive(false);
        Invoke("destroySelf", Delay);
    }

    private void instantiateNewObject()
    {
        Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
    }

    private void useParticleSystem()
    {
        particles.gameObject.SetActive(true);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
}
