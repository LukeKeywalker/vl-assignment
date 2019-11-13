using UnityEngine;
using Core.SystemExtensions;

public class WeaponChanger : MonoBehaviour
{
    public BaseWeapon[] weapons;

    private int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        currentWeapon = 0;
        UpdateWeapon();
    }


    void UpdateWeapon()
    {
        if (currentWeapon >= 0 && currentWeapon < weapons.Length)
        {
            DisableWeapons();
            weapons[currentWeapon].gameObject.SetActive(true);
        }
    }

    void DisableWeapons()
    {
        weapons.ForEach(w => w.gameObject.SetActive(false));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentWeapon != 0) {
            currentWeapon = 0;
            UpdateWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeapon != 1) {
            currentWeapon = 1;
            UpdateWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentWeapon != 2) {
            currentWeapon = 2;
            UpdateWeapon();
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0){
            if(Input.GetAxis("Mouse ScrollWheel") > 0){
                currentWeapon = Mathf.Clamp(currentWeapon + 1, 0, 2);
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0){
                currentWeapon = Mathf.Clamp(currentWeapon - 1, 0, 2);
            }
            UpdateWeapon();
        }
    }
}
