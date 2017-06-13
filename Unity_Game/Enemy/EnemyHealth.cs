using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : MonoBehaviour {
    public int EHealth = 1;
    public GameObject Death;
    GameUI UI;
    BulletMovement bulletdmg;

    // Use this for initialization
    void Start () {
        UI = GameObject.Find("GameManagerUI").GetComponent<GameUI>();
        EHealth += UI.ex;
    }
	
	// Update is called once per frame
	void Update () {
        if (EHealth <= 0)
        {
            PlayDeath();
            UI.numbD++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TurretBullet"))
        {
            Destroy(other.gameObject);
            EHealth-=UI.getdmg;
        }
        if (other.tag == "PlayerBase")
        {
            UI.conquerpercent += 10;
            Destroy(gameObject);
        }
    }

    void PlayDeath()
    {
        GameObject explosion = (GameObject)Instantiate(Death);

        explosion.transform.position = transform.position;
    }
}
