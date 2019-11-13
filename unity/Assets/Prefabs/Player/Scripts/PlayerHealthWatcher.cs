using UnityEngine;

[RequireComponent(typeof(DamageReceiver))]
public class PlayerHealthWatcher : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private DamageReceiver damageReceiver;

    // Start is called before the first frame update
    void Start()
    {
        damageReceiver = GetComponent<DamageReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.SetNormalizedHealth(damageReceiver.healthNormalized);
    }
}
