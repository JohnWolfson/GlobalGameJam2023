using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAnimation()
    {
        var anim = gameObject.GetComponent<Animation>();
        anim.Play();
    }
}
