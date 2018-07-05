using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    [SerializeField] GameObject m_player;
    [SerializeField] Platformspawener m_spawner;
    [SerializeField] GameObject m_destroyer;
    private bool m_CanSpawn;
	void Start () {
        m_player = GameObject.Find("Player");
        m_spawner = GameObject.Find("PlatformGenerator").GetComponent<Platformspawener>();
        m_destroyer = GameObject.Find("PlatformDestructionPoint");
        m_CanSpawn = true;
    }

    // Update is called once per frame
    void Update () {
        if (m_player.transform.position.x > transform.position.x && m_CanSpawn == true)
        {
            m_spawner.Nextplatform();
            m_CanSpawn = false;
        }
        if(m_destroyer.transform.position.x > transform.position.x)
        {
            m_CanSpawn = true;
            this.gameObject.SetActive(false);
        }
	}
}
