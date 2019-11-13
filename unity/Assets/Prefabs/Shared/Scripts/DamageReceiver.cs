using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DamageReceiver : MonoBehaviour
{
    public float health;
    public MaxHealth maxHealth;

    public bool keepAliveWhenZero;

    public float healthNormalized { get { return health / maxHealth.value; } }
    
    void Start()
    {
        health = maxHealth.value;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "damager" && collision.collider.gameObject.layer != gameObject.layer)
        {
            Damager damager = collision.collider.gameObject.GetComponent<Damager>();

            DealDamageWith(damager);
            if (damager.destroyOnDelivery) 
                Destroy(damager.gameObject);
        }
    }

    void DealDamageWith(Damager damager) {
        health = Mathf.Clamp(health - damager.damage.value, 0, maxHealth.value);
        if (healthNormalized <= 0 && keepAliveWhenZero == false)
        {
            Destroy(gameObject);
        }
    }
}
