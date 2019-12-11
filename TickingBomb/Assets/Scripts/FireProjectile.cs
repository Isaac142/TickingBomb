using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject projectile;

    public bool canThrow;

    private void Start()
    {
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ThrowCrumb();
            //Instantiate(projectile, firingPoint.position, firingPoint.rotation);
        }
        
    }

    void ThrowCrumb()
    {
        if (canThrow)
        {
            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
            StartCoroutine(ThrowingCrumbsDelay());
        }
    }

    IEnumerator ThrowingCrumbsDelay()
    {
        canThrow = false;
        yield return new WaitForSeconds(2f);
        canThrow = true;
    }
}
