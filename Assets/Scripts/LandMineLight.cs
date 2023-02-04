using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineLight : MonoBehaviour
{
    [Header("Standby")]
    public Vector2 StandbyIntensity;
    public float StandbySpeed;
    private bool standbyUp = true;
    
    [Header("Countdown")]
    public Vector2 CountdownIntensity;
    public float CountdownTimer;
    private bool countdownUp = true;

    [Header("Other")]
    public Light Light;
    public bool Alarmed = false;

    private float timer;
    
    void Start()
    {
        Light.intensity = StandbyIntensity.x;
        timer = CountdownTimer;
    }

    void Update()
    {
        if (!Alarmed)
            Standby();
        else
            CountDown();
    }

    private void Standby()
    {
        if (standbyUp)
        {
            Light.intensity += (StandbySpeed * Time.deltaTime);
            if (Light.intensity >= StandbyIntensity.y)
                standbyUp = false;
        }
        else
        {
            Light.intensity -= (StandbySpeed * Time.deltaTime);
            if (Light.intensity <= StandbyIntensity.x)
                standbyUp = true;
        }
    }

    private void CountDown()
    {
        CountdownTimer -= Time.deltaTime;
        if(CountdownTimer <= 0)
        {
            CountdownTimer = timer;
            if (countdownUp)
            {
                Light.intensity = CountdownIntensity.x;
                countdownUp = false;
            }
            else
            {
                Light.intensity = CountdownIntensity.y;
                countdownUp = true;
            }
        }
    }
}
