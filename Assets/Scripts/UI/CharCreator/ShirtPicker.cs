using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ShirtPicker : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private SpriteCollection shirtSprites;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnShirtUpdated;

    private Sprite currentSprite;
    private int spriteIndex;
    private VisualElement root;
    private int spriteCollectionLength;

    private void Start()
    {
        InitListeners();
        spriteCollectionLength = shirtSprites.Sprites.Length;
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var shirtContainer = root.Q<VisualElement>("Shirt");

        var shirtPrevious = shirtContainer.Q<Button>("Previous");
        var shirtNext = shirtContainer.Q<Button>("Next");

        spriteIndex = 0;
        UpdatePlayerSprite();

        shirtPrevious.clicked += Handle_ShirtPrevious;
        shirtNext.clicked += Handle_ShirtNext;
    }

    private void Handle_ShirtNext()
    {
        if (spriteCollectionLength < 2) { return; }
        spriteIndex++;
        if (spriteIndex >= spriteCollectionLength) 
        { 
            spriteIndex = 0;
        }
        UpdatePlayerSprite();
    }

    private void Handle_ShirtPrevious()
    {
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
        currentSprite = shirtSprites.Sprites[spriteIndex];
        playerArt.Shirt = currentSprite;
        OnShirtUpdated?.Invoke();
    }
}
