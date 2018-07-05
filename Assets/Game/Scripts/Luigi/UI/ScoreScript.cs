using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;

    private Text score;
    private float scorePercentage = 0;
    private int scoreValue = 0;
    private int HighScoreValue = 0;
    
    private bool m_IsAlive;
    private float Health;

    void Start()
    {
        score = GetComponent<Text>();
        m_IsAlive = true;
    }
    void Update()
    {
        Health = m_Player.GetComponent<Player>().m_PlayerHealth;
        if (Health <= 0)
        {
            m_IsAlive = false;
        }
        
        if (Health >= 0.1f)
        {
            scorePercentage += 1f * Time.deltaTime;
        }
        if (scorePercentage >= 1f)
        {
            scoreValue += 10;
            scorePercentage = 0f;
        }
        score.text = "Score: " + scoreValue;
    }
}
