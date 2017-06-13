using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int health = 100;
    private GameUI UI;
    public GameObject Lose;

	void Start () {
	
	}
	
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health--;
            other.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                UI.GameOver = true;
                PlayLose();
            }

        }
    }

    void PlayLose()
    {
        GameObject lose = (GameObject)Instantiate(Lose);

        lose.transform.position = transform.position;
    }
}
