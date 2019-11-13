using System.Collections;

public class TitanCubeBrain : BaseEnemyBrain
{
    protected override IEnumerator ActionCoroutine()
    {
        while(true) 
        {
            yield return controller.MakeStep(StepDirection.Forward);
        }
    }
}
