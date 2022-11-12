  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activestate;
    public PatrolState patrolState;

    public void Initialise()
    {
        // setup state default
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }

    void Start()
    {

    }

    void Update()
    {
        if (activestate != null)
        {
            activestate.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        // mengganti active state
        if(activestate != null)
        {
            activestate.Exit();
        }
        activestate = newState;

        // parameter harus tidak null
        if (activestate != null)
        {
            // setup 
            activestate.stateMachine = this;
            activestate.enemy = GetComponent<Enemy>();
            activestate.Enter();

        }
    }
}
