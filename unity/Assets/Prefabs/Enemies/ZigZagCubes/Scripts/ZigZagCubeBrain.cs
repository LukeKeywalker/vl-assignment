using System.Collections;

public class ZigZagCubeBrain : BaseEnemyBrain
{
    public ZigZagBrainConfig zigZagConfig;
    protected override IEnumerator ActionCoroutine()
    {
        while(true) 
        {
            for (int i = 0; i < zigZagConfig.ForwardStepsoOunt; i++)
            {
                yield return controller.MakeStep(StepDirection.Forward);
            }
            for (int i = 0; i < zigZagConfig.SideStepsCount; i++)
            {
                yield return controller.MakeStep(StepDirection.Left); 
            }
            for (int i = 0; i < zigZagConfig.ForwardStepsoOunt; i++)
            {
                yield return controller.MakeStep(StepDirection.Forward);
            }
            for (int i = 0; i < zigZagConfig.SideStepsCount; i++)
            {
                yield return controller.MakeStep(StepDirection.Right);
            }
        }
    }
}
