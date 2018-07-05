using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformspawener : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceHeight;

    [SerializeField] GameObject Spawnpoint;
    [SerializeField] GameObject Platform2;
    [SerializeField] GameObject nextSpawnpoint;

    private GameObject lastSpawnpoint;

    private float platformWidth;
    private float platformLength;

    public float distanceBetweenMinLength;
    public float distanceBetweenMaxLength;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private List<GameObject> Platforms;

	// Use this for initializationx
	void Start () {
        Platforms = new List<GameObject>();
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformLength = thePlatform.GetComponent<BoxCollider2D>().size.y;
        for (int i = 0; i < 10; i++)
        {
            GameObject iets;
            iets = Instantiate(thePlatform, transform.position, transform.rotation);
            Platforms.Add(iets);
            iets.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        //if(Camera.main.transform.position.x > Spawnpoint.transform.position.x)
        //{
            

            
            
        //}
        
	}
    public void Nextplatform ()
    {
        distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
        distanceHeight = Random.Range(distanceBetweenMinLength, distanceBetweenMaxLength);
        for (int i = 0; i < Platforms.Count; i++)
        {
            if (!Platforms[i].activeInHierarchy)
            {
                Platforms[i].SetActive(true);
                Platforms[i].transform.position = new Vector3(generationPoint.transform.position.x + platformWidth + distanceBetween, Spawnpoint.transform.position.y + platformLength + distanceHeight, generationPoint.transform.position.z);

                break;

            }
        }
    }
}
