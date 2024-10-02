using OWL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attacker : GenericBehaviour
{
    public static Player_Attacker instance;

    private Animator anim;
    private int hasAttackCounter = Animator.StringToHash("AttackCounter");

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        TryGetComponent(out anim);
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Skill_01");
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public int AttackCount
    {
        get => anim.GetInteger(hasAttackCounter);
        set => anim.SetInteger(hasAttackCounter, value);
    }
}
