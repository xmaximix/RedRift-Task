using UnityEngine;
using UnityEngine.UI;

public class RandomCardValueButton : MonoBehaviour
{
    [SerializeField] Button button;

    private int maximumValue;
    private int minimumValue;
    private Hand hand;
    private int index = 0;

    public void Initialize(Hand hand, int minimumValue, int maximumValue)
    {
        this.hand = hand;
        this.minimumValue = minimumValue;
        this.maximumValue = maximumValue;
        button.onClick.AddListener(ChangeRandomValue);
    }

    public void ChangeRandomValue()
    {
        if (hand.CardsInHand.Count <= 0)
        {
            return;
        }

        ChangeVariant variant = (ChangeVariant)Random.Range(0, 3);
        CardContainer selectedCard = hand.CardsInHand[index];
        int newValue = Random.Range(minimumValue, maximumValue + 1);

        switch (variant)
        {
            case ChangeVariant.Health:
                selectedCard.SetHealthPoints(newValue);
                break;
            case ChangeVariant.Mana:
                selectedCard.SetManaCost(newValue);
                break;
            case ChangeVariant.Attack:
                selectedCard.SetAttackValue(newValue);
                break;
        }

        index++;
        if (index >= hand.CardsInHand.Count)
        {
            index = 0;
        }
    }
}

public enum ChangeVariant
{
    Health = 0,
    Mana = 1,
    Attack = 2,
}
