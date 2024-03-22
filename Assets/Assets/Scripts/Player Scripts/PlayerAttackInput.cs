using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimations;
    private bool canAttack;
    public GameObject attackPoint;
    private PlayerShieldScript shieldScript;
    void Awake()
    {
        playerAnimations = GetComponent<CharacterAnimations>();
        shieldScript = GetComponent<PlayerShieldScript>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Z))                          // Defend
        {
            playerAnimations.Defend(true);
            shieldScript.ActivateShield(true);
        }
        if(Input.GetKeyUp(KeyCode.Z))
        {
            playerAnimations.UnFreezeAnimation();
            playerAnimations.Defend(false);
            shieldScript.ActivateShield(false);
        }
        if(Input.GetKeyDown(KeyCode.X))                         // Attack
        {
            if(Random.Range(0, 2) > 0)
            {
                playerAnimations.Attack1();
            }
            else
            {
                playerAnimations.Attack2();
            }
        }
    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if(attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }

}
