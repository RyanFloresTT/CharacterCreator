using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Sprite")]
public class SpriteVariable : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } set { _sprite = value; } }
}
