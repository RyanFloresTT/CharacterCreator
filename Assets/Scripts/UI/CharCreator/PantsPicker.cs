using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PantsPicker : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private SpriteCollection pantsSprites;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnPantsUpdated;

    private int spriteIndex;
    private VisualElement root;
    private int spriteCollectionLength;

    private void Start()
    {
        InitListeners();
        spriteCollectionLength = pantsSprites.Sprites.Length;
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var pantsContainer = root.Q<VisualElement>("Pants");

        var pantsPrevious = pantsContainer.Q<Button>("Previous");
        var pantsNext = pantsContainer.Q<Button>("Next");

        spriteIndex = 0;
        UpdatePlayerSprite();

        pantsPrevious.clicked += Handle_PantsPrevious;
        pantsNext.clicked += Handle_PantsNext;
    }

    private void Handle_PantsNext()
    {
        if (spriteCollectionLength < 2) { return; }
        spriteIndex++;
        if (spriteIndex >= spriteCollectionLength) 
        { 
            spriteIndex = 0;
        }
        UpdatePlayerSprite();
    }

    private void Handle_PantsPrevious()
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
        playerArt.Pants = pantsSprites.Sprites[spriteIndex];
        OnPantsUpdated?.Invoke();
    }
}
