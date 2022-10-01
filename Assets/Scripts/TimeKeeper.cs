using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public TriggeredEvent TenSecondsPass;

    public void TenSeconds()
    {
        TenSecondsPass.Trigger();
    }


}
