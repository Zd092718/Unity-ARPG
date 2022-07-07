using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float projectileSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(0, 0, projectileSpeed * Time.deltaTime);
    }
}
