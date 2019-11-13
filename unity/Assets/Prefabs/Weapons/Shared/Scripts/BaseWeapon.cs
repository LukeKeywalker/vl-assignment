using System.Collections;
using UnityEngine;
using Core.UnityEngineExtensions;

[RequireComponent(typeof(Animation))]
public class BaseWeapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    public Projectile projectilePrefab;
    public Transform barrel;

    private bool isFiring = false;

    new private Animation animation;

    public void OnEnable()
    {        
        isFiring = false;
        animation.ResetCurrentClip();
    }

    public void Fire()
    {
        if (isFiring) return;
        else StartCoroutine(FireCoroutine());
    }
    public IEnumerator FireCoroutine()
    {
        isFiring = true;
        for (int i = 0; i < weaponConfig.NumProjectiles; ++i)
        {
            var projectile = (Projectile)Instantiate(projectilePrefab, barrel.position, Quaternion.identity);
            projectile.Fire(Disperse(barrel.forward));
        } 
        animation.Play();
        yield return new WaitForSeconds(weaponConfig.ReloadTime);
        isFiring = false;
    }

    public Vector3 Disperse(Vector3 direction)
    {
        Vector3 a1 = Quaternion.AngleAxis(Random.Range(-weaponConfig.Dispersion / 2.0f, weaponConfig.Dispersion / 2.0f), Vector3.up) * direction;
        return Quaternion.AngleAxis(Random.Range(-weaponConfig.Dispersion / 2.0f, weaponConfig.Dispersion / 2.0f), Vector3.forward) * a1;
    }

    void Awake()
    {
        this.animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Fire();
        }
    }
}
