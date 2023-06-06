using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Sword;

    public bool CanAttack = true;

    public float AttackCooldown = 1.0f;

    public bool IsAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttacking());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }
    
    IEnumerator ResetAttacking()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
}
