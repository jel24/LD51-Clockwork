using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthDisplay : MonoBehaviour
{

    [SerializeField] HealthManager healthManager;
    [SerializeField] TextMeshProUGUI text;

    public void UpdateHealthDisplay()
    {
        text.text = healthManager.GetHealth().ToString();
    }

}
