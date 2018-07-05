using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private Animator m_Animator;
    [SerializeField]
    private GameObject m_HandPointer;
    [SerializeField]
    private List<GameObject> m_HandPositions;

    private Transform m_Destination;

    [SerializeField]
    GameObject m_MenuPanel;

    private void Start()
    {
        m_MenuPanel.SetActive(false);
        m_Destination = m_HandPositions[0].transform;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (m_Animator.GetInteger("State") == 0)
            {
                SetAnimationState(1);
            }
        }

        m_HandPointer.transform.position= Vector2.Lerp(m_HandPointer.transform.position, m_Destination.position, 0.1f);

    }

    public void SetAnimationState(int state)
    {
        m_Animator.SetInteger("State", state);
    }

    public void SetHandPos(int pos)
    {
        Debug.Log("lerp");
        m_Destination = m_HandPositions[pos].transform;
    }

    public void ActivateMenu()
    {
        m_MenuPanel.SetActive(true);
        m_Destination = m_HandPositions[1].transform;
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonHowToPlay()
    {
        Debug.Log("HowToPLay");
    }
    public void ButtonSetting()
    {
        Debug.Log("Settings");
    }
    public void ButtonCredits()
    {
        Debug.Log("Credits");
    }
    public void ButtonExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }

}
