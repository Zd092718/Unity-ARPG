using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] bool isHoming = false;
    [SerializeField] GameObject hitImpact = null;
    Health target = null;
    float damage = 0f;


    private void Start()
    {
        transform.LookAt(GetAimLocation());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (isHoming && !target.IsDead())
        {
            transform.LookAt(GetAimLocation());
        }
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    public void SetTarget(Health target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * targetCapsule.height / 1.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target)
        {
            return;
        }
        if (target.IsDead())
        {
            return;
        }
        target.TakeDamage(damage);
        if (hitImpact != null)
        {
            Instantiate(hitImpact, GetAimLocation(), transform.rotation);

        }
        Destroy(gameObject);
    }


}
