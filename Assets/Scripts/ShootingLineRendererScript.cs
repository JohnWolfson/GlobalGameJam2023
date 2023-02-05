using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLineRendererScript : MonoBehaviour
{
    public LineRenderer Line;
    public float TimeTillRemoved;

    public void InitialiseLineRenderer(Vector3 newLocation, Vector3 newTarget)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = newLocation;
        positions[1] = newTarget;
        Line.SetPositions(positions);
        Invoke("destroySelf", TimeTillRemoved);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
}
