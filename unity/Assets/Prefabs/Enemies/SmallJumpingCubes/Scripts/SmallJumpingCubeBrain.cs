using System.Collections;
using UnityEngine;

[RequireComponent(typeof(JumpingController))]
public class SmallJumpingCubeBrain : BaseEnemyBrain
{
    JumpingController jumpingController;
    protected override void Awake()
    {
        base.Awake();
        jumpingController = GetComponent<JumpingController>();
    }

    protected override IEnumerator ActionCoroutine()
    {
        while (true)
        {
            yield return WalkRandomSteps();
            yield return jumpingController.Jump();
        }
    }

    private IEnumerator WalkRandomSteps()
    {
        for (int i = 0; i < Random.Range(0, 6); i++) {
            yield return controller.MakeStep(StepDirection.Forward);
        }
    }
}
