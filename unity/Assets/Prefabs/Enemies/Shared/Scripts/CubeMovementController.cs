using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UnityEngineExtensions;

public enum StepDirection
{
    Forward,
    Backward,
    Left,
    Right
}

[RequireComponent(typeof(Rigidbody))]
public class CubeMovementController : MonoBehaviour
{
    public MovementConfig movementConfig;
    public Transform target;

    private new Rigidbody rigidbody;
    private new Transform transform;
    private bool isMakingStep = false;
    private Vector3 forward;
    private WaitForSeconds stepCooldown;
    private Dictionary<StepDirection, Vector3> directions;

    IEnumerator Start()
    {
        Init();
        yield return RotateTowardsTargetCoroutine();
    }

    public void Init()
    {
        StopAllCoroutines();

        isMakingStep = false;
        rigidbody.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z;

        GameObject playerObject = GameObject.Find("Player");
        target = playerObject == null? null: playerObject.transform;
        if (target != null)
        {
            forward = (target.position.xzProjection() - transform.position.xzProjection()).normalized;
            transform.forward = forward;
        }
    }

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.transform = GetComponent<Transform>();
        stepCooldown = new WaitForSeconds(movementConfig.stepCooldown);
    }

    public bool FacesTarget()
    {
        if (target == null)
            return true;

        Vector3 toTarget = target.position.xzProjection() - transform.position.xzProjection();
        float angle = Vector3.SignedAngle(forward, toTarget, Vector3.up);

        if (Mathf.Abs(angle) > 30.0f)
        {
            return false;
        }

        return true;
    }

    void Update()
    {
    }

    private IEnumerator RotateTowardsTargetCoroutine()
    {
        while (!FacesTarget() && target != null)
        {
            var direction = (target.position - transform.position).xzProjection().normalized;
            forward = Vector3.Slerp(forward, direction, Time.deltaTime * movementConfig.RotateSpeed);
            rigidbody.transform.forward = forward;
            yield return null;
        }
    }

    public IEnumerator MakeStep(StepDirection direction)
    {
        if (isMakingStep) yield return null;
        else 
        {
            Vector3 axis = Vector3.right;
            switch (direction)
            {
                case StepDirection.Forward:
                    axis = Vector3.Cross(forward, Vector3.down);
                    break;
                case StepDirection.Backward:
                    axis =  Vector3.Cross(forward, Vector3.up);
                    break;
                case StepDirection.Right:
                    var right = Vector3.Cross(forward, Vector3.up);
                    axis =  Vector3.Cross(right, Vector3.up);
                    break;
                case StepDirection.Left:
                    var left = Vector3.Cross(forward, Vector3.down);
                    axis =  Vector3.Cross(left, Vector3.up);
                    break;
            }
            yield return StepCoroutine(axis);
        }
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator StepCoroutine(Vector3 axis)
    {
        isMakingStep = true;
        float t = 0;
        while (t < movementConfig.stepDuration)
        {
            t += Time.deltaTime;
            rigidbody.angularVelocity += axis * movementConfig.ForceMultiplier * Time.deltaTime;
            yield return null;
        }
        isMakingStep = false;
        yield return stepCooldown;
        yield return RotateTowardsTargetCoroutine();
    }
}
