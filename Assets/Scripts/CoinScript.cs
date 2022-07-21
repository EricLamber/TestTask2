using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI txt;

    private int GoldCount;

    private void Start()
    {
        if(cam == null)
            cam = Camera.main;
    }

    public void Sellcoin(GameObject coin)
    {
        var targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        StartCoroutine(SellAnimation(coin, targetPos));
    }

    private IEnumerator SellAnimation(GameObject coin, Vector3 targetPos)
    {
        var myTween = coin.transform.DOMove(targetPos, 1f);
        myTween.OnUpdate(() => myTween.ChangeValues(coin.transform.position, targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1))));
        yield return new WaitForSeconds(1f);
        Destroy(coin);
        ChangeGoldTxt();
    }

    private void ChangeGoldTxt()
    {
        GoldCount += 15;
        txt.text = $"{GoldCount}";
    }
}
