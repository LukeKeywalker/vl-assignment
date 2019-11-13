
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "Enemy Movement Config", menuName = "Core Gameplay/Movement Config")]
public class MovementConfig : ScriptableObject
{
    [SerializeField]
    public float stepDuration;

    [SerializeField]
    public float stepCooldown;

    [SerializeField]
    public float ForceMultiplier;

    [SerializeField]
    public float RotateSpeed;
}
