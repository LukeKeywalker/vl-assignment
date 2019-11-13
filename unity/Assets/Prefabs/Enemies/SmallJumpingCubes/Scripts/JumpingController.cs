using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class JumpingController : MonoBehaviour
{
    private new Collider collider;
    private new Rigidbody rigidbody;
    public bool inAir = false;
    private WaitForSeconds cooldown;
    private WaitForEndOfFrame nextFrame;

    void Awake()
    {
        cooldown = new WaitForSeconds(0.25f);
        nextFrame = new WaitForEndOfFrame();
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }
    public IEnumerator Jump()
    {
        while (inAir) yield return nextFrame;

        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * 17f, ForceMode.Impulse);
        inAir = true;
        while (inAir) yield return nextFrame;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            inAir = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            inAir = true;
        }
    }
}
