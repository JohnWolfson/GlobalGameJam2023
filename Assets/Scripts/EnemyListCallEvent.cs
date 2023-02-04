using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyListCallEvent : MonoBehaviour
{
    public List<GameObject> NPCS = new List<GameObject>();
    public UnityEvent Event;

    void Start()
    {
        InvokeRepeating("checkList", 0f, 5f);
    }

    private void checkList()
    {
        List<GameObject> temp = new List<GameObject>();
        foreach(GameObject NPC in NPCS)
            if(NPC != null)
                temp.Add(NPC);
        NPCS = temp;
        if (NPCS.Count < 1)
            callEvent();
    }

    private void callEvent()
    {
        if(Event != null)
            Event.Invoke();
        Destroy(this);
    }
}
