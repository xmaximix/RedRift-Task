using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] CardContainer cardContainerPrefab;
    [SerializeField] HandCardsAligner handCardsAligner;
    private List<CardContainer> CardsInDeck;

    public Action<List<CardContainer>> OnCardsCreated;

    public void Initialize(List<CardData> deckCards)
    {
        CardsInDeck = new List<CardContainer>();

        if (deckCards.Count < 0 || cardContainerPrefab == null)
        {
            return;
        }

        for (int i = 0; i < deckCards.Count; i++)
        {
            var newCardContainer = Instantiate(cardContainerPrefab, transform.position, Quaternion.identity, transform);
            newCardContainer.Initialize(deckCards[i]);
            newCardContainer.transform.localScale = Vector3.zero;
            CardsInDeck.Add(newCardContainer);
        }

        OnCardsCreated?.Invoke(CardsInDeck);
    }
}