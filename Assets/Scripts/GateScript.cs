using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && other.GetComponent<CharacterStats>().Keys > 0) 
        {
            PlayerDetected();
            other.GetComponent<CharacterStats>().Keys--;
        }
    }

    private void PlayerDetected()
    {
        animator.SetTrigger("Open");
    }
}
