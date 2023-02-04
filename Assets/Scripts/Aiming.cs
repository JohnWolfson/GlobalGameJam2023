using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{

     private Animator anim;
    int isAimingParam = Animator.StringToHash("isAiming"); 

    // Start is called before the first frame update
    void Start ()
	{
	    anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool isAiming = Input.GetMouseButton(1); 
        anim.SetBool(isAimingParam, isAiming); 
    }
}
