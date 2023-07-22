using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Sprites")]
public class SpriteCollection : ScriptableObject
{
    [SerializeField] private Sprite[] sprites;
    public Sprite[] Sprites { get { return sprites; } private set { } }
}
