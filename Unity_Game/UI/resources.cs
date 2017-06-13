using UnityEngine;
using System.Collections;

public class resources : MonoBehaviour{
    RandomResources rand;
    GameObject[] quest;

    // Use this for initialization
    void Start () {
        rand = GameObject.Find("RandomSpawn").GetComponent<RandomResources>();
        quest = rand.quest;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseUp()
    {
        Time.timeScale = 0.0f;
        foreach (GameObject q in quest)
        {
            q.gameObject.SetActive(true);
        }
        rand.SetCurrentQuestion();
        Destroy(gameObject);        
    }
}
