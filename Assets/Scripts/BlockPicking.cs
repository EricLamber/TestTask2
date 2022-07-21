using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BlockPicking : MonoBehaviour
{
    [SerializeField] private GameObject PointForBlocks;
    [SerializeField] private GameObject PlaseForSell;
    [SerializeField] private byte LimitOfBlocks;
    [SerializeField] private TextMeshProUGUI txt;

    private GameObject pastblock;
    private bool IsBlockActive;
    private byte BlockCount;

    private void Awake()
    {
        pastblock = PointForBlocks;
        ChangeUITxt();
    }

    private void PickingUp(GameObject block)
    {
        block.GetComponent<BoxCollider>().enabled = false;
        block.GetComponent<Rigidbody>().mass = pastblock.GetComponent<Rigidbody>().mass + 1;
        var joint = block.AddComponent<HingeJoint>();
        joint.connectedBody = pastblock.GetComponent<Rigidbody>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = new Vector3(0f, 0.3f, 0f);
        joint.useSpring = true;
        var spring = joint.spring;
        spring.spring = 10000f;
        joint.spring = spring;
        block.transform.parent = pastblock.transform;
        block.transform.rotation = new Quaternion(0, 0, 0, 0);
        pastblock = block;
        BlockCount++;
        ChangeUITxt();
        IsBlockActive = false;
    }

    private void SellingBlocks(Transform parentblock)
    {
        var block = parentblock.Find("BlockOfPlant(Clone)");
        if (block != null)
            SellingBlocks(block);

        if (parentblock != PointForBlocks.transform)
        {
            StartCoroutine(SellingCourotine(parentblock));
            BlockCount--;
            ChangeUITxt();
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block") && !IsBlockActive && BlockCount < LimitOfBlocks)
        {
            IsBlockActive = true;
            PickingUp(other.gameObject);
        }
        else if(other.CompareTag("SellPlace"))
        {
            SellingBlocks(PointForBlocks.transform);
            pastblock = PointForBlocks;
        }
    }

    private IEnumerator SellingCourotine(Transform block)
    {
        Destroy(block.GetComponent<HingeJoint>());
        block.DOMove(PlaseForSell.transform.position, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(block.gameObject);
    }

    private void ChangeUITxt()
    {
        txt.text = $"{BlockCount}/{LimitOfBlocks}";
    }
}
