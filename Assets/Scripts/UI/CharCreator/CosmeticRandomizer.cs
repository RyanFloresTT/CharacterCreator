using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CosmeticRandomizer : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private SpriteCollection skin;
    [SerializeField] private SpriteCollection hair;
    [SerializeField] private SpriteCollection shirt;
    [SerializeField] private SpriteCollection pants;
    [SerializeField] private SpriteCollection shoes;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnCosmeticRandomized;

    private VisualElement root;

    private void Start()
    {
        InitListeners();
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var randButton = root.Q<Button>("RandomizeButton");

        randButton.clicked += Handle_Randomize;
    }

    private void Handle_Randomize()
    {
        SetRandomArtValues();
        OnCosmeticRandomized?.Invoke();
    }

    private void SetRandomArtValues()
    {
        playerArt.Skin = skin.GetRandomSprite();
        playerArt.Hair = hair.GetRandomSprite();
        playerArt.Shirt = shirt.GetRandomSprite();
        playerArt.Pants = pants.GetRandomSprite();
        playerArt.Shoes = shoes.GetRandomSprite();
    }
}