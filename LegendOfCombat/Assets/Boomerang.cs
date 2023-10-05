using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    public void Attack()
    {
        Debug.Log("Boomerang Attack");
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
