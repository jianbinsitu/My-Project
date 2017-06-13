using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    void Start () {
    }


    void Update()
    {
        transform.Translate(Time.deltaTime * (2f), 0, 0);
    }
}
