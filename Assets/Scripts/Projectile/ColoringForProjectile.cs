using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringForProjectile : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skin;

    public void SetMaterialSkin(Material newMaterial)
    {
        Material[] newMaterials = new Material[5] { newMaterial, newMaterial, newMaterial, newMaterial, newMaterial };

        _skin.materials = newMaterials;
    }
}
