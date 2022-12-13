using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public int MinimalCardsAmount;
    [field: SerializeField] int MaximalCardsAmount;
}
