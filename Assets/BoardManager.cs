using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject m_cardPrefab = null;
    [SerializeField] private uint m_numberOfPairs = 14;
    [SerializeField] private AllCards cardHolder = null;
    
    private LinkedList<int> possibleIndexes;
    private bool m_canClick = true;
    private bool m_isCardSelected = false;
    private Card m_selectedCard = null;
    private uint m_pairsRemaing = 0;
    void Awake()
    {
        InitCards();
        m_pairsRemaing = m_numberOfPairs;
        CardClickNotifier.OnCardClick += CardWasClicked;
        StartCoroutine(DisableGridLayout());
    }

    IEnumerator DisableGridLayout()
    {
        yield return new WaitForSecondsRealtime(.5f);
        GetComponent<GridLayoutGroup>().enabled = false;
    }
    private void InitCards()
    {
        uint numberOfCards = m_numberOfPairs * 2;
        for (uint i = 0; i < numberOfCards; i++)
            Instantiate(m_cardPrefab, transform);
    }

    private void CardWasClicked(Card clickedCard)
    {
        if(m_canClick)
        {
            if (!m_isCardSelected)
            {
                print("first card");
                SelectCard(clickedCard);
            }
            else
            {
                if (ClickedCardWasAlreadySelected(clickedCard))
                {
                    print("card already selected");
                }
                else
                {
                    clickedCard.Flip();
                    StartCoroutine(CheckForPairAndGameOver(clickedCard));
                    
                }
            }
        }
    }

    private IEnumerator CheckForPairAndGameOver(Card clickedCard)
    {
        m_canClick = false;
        yield return new WaitForSecondsRealtime(.5f);
        if (SelectedCardsArePair(clickedCard))
        {
            print("pair!");
            TakeCardsFromBoard(clickedCard);
            if (GameIsOver())
            {
                print("game over");
            }
        }
        else
        {
            print("cards were not pairs");
            clickedCard.Flip();
        }
        DeselectCard();
        m_canClick = true;
    }
    
    private void TakeCardsFromBoard(Card cardToTake)
    {
        cardToTake.PairWasMade();
        m_selectedCard.PairWasMade();
    }

    private bool GameIsOver()
    {
        return (--m_pairsRemaing == 0) ? true : false;
    }
    private bool SelectedCardsArePair(in Card secondCardSelected)
    {
        return secondCardSelected.GetCardType() == m_selectedCard.GetCardType();
    }
    private bool ClickedCardWasAlreadySelected(in Card secondCardSelected)
    {
        return secondCardSelected.GetCardID() == m_selectedCard.GetCardID();
    }
    private void SelectCard(Card clickedCard)
    {
        m_selectedCard = clickedCard;
        m_selectedCard.Flip();
        m_isCardSelected = true;
    }
    private void DeselectCard()
    {
        m_selectedCard.Flip();
        m_selectedCard = null;
        m_isCardSelected = false;
    }
    
    private void OnDisable()
    {
        CardClickNotifier.OnCardClick -= CardWasClicked;
    }
}
