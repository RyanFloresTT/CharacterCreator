using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;
public static class TrustyUnityUtils
{
    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }

    public static Vector3 ToVector3(this Vector2 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }

    public static Sprite GetRandomSprite(this SpriteCollection collection)
    {
        var spritesArr = collection.Sprites;
        if(spritesArr == null || spritesArr.Length < 2) { return null; }
        return spritesArr[Random.Range(0, spritesArr.Length - 1)];
    }
}
