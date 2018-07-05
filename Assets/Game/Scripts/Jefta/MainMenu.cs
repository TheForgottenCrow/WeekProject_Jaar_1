using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum e_MenuState
{
    Passport_Idle = 0,
    Passport_Open,
    Passport_OpenIdle,
    Passport_HowToPlay_Open,
    Passport_HowToPlay_close,
    Passport_Settings_Open,
    Passport_Settings_close,
    Passport_Credits_Open,
    Passport_Credits_close,
    Passport_Stamp


}

public class MainMenu : MonoBehaviour {

    [SerializeField]
    GameObject m_MainPanel, m_HowToPlayPanel, m_SettingsPanel, m_CreditsPanel;

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
                SetAnimationState(e_MenuState.Passport_Open);
            }
        }

        m_HandPointer.transform.position= Vector2.Lerp(m_HandPointer.transform.position, m_Destination.position, 0.1f);

    }

    // Level Loader
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }


    // Animation Handler
    public void SetAnimationState(e_MenuState state)
    {
        m_Animator.SetInteger("State", (int)state);
    }


    // Set HandPosition to New Position
    public void SetHandPos(int pos)
    {
        Debug.Log("lerp");
        m_Destination = m_HandPositions[pos].transform;
    }

    // Animation event
    public void ActivateMenu()
    {
        m_MenuPanel.SetActive(true);
        m_Destination = m_HandPositions[1].transform;
    }

    //Buttons
    public void ButtonStart()
    {
        SetAnimationState(e_MenuState.Passport_Stamp);
        DeactivatePanels();
    }
    public void ButtonHowToPlay()
    {
        SetAnimationState(e_MenuState.Passport_HowToPlay_Open);
        DeactivatePanels();
        m_HowToPlayPanel.SetActive(true);
    }
    public void ButtonSetting()
    {
        SetAnimationState(e_MenuState.Passport_Settings_Open);
        DeactivatePanels();
        m_SettingsPanel.SetActive(true);
    }
    public void ButtonCredits()
    {
        SetAnimationState(e_MenuState.Passport_Credits_Open);
        DeactivatePanels();
        m_CreditsPanel.SetActive(true);
    }

    public void Back(int menuState)
    {
        DeactivatePanels();
        m_MainPanel.SetActive(true);

        switch ( (e_MenuState)menuState)
        {
            
            case e_MenuState.Passport_HowToPlay_close:
                SetAnimationState(e_MenuState.Passport_HowToPlay_close);
                break;
           
            case e_MenuState.Passport_Settings_close:
                SetAnimationState(e_MenuState.Passport_Settings_close);
                break;
      ;
            case e_MenuState.Passport_Credits_close:
                SetAnimationState(e_MenuState.Passport_Credits_close);
                break;
            
            default:
                break;
        }
    }

    public void ButtonExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }



// Deactivates all panels
public void DeactivatePanels()
    {
        m_MainPanel.SetActive(false);
        m_HowToPlayPanel.SetActive(false);
        m_SettingsPanel.SetActive(false);
        m_CreditsPanel.SetActive(false);
    }



}




