using System;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    [SerializeField] CardView cardView;

    private int manaCost;
    private int attackValue;
    private int healthPoints;

    public Action<CardContainer> OnRemove;

    public void Initialize(CardData cardData)
    {
        manaCost = cardData.ManaCost;
        attackValue = cardData.AttackValue;
        healthPoints = cardData.HealthPoints;
        cardView.Setup(cardData);
    }

    public void SetManaCost(int value)
    {
        manaCost = value;
        cardView.UpdateManaCost(manaCost);
    }

    public void SetHealthPoints(int value)
    {
        healthPoints = value;
        if (healthPoints < 1)
        {
            RemoveFromHand();
        }
        cardView.UpdateHealthPoints(healthPoints);
    }

    public void SetAttackValue(int value)
    {
        attackValue = value;
        cardView.UpdateAttackValue(attackValue);
    }

    private void RemoveFromHand()
    {
        OnRemove?.Invoke(this);
    }
}