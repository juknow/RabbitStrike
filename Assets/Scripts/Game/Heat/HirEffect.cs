using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HirEffect : MonoBehaviour
{
    public Material glowMaterial;
    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void OnHit()
    {
        StartCoroutine(GlowEffect());
    }



    private IEnumerator GlowEffect()
    {
        spriteRenderer.material = glowMaterial;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.material = originalMaterial;
    }

}
