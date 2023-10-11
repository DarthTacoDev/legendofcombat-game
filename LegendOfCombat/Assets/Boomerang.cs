using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject boomerangProjectile;
    [SerializeField] private Transform boomerangSpawnPoint;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.enabled = true;
    }

    public void Attack()
    {
        spriteRenderer.enabled = false;

        GameObject boomerang = Instantiate(boomerangProjectile, boomerangSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        boomerang.GetComponent<BoomerangProjectile>().UpdateProjectileRange(weaponInfo.weaponRange);

        spriteRenderer.enabled = true;
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
