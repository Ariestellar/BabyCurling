using UnityEngine;
[AddComponentMenu("Rendering/Material Control")]
public class MaterialControl : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material opaque, transparent;

    void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetMask(bool value)
    {
        if (value)
        {
            meshRenderer.material = transparent;
        }
        else
        {
            meshRenderer.material = opaque;
        }
    }
}