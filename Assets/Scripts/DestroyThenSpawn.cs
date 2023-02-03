using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class DestroyThenSpawn : MonoBehaviour
{
    public GameObject newObject; // Game Object to instantiate

    public bool test;

    public void DestroyAndSpawn()
    {
        Instantiate(newObject, this.gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (test)
            DestroyAndSpawn();
    }
}
