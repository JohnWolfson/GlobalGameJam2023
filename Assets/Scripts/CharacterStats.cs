﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particles; // Particle System use for firing
    public int MaxHP; // Player max health
    public int HP; // Player current health
    public int Ammo; // Player ammo count; 
    public int Damage; // Player damage per shot
    public float Accuracy; // The higher this is, the lower the accuracy
    public bool CanFire; // If the player has finished the current firing animation to fire again

    void Start()
    {
        CanFire = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Ammo > 0 && CanFire)
        {
            CanFire = false;
            animator.SetTrigger("Fire");
        }
    }

    private void fireWeapon()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        Vector3 spreadVector = getSpreadVector();
        Debug.DrawRay(transform.position, spreadVector * 100, Color.red, 600);
        if (Physics.Raycast(transform.position, spreadVector, out hit, 10000f, layerMask))
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000f, layerMask))
        {
            switch (hit.transform.tag)
            {
                case "AIBomber":
                    hit.transform.gameObject.GetComponent<AIBomber>().TakeDamage(Damage);
                    break;
                case "AIGunner":
                    hit.transform.gameObject.GetComponent<AIGunner>().TakeDamage(Damage);
                    break;
                case "AIShield":
                    hit.transform.gameObject.GetComponent<AIShield>().TakeDamage(Damage);
                    break;
                case "AIMortar":
                    hit.transform.gameObject.GetComponent<AIMortor>().TakeDamage(Damage);
                    break;
                default:
                    Debug.Log(this.gameObject.name + ": CharacterStats -> Raycast hit returned unrecognised tag: " + hit.transform.tag);
                    break;
            }
        }
    }

    private Vector3 getSpreadVector()
    {
        float yAngle = Random.Range(-Accuracy, Accuracy);
        float xAngle = Random.Range(-Accuracy, Accuracy);
        Quaternion ySpreadAngle = Quaternion.AngleAxis(yAngle, new Vector3(0, 1, 0));
        Quaternion xSpreadAngle = Quaternion.AngleAxis(xAngle, new Vector3(1, 0, 0));
        Quaternion totalSpreadAngle = xSpreadAngle * ySpreadAngle;
        Vector3 newVector = totalSpreadAngle * transform.TransformDirection(Vector3.forward);
        return newVector;
    }

    private void SetCanFire()
    {
        CanFire = true;
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