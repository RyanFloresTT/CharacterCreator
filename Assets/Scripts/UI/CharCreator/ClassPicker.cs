using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ClassPicker : MonoBehaviour, IPickCustomizations
{
    [SerializeField] private UIDocument document;
    [SerializeField] private ClassData[] classWeaponSprites;
    [SerializeField] private PlayerArtAssets playerArt;

    public static Action OnClassUpdated;

    private int spriteIndex;
    private int spriteCollectionLength;
    private Label classNameText;
    private Label classDescriptionText;
    private VisualElement root;
    private VisualElement classIcon;

    private void Start()
    {
        InitListeners();
        spriteCollectionLength = classWeaponSprites.Length;
    }

    public void InitListeners()
    {
        root = document.rootVisualElement;
        var classContainer = root.Q<VisualElement>("ClassPicker");

        var classPrevious = classContainer.Q<Button>("Previous");
        var classNext = classContainer.Q<Button>("Next");

        classNameText = classContainer.Q<Label>("ClassNameText");
        classIcon = classContainer.Q<VisualElement>("ClassIcon");
        classDescriptionText = classContainer.Q<Label>("ClassDescription");

        spriteIndex = 0;
        UpdatePlayerSprite();

        classPrevious.clicked += Handle_ClassPrevious;
        classNext.clicked += Handle_ClassNext;
    }

    private void Handle_ClassNext()
    {
        if (spriteCollectionLength < 2) { return; }
        spriteIndex++;
        if (spriteIndex >= spriteCollectionLength) 
        { 
            spriteIndex = 0;
        }
        UpdatePlayerSprite();
    }

    private void Handle_ClassPrevious()
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
        var chosenClass = classWeaponSprites[spriteIndex];
        classIcon.style.backgroundImage = new StyleBackground(chosenClass.UIWeaponSprite);
        playerArt.Weapon = chosenClass.PlayerWeaponSprite;
        classNameText.text = chosenClass.ClassName;
        classDescriptionText.text = chosenClass.ClassDescription;
        OnClassUpdated?.Invoke();
    }
}