using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDamage : MonoBehaviour
{
    public int Damage;
    public float DamageTimer;
    private float timer;

    void Start()
    {
        timer = DamageTimer;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            DamageTimer -= Time.deltaTime;
            if(DamageTimer < 0)
            {
                DamageTimer = timer;
                other.gameObject.GetComponent<CharacterStats>().TakeDamage(Damage);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            DamageTimer = 0;
        }
    }
}
