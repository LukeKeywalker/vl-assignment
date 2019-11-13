using UnityEngine;
namespace Core.UnityEngineExtensions 
{
    public static class AnimationExtensions
    {
        public static void ResetCurrentClip(this Animation animation)
        {
            string name = animation.clip.name;
            AnimationState clipState = animation[name];
            clipState.normalizedTime = 0;
            animation.Play();
            animation.Sample();
            animation.Stop();
        }
    }
}