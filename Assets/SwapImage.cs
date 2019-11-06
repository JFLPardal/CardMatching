using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class SwapImage : MonoBehaviour
{
    private Card m_card = null;
    //private Image m_cardImage = null;
    private void Awake()
    {
        m_card = GetComponentInParent<Card>();
        //m_cardImage = GetComponent<Image>();
    }

    public void SwapCardImage()
    {
        m_card.SwapImage();
    }
}
