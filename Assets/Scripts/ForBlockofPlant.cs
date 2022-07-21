using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBlockofPlant : MonoBehaviour
{
    [SerializeField] private GameObject CoinPrefab;

    private CoinScript CoinScript;

    private void Start()
    {
        CoinScript = GameObject.Find("CoinManager").GetComponent<CoinScript>();
    }

    private void OnDestroy()
    {
        CoinScript.Sellcoin(Instantiate(CoinPrefab, transform.position, Camera.main.transform.rotation));
    }
}
