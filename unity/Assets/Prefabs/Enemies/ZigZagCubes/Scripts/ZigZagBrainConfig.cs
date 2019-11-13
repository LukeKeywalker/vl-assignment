
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu (fileName = "ZigZagBrainConfig", menuName = "Core Gameplay/ZigZag Brain Config")]
public class ZigZagBrainConfig : ScriptableObject
{
    [SerializeField]
    public int SideStepsCount;

    [SerializeField]
    public int ForwardStepsoOunt;
}
