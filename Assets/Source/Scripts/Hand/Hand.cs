using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hand : MonoBehaviour
{
    [SerializeField] HandCardsAligner cardsAligner;

    [SerializeField] GameObject cardsContainer;

    private List<CardContainer> cardsInHand;
    public List<CardContainer> CardsInHand => cardsInHand;

    public void Initialize(List<CardContainer> cards)
    {
        cardsInHand = cards;

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            cardsInHand[i].OnRemove += RemoveFromHand;
            cardsInHand[i].transform.SetParent(cardsContainer.transform);
            cardsInHand[i].transform.localPosition = Vector3.zero;
        }

        StartCoroutine(ShowCards());
    }

    private IEnumerator ShowCards()
    {
        cardsAligner.AlignCards(cardsInHand);
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            yield return new WaitForSeconds(0.1f);
            cardsAligner.ShowCard(cardsInHand[i]);
        }
    }

    private void RemoveFromHand(CardContainer card)
    {
        cardsInHand.Remove(card);

        StartCoroutine(Delay(() => { 
            cardsAligner.HideCard(card); 
            cardsAligner.AlignCards(cardsInHand); 
        }, 1f));
        card.OnRemove -= RemoveFromHand;
    }


    private IEnumerator Delay(UnityAction callback, float time)
    {
        yield return new WaitForSeconds(time);
        callback();
    }
}
