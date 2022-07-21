using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Attributes;
using UnityEngine;


namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float projectileSpeed = 5f;
        [SerializeField] bool isHoming = false;
        [SerializeField] GameObject hitImpact = null;
        [SerializeField] float maxLifetime = 10f;
        [SerializeField] GameObject[] destroyOnHit = null;
        [SerializeField] float lifeAfterImpact = 2f;
        Health target = null;
        GameObject instigator = null;
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

        public void SetTarget(Health target, GameObject instigator, float damage)
        {
            this.target = target;
            this.damage = damage;
            this.instigator = instigator;

            Destroy(gameObject, maxLifetime);
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
            target.TakeDamage(instigator, damage);

            projectileSpeed = 0f;
            if (hitImpact != null)
            {
                Instantiate(hitImpact, GetAimLocation(), transform.rotation);

            }

            foreach (GameObject toDestroy in destroyOnHit)
            {
                Destroy(toDestroy);
            }
            Destroy(gameObject, lifeAfterImpact);

        }


    }

}
