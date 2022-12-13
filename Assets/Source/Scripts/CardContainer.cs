using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    [SerializeField] CardView cardView;

    public void Initialize(CardData cardData)
    {
        cardView.Setup(cardData);
    }
}
