using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringForCats : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skin;

    public void SetMaterialSkin(Material material)
    {
        _skin.material = material;
    }
}
