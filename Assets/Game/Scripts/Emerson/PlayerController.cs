using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    windup,
    walking,
    jumping
}

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;
    public int playerState;

    public float m_PlayerHealth;
    public Vector3 respawnPoint;

    private PlayerState state;

    //[SerializeField]
    private Image m_HealthBar;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        m_PlayerHealth = 1;
        respawnPoint = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetInteger("State", (int)state);

        if (grounded)
        {
            state = PlayerState.windup;
        }
        
        if (!grounded)
        {
            state = PlayerState.jumping;
        }
        
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
