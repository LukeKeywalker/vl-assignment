using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubeMovementController))]
public abstract class BaseEnemyBrain : MonoBehaviour
{
    protected CubeMovementController controller;
    protected virtual void Awake ()
    {
        this.controller = GetComponent<CubeMovementController>();
    }

    protected virtual void Start()
    {
        StartCoroutine(ActionCoroutine());
    }

    protected abstract IEnumerator ActionCoroutine();
}
