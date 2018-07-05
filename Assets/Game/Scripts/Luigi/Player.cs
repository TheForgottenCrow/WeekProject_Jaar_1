using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float m_PlayerHealth;
    public Vector3 respawnPoint;
    [SerializeField]
    private Image m_HealthBar;

    void Start ()
    {
        m_PlayerHealth = 3;
        respawnPoint = transform.position;
    }
	void Update ()
    {
        m_HealthBar.fillAmount = m_PlayerHealth / 3f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GetDamaged();
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
        }
    }
    private void GetDamaged()
    {
        m_PlayerHealth -= 1;
        if (m_PlayerHealth > 0)
        {
            ReturntoCheckpoint();
        }
        if (m_PlayerHealth <= 0)
        {
            Die();
        }
    }

    private void ReturntoCheckpoint()
    {
        this.transform.position = respawnPoint;
    }
    private void Die()
    {
        SceneManager.LoadScene(2);
    }
}
