using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SkinPicker : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private SpriteCollection skinSprites;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnSkinUpdated;

    private int spriteIndex;
    private VisualElement root;
    private int spriteCollectionLength;

    private void Start()
    {
        InitListeners();
        spriteCollectionLength = skinSprites.Sprites.Length;
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var skinContainer = root.Q<VisualElement>("Skin");

        var skinPrevious = skinContainer.Q<Button>("Previous");
        var skinNext = skinContainer.Q<Button>("Next");

        spriteIndex = 0;
        UpdatePlayerSprite();

        skinPrevious.clicked += Handle_SkinPrevious;
        skinNext.clicked += Handle_SkinNext;
    }

    private void Handle_SkinNext()
    {
        if (spriteCollectionLength < 2) { return; }
        spriteIndex++;
        if (spriteIndex >= spriteCollectionLength) 
        { 
            spriteIndex = 0;
        }
        UpdatePlayerSprite();
    }

    private void Handle_SkinPrevious()
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
        playerArt.Skin = skinSprites.Sprites[spriteIndex];
        OnSkinUpdated?.Invoke();
    }
}