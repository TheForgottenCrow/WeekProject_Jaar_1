using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ActiveOBJ;
    [SerializeField]
    private GameObject m_InActiveOBJ;
    
    //public Sprite m_ActiveSPRITE;
    //public Sprite m_InActiveSPRITE;
    //private SpriteRenderer m_checkpointSpriteRenderer;
    public bool m_checkpointReached;

    void Start ()
    {
        
        m_ActiveOBJ.SetActive(false);
        m_InActiveOBJ.SetActive(true);
        
        //m_checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
	}	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Player"))
        {
            
            m_ActiveOBJ.SetActive(true);
            m_InActiveOBJ.SetActive(false);
            
            //m_checkpointSpriteRenderer.sprite = m_ActiveSPRITE;
            m_checkpointReached = true;
        }
    }
}
