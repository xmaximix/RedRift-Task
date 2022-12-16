using UnityEngine;

[CreateAssetMenu(menuName = "Card Aligner Config")]
public class HandCardsAlignerConfig : ScriptableObject
{
    [Header("Appearance Settings")]
    [SerializeField] private float cardScale;
    public float CardScale => cardScale;
    [SerializeField] private float appearTime;
    public float AppearTime => appearTime;
    [SerializeField] private float dissapearTime;
    public float DissapearTime => dissapearTime;

    [Header("In-Hand Movement Settings")]
    [SerializeField] private float handWidth;
    public float HandWidth => handWidth;
    [SerializeField] private float totalRotationAngle;
    public float TotalRotationAngle => totalRotationAngle;
    [SerializeField] private float gapBetweenCards;
    public float GapBetweenCards => gapBetweenCards;
    [SerializeField] private float inHandMoveTime;
    public float InHandMoveTime => inHandMoveTime;
    [SerializeField] private float rotationTime;
    public float RotationTime => rotationTime;
}
