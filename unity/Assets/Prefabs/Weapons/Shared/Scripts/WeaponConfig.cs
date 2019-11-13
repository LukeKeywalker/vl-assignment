
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "WeaponConfig", menuName = "Core Gameplay/Weapon Config")]
public class WeaponConfig : ScriptableObject
{
    [SerializeField]
    public float ReloadTime;

    [SerializeField]
    public float NumProjectiles;

    [SerializeField]
    public float Dispersion;
}
