using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class HealthIndicator : MonoBehaviour
{
    public Color deadColor;
    public Color healthyColor;
    public DamageReceiver damageReceiver;
    private MaterialPropertyBlock baseColorMBP;
    new private Renderer renderer;
    
    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        baseColorMBP = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        baseColorMBP.SetColor("_EmissionColor", Color.Lerp(deadColor, healthyColor, damageReceiver.healthNormalized));
        renderer.SetPropertyBlock(baseColorMBP);
    }
}
