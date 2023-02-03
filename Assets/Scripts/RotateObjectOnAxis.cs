using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectOnAxis : MonoBehaviour
{
    public bool Xaxis; // If the game object should rotate on it's X axis
    public bool Yaxis; // If the game object should rotate on it's Y axis
    public bool Zaxis; // If the game object should rotate on it's Z axis
    public bool Reversed; // If the game object should rotate in reverse
    public float RotationSpeed; // speed that the game object rotates;

    void Update()
    {
        if(Xaxis || Yaxis || Zaxis)
        {
            float xSpeed = 0;
            float ySpeed = 0;
            float zSpeed = 0;
            if (Xaxis)
                xSpeed = RotationSpeed;
            if (Yaxis)
                ySpeed = RotationSpeed;
            if (Zaxis)
                zSpeed = RotationSpeed;
            if (!Reversed)
                this.gameObject.transform.Rotate(xSpeed, ySpeed, zSpeed, Space.World);
            else
                this.gameObject.transform.Rotate(-xSpeed, -ySpeed, -zSpeed, Space.World);
        }
    }
}
