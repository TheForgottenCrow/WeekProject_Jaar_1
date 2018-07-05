using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

    [SerializeField]
    private GameObject m_HandPointer;
    
    [SerializeField]
    private List<GameObject> m_HandPositions;

    private Transform m_Destination;

    private void Update()
    {
        m_HandPointer.transform.position = Vector2.Lerp(m_HandPointer.transform.position, m_Destination.position, 0.1f);
    }


    public void SetHandPos(int pos)
    {
        m_Destination = m_HandPositions[pos].transform;
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }
}
