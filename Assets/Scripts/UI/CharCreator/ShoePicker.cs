using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ShoePicker : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private SpriteCollection shoeSprites;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnShoesUpdated;

    private Sprite currentSprite;
    private int spriteIndex;
    private VisualElement root;
    private int spriteCollectionLength;

    private void Start()
    {
        InitListeners();
        spriteCollectionLength = shoeSprites.Sprites.Length;
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var shoeContainer = root.Q<VisualElement>("Shoes");

        var shoePrevious = shoeContainer.Q<Button>("Previous");
        var shoeNext = shoeContainer.Q<Button>("Next");

        spriteIndex = 0;
        UpdatePlayerSprite();

        shoePrevious.clicked += Handle_ShoePrevious;
        shoeNext.clicked += Handle_ShoeNext;
    }

    private void Handle_ShoeNext()
    {
        if (spriteCollectionLength < 2) { return; }
        spriteIndex++;
        if (spriteIndex >= spriteCollectionLength) 
        { 
            spriteIndex = 0;
        }
        UpdatePlayerSprite();
    }

    private void Handle_ShoePrevious()
    {
        Debug.Log("Hi");
        if (spriteCollectionLength < 2) { return; }
        spriteIndex--;
        if (spriteIndex < 0)
        {
            spriteIndex = spriteCollectionLength - 1;
        }
        UpdatePlayerSprite();
    }

    private void UpdatePlayerSprite()
    {
        currentSprite = shoeSprites.Sprites[spriteIndex];
        playerArt.Shoes = currentSprite;
        OnShoesUpdated?.Invoke();
    }
}
