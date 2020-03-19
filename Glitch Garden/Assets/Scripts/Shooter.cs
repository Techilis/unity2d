using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackSpawner myLaneSpawner;
    Animator animator;

    // Can add input parameter which will appear as SerializeField in Unity event

    private void Start()
    {
        SetLaneSpawner();
        // because shooter is same level as Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackSpawner[] spawners = FindObjectsOfType<AttackSpawner>();
        foreach (AttackSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner)
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public void Fire()
    {
        // Can use Quarternion.identity as opposed to transform.rotation
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
