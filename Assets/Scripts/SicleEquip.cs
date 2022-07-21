using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicleEquip : MonoBehaviour
{
    
    [SerializeField] private GameObject HandSicle;

    private void ToolEquip()
    {
        HandSicle.SetActive(true);
    }

    private void ToolUnequip()
    {
        HandSicle.SetActive(false);
    }
}
