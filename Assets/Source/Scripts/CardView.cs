using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Image artImage;
    [SerializeField] Image rarityImage;

    [SerializeField] TextMeshProUGUI titleTMPU;
    [SerializeField] TextMeshProUGUI descriptionTMPU;
    [SerializeField] TextMeshProUGUI manaCostTMPU;
    [SerializeField] TextMeshProUGUI healthPointsTMPU;
    [SerializeField] TextMeshProUGUI attackTMPU;

    public void Setup(CardData card)
    {
        artImage.sprite = card.art;
        rarityImage.color = CardRarities.GetColor(card.Rarity);

        titleTMPU.text = card.Title;
        descriptionTMPU.text = card.Description;
        manaCostTMPU.text = card.ManaCost.ToString();
        healthPointsTMPU.text = card.HealthPoints.ToString();
        attackTMPU.text = card.AttackValue.ToString();
    }
}
