using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamoverScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            SceneManager.LoadScene(8);
        }
    }
}
