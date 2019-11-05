using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

[CreateAssetMenu(fileName = "Card00", menuName = "ScriptableObjects/Card")]
public class CardSO : ScriptableObject
{
    public int GetCardType()
    {
        return GetInstanceID();
    }
}
