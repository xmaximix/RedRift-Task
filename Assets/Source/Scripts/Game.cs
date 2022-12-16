using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;

    [SerializeField] Hand playerHand;
    [SerializeField] Deck playerDeck;
    [SerializeField] CardsCollection gameCards;

    [HideInInspector]
    [SerializeField] CardsArtLoader artLoader;

    [SerializeField] RandomCardValueButton randomCardValueButton;

    private async void Start()
    {
        List<CardData> playerCardSet = CreateRandomCardSet();

        await artLoader.SetArtTo(playerCardSet);

        playerDeck.OnCardsCreated += playerHand.Initialize;
        playerDeck.Initialize(playerCardSet);

        randomCardValueButton.Initialize(playerHand, gameConfig.MinimumRandomValue, gameConfig.MaximumRandomValue);
    }

    private List<CardData> CreateRandomCardSet()
    {
        List<CardData> cardSet = new List<CardData>();
        int numberOfCards = Random.Range(gameConfig.MinimumCardsNumber, gameConfig.MaximumCardsNumber + 1);
        while (numberOfCards > 0)
        {
            CardData randomCard = gameCards.Cards[Random.Range(0, gameCards.Count)];
            cardSet.Add(randomCard);
            numberOfCards--;
        }
        return cardSet;
    }

    private void OnDestroy()
    {
        playerDeck.OnCardsCreated -= playerHand.Initialize;
    }
}