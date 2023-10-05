using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBoltShooter : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject manaBoltPrefab;
    [SerializeField] private Transform boltSpawnPoint;

    public void Attack()
    {
        GameObject newManaBolt = Instantiate(manaBoltPrefab, boltSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        newManaBolt.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
