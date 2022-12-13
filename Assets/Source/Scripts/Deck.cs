using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] [HideInInspector] CardsArtLoader artLoader;

    [SerializeField] CardContainer cardContainerPrefab;
    [SerializeField] DeckConfig deckConfig;

    public async void Initialize(GameConfig gameConfig)
    {
        if (deckConfig.cards.Length < 0 || cardContainerPrefab == null)
        {
            return;
        }

        await artLoader.SetArtTo(deckConfig.cards);

        for (int i = 0; i < deckConfig.cards.Length; i++)
        {
            var newCardContainer = Instantiate(cardContainerPrefab, transform.position, Quaternion.identity, transform);
            newCardContainer.Initialize(deckConfig.cards[i]);
        }
    }
}