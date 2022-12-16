using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class HandCardsAligner 
{
    [SerializeField] HandCardsAlignerConfig config;

    public void AlignCards(List<CardContainer> cards)
    {
        float totalRotation = -config.TotalRotationAngle;
        float rotationStep = totalRotation / cards.Count;

        float totalWidth = config.HandWidth;
        float positionStep = totalWidth / cards.Count;

        for (int i = 0; i < cards.Count; i++)
        {
            CardContainer card = cards[i];
            MoveCardX(totalWidth, positionStep, i, card);
            float calculatedRotation = CalculateRotation(cards, totalRotation, rotationStep, i);
            card.transform.DORotate(new Vector3(0, 0, calculatedRotation), config.RotationTime);
            MoveCardY(card, calculatedRotation);
        }
    }

    private float CalculateRotation(List<CardContainer> cards, float totalRotation, float rotationStep, int i)
    {
        float calculatedRotation = i * rotationStep - totalRotation / 2;
        if (cards.Count <= 2)
        {
            calculatedRotation = 0;
        }

        return calculatedRotation;
    }

    private void MoveCardY(CardContainer card, float calculatedRotation)
    {
        float scalingFactor = 1.8f;
        float yOffset = Mathf.Abs(calculatedRotation);
        yOffset *= scalingFactor;
        card.transform.DOLocalMoveY(-yOffset, config.InHandMoveTime);
    }

    private void MoveCardX(float totalWidth, float positionStep, int i, CardContainer card)
    {
        float xOffset = positionStep * (i + .5f) - totalWidth / 2;
        card.transform.DOLocalMoveX(xOffset * 100, config.InHandMoveTime);
    }

    public void ShowCard(CardContainer card)
    {
        card.transform.DOScale(config.CardScale, config.AppearTime);
    }

    public void HideCard(CardContainer card)
    {
        card.transform.DOScale(0, config.DissapearTime).OnComplete(() =>
        {
            card.transform.DOKill(); 
            MonoBehaviour.Destroy(card.gameObject);
        });
    }
}
