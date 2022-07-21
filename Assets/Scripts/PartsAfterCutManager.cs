using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsAfterCutManager : MonoBehaviour
{
    [SerializeField] private GameObject BlockPrefab;
    [SerializeField] private float PartsLifeTime;

    private GameObject PlantPart;
    private float timer;

    private void Update()
    {
        PartLogic();
    }

    private void DestroyIt(GameObject obj)
    {
        Destroy(obj);
        Instantiate(BlockPrefab, obj.transform.position, obj.transform.rotation);
    }

    private void PartLogic()
    {
        if ((timer > PartsLifeTime) &&
            (PlantPart = GameObject.FindGameObjectWithTag("Parts")))
        {
            DestroyIt(PlantPart);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime % 60;
        }
            
    }
}
