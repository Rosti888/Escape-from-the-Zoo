using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialTip", menuName = "ScriptableObjects/TutorialTip")]
public class TutorialTip : ScriptableObject
{
    public Sprite tipSprite;
    public string gameObjectName;
    public bool isTipEnabledOnStart;
}
