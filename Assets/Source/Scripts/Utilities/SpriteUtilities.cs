using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUtilities : MonoBehaviour
{
    public static Sprite CreateSpriteFromTexture(Texture2D texture, int width, int height)
    {
        return Sprite.Create(texture, new Rect(0, 0, width, height), Vector2.zero);
    }
}
