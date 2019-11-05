using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardSO m_cardData = null;
    private int m_ID;
    
    void Awake()
    {
        m_ID = GetInstanceID();
    }

    private void Start()
    {
        m_cardData = AllCards.RandomCardData();
    }

    public void PairWasMade()
    {
        gameObject.SetActive(false);
    }
    public int GetCardType()
    {
        return m_cardData.GetCardType();
    }

    public int GetCardID()
    {
        return m_ID;
    }
}
