using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineScript : MonoBehaviour
{
    public GameObject prefab; // The gameobject to instantiate
    public Light MineLight; // The light object inside the mine
    public float InstantiateDelay; // The amount of time from player being detected to the prefab being instantiated
    public float SelfDestructDelay; // The amount of time from the model being hiddem to the parent gameobject destroying itself
    public bool InstantiateAsChild; // If true, the instianted object will be made a child of this object and destroyed with it when it self destructs
    public bool PlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !PlayerDetected)
        {
            PlayerDetected = true;
            MineLight.GetComponent<LandMineLight>().Alarmed = true;
            Invoke("instantiatePrefab", InstantiateDelay);
        }
    }

    private void instantiatePrefab()
    {
        GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);
        if (InstantiateAsChild)
            newObject.transform.SetParent(this.gameObject.transform);
        Invoke("destroySelf", SelfDestructDelay);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
}
