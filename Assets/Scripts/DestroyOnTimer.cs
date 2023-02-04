using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    public float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timer);
    }
}
