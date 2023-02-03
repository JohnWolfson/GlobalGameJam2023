using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public ParticleSystem particles; // Particle System use for firing
    public int MaxHP; // Player max health
    public int HP; // Player current health
    public int Ammo; // Player ammo count; 
    public int Damage; // Player damage per shot
    public float ShootSpeed; // Time between each of the players shots
    float timer; // Reset variable for the shoot speed

    int number = 0;

    void Start()
    {
        timer = ShootSpeed; 
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Ammo > 0)
        {
            if (ShootSpeed <= 0)
                fireWeapon();
            else
                ShootSpeed -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
            ShootSpeed = 0;
    }

    private void fireWeapon()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000f, layerMask))
        //{
        //    switch (hit.transform.tag)
        //    {
        //        case "AIBomber":
        //            //hit.transform.gameObject.GetComponent<AIBomber>().TakeDamage(damage);
        //            break;
        //        case "AIGunner":
        //            //hit.transform.gameObject.GetComponent<AIGunner>().TakeDamage(damage);
        //            break;
        //        case "AIShield":
        //            //hit.transform.gameObject.GetComponent<AIShield>().TakeDamage(damage);
        //            break;
        //        case "AIMortar":
        //            //hit.transform.gameObject.GetComponent<AIMortar>().TakeDamage(damage);
        //            break;
        //        default:
        //            Debug.Log(this.gameObject.name + ": CharacterStats -> Raycast hit returned unrecognised tag: " + hit.transform.tag);
        //            break;
        //    }
        //}
        Debug.Log("Fire " + number);
        number += 1;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            playerDeath();
    }

    private void playerDeath()
    {

    }
}
