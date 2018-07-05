using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFloorMovement : MonoBehaviour
{
    private float m_speed = -10;

    private Rigidbody2D m_RigidBody;

    void Start ()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }
	void Update ()
    {
        m_RigidBody.velocity = new Vector2(m_speed, 0);
    }
}
