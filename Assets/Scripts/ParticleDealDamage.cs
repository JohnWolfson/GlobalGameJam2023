using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDealDamage : MonoBehaviour
{
    public int damage = 15;
    
    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player"){
            other.transform.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
        }
    }
}
