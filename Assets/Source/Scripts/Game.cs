using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] Deck playerDeck;

    private void Start()
    {
        playerDeck.Initialize(gameConfig);
    }
}
