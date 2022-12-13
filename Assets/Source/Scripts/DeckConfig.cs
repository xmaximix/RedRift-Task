using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck")]
public class DeckConfig : ScriptableObject
{
    public CardData[] cards;
}
