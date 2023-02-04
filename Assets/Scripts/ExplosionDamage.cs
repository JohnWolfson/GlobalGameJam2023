using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public int damage = 35;

    void Start(){
        Destroy(this, 0.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            other.transform.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
        }
    }
}
