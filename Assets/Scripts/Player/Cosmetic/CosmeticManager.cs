using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer skin;
    [SerializeField] SpriteRenderer hair;
    [SerializeField] SpriteRenderer shirt;
    [SerializeField] SpriteRenderer pants;
    [SerializeField] SpriteRenderer shoes;
    [SerializeField] SpriteRenderer weapon;
    [SerializeField] SpriteRenderer classAccessory;

    [SerializeField] PlayerArtAssets playerArt;

    void Start()
    {
        UpdateCosmetics();
        SkinPicker.OnSkinUpdated += UpdateCosmetics;
        HairPicker.OnHairUpdated += UpdateCosmetics;
        ShirtPicker.OnShirtUpdated += UpdateCosmetics;
        PantsPicker.OnPantsUpdated += UpdateCosmetics;
        ShoePicker.OnShoesUpdated += UpdateCosmetics;
        ClassPicker.OnClassUpdated += UpdateCosmetics;
    }

    private void UpdateCosmetics()
    {
        skin.sprite = playerArt.Skin;
        hair.sprite = playerArt.Hair;
        shirt.sprite = playerArt.Shirt;
        pants.sprite = playerArt.Pants;
        shoes.sprite = playerArt.Shoes;
        weapon.sprite = playerArt.Weapon;
        classAccessory.sprite = playerArt.ClassAccessory;
    }
}
