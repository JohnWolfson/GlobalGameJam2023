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
            switch (other.transform.tag)
            {
                case "AIBomber":
                    other.transform.gameObject.GetComponent<AIBomber>().TakeDamage(damage);
                    break;
                case "AIGunner":
                    other.transform.gameObject.GetComponent<AIGunner>().TakeDamage(damage);
                    break;
                case "AIShield":
                    other.transform.gameObject.GetComponent<AIShield>().TakeDamage(damage);
                    break;
                case "AIMortar":
                    other.transform.gameObject.GetComponent<AIMortor>().TakeDamage(damage);
                    break;
                default:
                    Debug.Log(this.gameObject.name + "' explosion hit " + other.transform.tag);
                    break;
            }
        }
    }
}
