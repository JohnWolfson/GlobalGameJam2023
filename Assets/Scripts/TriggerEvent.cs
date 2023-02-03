using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent objectsToTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            objectsToTrigger.Invoke();
        }
    }
}
