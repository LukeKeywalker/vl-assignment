using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCubeBrain : BaseEnemyBrain
{
    protected override IEnumerator ActionCoroutine()
    {
        while(true) 
        {
            yield return controller.MakeStep(StepDirection.Forward);
        }
    }
}
