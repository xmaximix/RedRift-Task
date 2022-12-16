using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] private string title;
    public string Title => title;

    [SerializeField] private string description;
    public string Description => description;

    [SerializeField] private CardRarity rarity;
    public CardRarity Rarity => rarity;

    [SerializeField] private int manaCost;
    public int ManaCost => manaCost;

    [SerializeField] private int healthPoints;
    public int HealthPoints => healthPoints;

    [SerializeField] private int attackValue;
    public int AttackValue => attackValue;

    public Sprite art;
}