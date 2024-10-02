using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    State_Pursue pursueState;

    private void Awake()
    {
        pursueState = GetComponent<State_Pursue>();
    }

    public override State Tick(Enemy_Manager enemy_Manager)
    {
        Debug.Log("Melee_Attack!");
        if (enemy_Manager.distanceFromCurrentTarget >= enemy_Manager.minAttackDistance + 1)
        {
            enemy_Manager.anim.SetBool("Attack", false);
            return pursueState;
        }
        else
        {
            enemy_Manager.anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
            enemy_Manager.anim.SetBool("Attack", true);
            return this;
        }

    }
}
