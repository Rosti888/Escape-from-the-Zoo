using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;

    private void Start()
    {
        cloud1.transform.DOLocalMoveY(transform.position.y - 900, 10f).SetLoops(-1, LoopType.Yoyo);
        cloud2.transform.DOLocalMoveY(transform.position.y - 700, 10f).SetLoops(-1, LoopType.Yoyo);
        cloud3.transform.DOLocalMoveY(transform.position.y - 900, 10f).SetLoops(-1, LoopType.Yoyo);
        cloud4.transform.DOLocalMoveY(transform.position.y - 700, 10f).SetLoops(-1, LoopType.Yoyo);
    }
}
