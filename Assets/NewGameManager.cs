using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{

    [SerializeField] HealthManager healthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        healthManager.NewGame();
    }

}
