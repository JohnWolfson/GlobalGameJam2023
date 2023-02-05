using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Animator animator;
    public bool Open = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && other.GetComponent<CharacterStats>().Keys > 0) 
        {
            PlayerDetected();
            other.GetComponent<CharacterStats>().UpdateKeys(-1);
        }
    }

    private void PlayerDetected()
    {
        Open = true;
        animator.SetTrigger("Open");
    }
}
