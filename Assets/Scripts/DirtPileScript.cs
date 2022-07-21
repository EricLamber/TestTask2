using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPileScript : MonoBehaviour
{
    [SerializeField] private GameObject PlantPrefab;
    [SerializeField] private int TimeToRespawn;

    private float timer;

    private void Start()
    {
        SpawnPlant();
    }

    private void Update()
    {
        ReSpawnPlant();
    }

    private void SpawnPlant()
    {
        Instantiate(PlantPrefab, transform.position, transform.rotation, transform.transform);
    }

    private void ReSpawnPlant()
    {
        if (timer > TimeToRespawn && transform.Find("Corn_Plant(Clone)") == null)
        {
            SpawnPlant();
            timer = 0;
        }
        else if (transform.Find("Corn_Plant(Clone)") == null)
            timer += Time.deltaTime % 60;
    }
}
