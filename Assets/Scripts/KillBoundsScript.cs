using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoundsScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            other.gameObject.GetComponent<CharacterStats>().playerDeath();
    }
}
