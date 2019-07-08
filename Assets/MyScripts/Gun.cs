using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float range = 100f;

    [SerializeField]
    private Camera fpsCam;

    [SerializeField]
    private LayerMask layerMaskShootable;

    [SerializeField]
    private float nextTimeToShoot = 0f;

    [SerializeField]
    private float shootRate = 15f;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private GameObject impact;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f / shootRate;
            muzzleFlash.SetActive(true);
            Shoot();
        }

        else
            muzzleFlash.SetActive(false);
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMaskShootable.value))
        {
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
