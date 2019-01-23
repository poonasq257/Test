using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighting : MonoBehaviour {
    public bool isHighlighted;
    private SkinnedMeshRenderer meshRenderer;
    private Material originMaterial;
    public Material replaceMaterial;

    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        originMaterial = meshRenderer.materials[0];
        if (!replaceMaterial) replaceMaterial = originMaterial;
    }

    void Update()
    {
        if (isHighlighted) meshRenderer.material = replaceMaterial;
        else meshRenderer.material = originMaterial;
    }
}
