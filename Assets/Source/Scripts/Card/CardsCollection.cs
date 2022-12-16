using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardsCollection")]
public class CardsCollection : ScriptableObject
{
    [SerializeField] private List<CardData> cards;
    public List<CardData> Cards => cards;

    public int Count => cards.Count;
}
