using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarProjectile : MonoBehaviour
{
    public Vector3 target;
    public Rigidbody rb;
    public float missileSpeed = 50f;
    public float missileRotationSpeed = 3f;
    public float damage = 10f;
    public GameObject explosion;
    public Transform aimRotation;
    float detonationTimer = 30f;
    float rotationTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Debug.Log("Missile has no target!");
            if(detonationTimer > 3){
                detonationTimer = 3.0f;
            }
        }

        rb.AddForce(transform.forward * missileSpeed);

        if(target != null){
            aimRotation.LookAt(target);
        }

        if(rotationTimer < 0){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, aimRotation.rotation, Time.deltaTime * missileRotationSpeed);
        }

        detonationTimer -= Time.deltaTime;

        rotationTimer -= Time.deltaTime;

        if(detonationTimer < 0){
            Debug.Log("Missile timed out");
            Destroy(this.gameObject);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision other){
        if(other.transform != this.transform && other.transform.tag != "Plane"){
            Debug.Log("Missile stuck object " + other);
            Destroy(this.gameObject);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
        }
    }
}
