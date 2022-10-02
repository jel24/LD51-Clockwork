using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderManager : MonoBehaviour
{
    [SerializeField] TriggeredEvent drawEvent; 
    [SerializeField] TriggeredEvent moveEvent;
    [SerializeField] TriggeredEvent spawnEvent;
    [SerializeField] TriggeredEvent powerEvent;


    public void TakeTurn()
    {
        drawEvent.Trigger();
        Debug.Log("Drawn.");
        moveEvent.Trigger();
        Debug.Log("Moved.");

        spawnEvent.Trigger();
        Debug.Log("Spawned.");

        powerEvent.Trigger();
        Debug.Log("Empowered.");

    }


}
