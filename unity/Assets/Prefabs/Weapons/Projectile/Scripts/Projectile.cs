using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    new private Rigidbody rigidbody;
    private WaitForSeconds destroyAfter = new WaitForSeconds(0.5f);

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    public void Fire(Vector3 direction)
    {
        rigidbody.velocity = direction * 150;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return destroyAfter;
        Destroy(gameObject);
    }
}
