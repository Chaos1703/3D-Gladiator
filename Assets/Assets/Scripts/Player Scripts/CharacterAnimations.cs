using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool("Walk", walk);
    }

    public void Defend(bool defend)
    {
        anim.SetBool("Defend", defend);
    }

    public void Attack1()
    {
        anim.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        anim.SetTrigger("Attack2");
    }

    public void FreezeAnimation()
    {
        anim.speed = 0f;
    }

    public  void UnFreezeAnimation()
    {
        anim.speed = 1f;
    }
}
