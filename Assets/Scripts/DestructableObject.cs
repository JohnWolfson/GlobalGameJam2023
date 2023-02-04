using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    [Header("Options")]
    public bool UseParticles; // If checked then the script will use the particles on object death, if not then it will instantiate a object
    public int HP; // Health of the game object

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
            destroySelf();
    }

    private void destroySelf()
    {
        if (UseParticles)
            useParticleSystem();
        else
            instantiateNewObject();
        Destroy(this.gameObject);
    }

    private void instantiateNewObject()
    {
        Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
    }

    private void useParticleSystem()
    {
        Debug.Log("Test 1");
        int particleNumber = Random.Range(MinParticles, MaxParticles);
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = transform.position;
        emitParams.applyShapeToPosition = true;
        particles.Emit(emitParams, particleNumber);
    }
}
