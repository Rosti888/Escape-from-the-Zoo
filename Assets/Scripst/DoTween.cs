using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    public GameObject Cloud1;
    public GameObject Cloud2;
    public GameObject Cloud3;
    public GameObject Cloud4;
    private void Start()
    {
        Cloud1.transform.DOLocalMoveY(transform.position.y - 900, 10f).SetLoops(-1, LoopType.Yoyo);
        Cloud2.transform.DOLocalMoveY(transform.position.y - 700, 10f).SetLoops(-1, LoopType.Yoyo);
        Cloud3.transform.DOLocalMoveY(transform.position.y - 900, 10f).SetLoops(-1, LoopType.Yoyo);
        Cloud4.transform.DOLocalMoveY(transform.position.y - 700, 10f).SetLoops(-1, LoopType.Yoyo);
    }
}
