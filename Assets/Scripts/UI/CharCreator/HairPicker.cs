using System;
using UnityEngine;
using UnityEngine.UIElements;

public class HairPicker : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private SpriteCollection hairSprites;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnHairUpdated;

    private Sprite currentSprite;
    private int spriteIndex;
    private VisualElement root;
    private int spriteCollectionLength;

    private void Start()
    {
        InitListeners();
        spriteCollectionLength = hairSprites.Sprites.Length;
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var hairContainer = root.Q<VisualElement>("Hair");

        var hairPrevious = hairContainer.Q<Button>("Previous");
        var hairNext = hairContainer.Q<Button>("Next");

        spriteIndex = 0;
        UpdatePlayerSprite();

        hairPrevious.clicked += Handle_HairPrevious;
        hairNext.clicked += Handle_HairNext;
    }

    private void Handle_HairNext()
    {
        if (spriteCollectionLength < 2) { return; }
        spriteIndex++;
        if (spriteIndex >= spriteCollectionLength) 
        { 
            spriteIndex = 0;
        }
        UpdatePlayerSprite();
    }

    private void Handle_HairPrevious()
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
        currentSprite = hairSprites.Sprites[spriteIndex];
        playerArt.Hair = currentSprite;
        OnHairUpdated?.Invoke();
    }
}
