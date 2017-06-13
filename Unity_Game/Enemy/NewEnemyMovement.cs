using UnityEngine;
using System.Collections;

public class NewEnemyMovement : MonoBehaviour {
    public float speed = -2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.deltaTime * speed, 0, 0);
	}
}
