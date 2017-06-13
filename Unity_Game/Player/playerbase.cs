using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerbase : MonoBehaviour {
    GameUI UI;
	// Use this for initialization
	void Start () {
        UI = GameObject.Find("GameManagerUI").GetComponent<GameUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            UI.conquerpercent += 10;
        }
    }
}
