using UnityEngine;
using System.Collections;
//use to detect enemy position, so when enemy
//walk past the soldier, it will flip
public class Enemyposition : MonoBehaviour {
    GameObject enemy;
    bool FaceLeft = true;

	void Start () {
	}
	
	void Update () {    
	}

    void Flip()
    {
        Vector3 playerscale = transform.localScale;
        playerscale.x = playerscale.x * -1;
        transform.localScale = playerscale;
        FaceLeft = !FaceLeft;
    }
}
