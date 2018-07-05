using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private Animator m_Animator;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (m_Animator.GetInteger("State") == 0)
            {
                SetAnimationState(1);
            }
            else
            {
                SetAnimationState(2);
            }
        }
            
        
    }

    public void SetAnimationState(int state)
    {
        m_Animator.SetInteger("State", state);
    }
}
