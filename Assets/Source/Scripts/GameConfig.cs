using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("Cards Amount")]
    [SerializeField] private int minimumCardsNumber;
    public int MinimumCardsNumber => minimumCardsNumber;

    [SerializeField] private int maximumCardsNumber;
    public int MaximumCardsNumber => maximumCardsNumber;

    [Header("Random Button Values")]
    [SerializeField] private int minimumRandomValue;
    public int MinimumRandomValue => minimumRandomValue;

    [SerializeField] private int maximumRandomValue;
    public int MaximumRandomValue => maximumRandomValue;
}