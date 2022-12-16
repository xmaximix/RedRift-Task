using UnityEngine;

public enum CardRarity
{
    Common = 0,
    Rare = 1,
    Epic = 2,
    Legendary = 3
}

public static class CardRarities
{
    private static Color Rare = new Color(0.2122642f, 0.6359147f, 1f);
    private static Color Mythic = new Color(0.92788f, 0.3392221f, 0.9339623f);
    private static Color Common = new Color(0.6415094f, 0.6415094f, 0.6415094f);
    private static Color Legendary = new Color(0.9339623f, 0.6982604f, 0.4713866f);

    private static Color[] colors = {
        Common,
        Rare,
        Mythic,
        Legendary
    };

    public static Color GetColor(CardRarity rarity)
    {
        return colors[(int)rarity];
    }
}