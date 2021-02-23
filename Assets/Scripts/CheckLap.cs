using MainProject.UI;
using RacingMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ObjectTagData;

public class CheckLap : MonoBehaviour
{
    LapCheckpoint[] m_BaseCheckpoints = null;
    [Inject]
    private readonly ILapsSystem m_LapsSystem = null;


    private void Start()
    {
        m_BaseCheckpoints = GetComponentsInChildren<LapCheckpoint>();
        m_LapsSystem.SetBaseCheckpoint(m_BaseCheckpoints);
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag(ObjectTagData.ObjectTagData.Player))
        {

           
            m_LapsSystem.CheckLap();




        }
    }

 
}
