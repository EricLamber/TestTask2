using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlantScrt : MonoBehaviour
{
    [SerializeField] private Vector3 PlantGrowTo;
    [SerializeField] private float TimeToGrow;

    private void Start()
    {
        DOTween.SetTweensCapacity(2000, 100);
        StartCoroutine(PlantLogic());
    }

    private IEnumerator PlantLogic()
    {
        transform.DOScale(PlantGrowTo, TimeToGrow);

        yield return new WaitForSeconds(TimeToGrow);

        gameObject.AddComponent<MeshCollider>().convex = true;
    }
}
