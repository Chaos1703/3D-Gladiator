using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    public bool isPlayer;
    [SerializeField]private Image healthBar;
    [HideInInspector]public bool shieldActivated;

    public void ApplyDamage(float damage)
    {
        if (shieldActivated)
        {
            return;
        }
        health -= damage;
        if(healthBar != null)
        {
            healthBar.fillAmount = health / 100f;
        }
        if (health <= 0)
        {
            health = 0;
            if (isPlayer)
            {
                // Player is dead
                GetComponent<PlayerMovementScript>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;
                GameObject.FindWithTag("Enemy").GetComponent<EnemyController>().enabled = false;
            }
            else
            {
                // Enemy is dead
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().isStopped = true;
            }
            gameObject.SetActive(false);
        }
    }
}
