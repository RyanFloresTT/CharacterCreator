using UnityEngine;

[CreateAssetMenu(menuName = "Variables/String")]
public class StringVariable : ScriptableObject
{
    [SerializeField] private string _value;
    public string Sprite { get { return _value; } set { _value = value; } }
}
