using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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

    public void UpdateAttackValue(int value)
    {
        StartCoroutine(SmoothCounter(value, attackTMPU));
    }

    public void UpdateHealthPoints(int value)
    {
        StartCoroutine(SmoothCounter(value, healthPointsTMPU));
    }

    public void UpdateManaCost(int value)
    {
        StartCoroutine(SmoothCounter(value, manaCostTMPU));
    }

    IEnumerator SmoothCounter(int endValue, TextMeshProUGUI tmpu)
    {
        int fromValue = 0;
        int.TryParse(tmpu.text, out fromValue);

        float time = 0;
        float timeBetweenTextUpdates = 0.05f;

        for (float t = 0; t < 1; t += Time.deltaTime * 2)
        {
            time += Time.deltaTime;
            var value = Mathf.Lerp(fromValue, endValue, t * t);
            if (time > timeBetweenTextUpdates)
            {
                time = 0f;
                tmpu.text = ((int)value).ToString();
            }
            yield return null;
        }
        tmpu.text = endValue.ToString();
    }
}
