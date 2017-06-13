using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {
    SpawnEnemy reset;
    // Use this for initialization
    void Start()
    {
        reset = gameObject.AddComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Restart()
    {
        reset.E = 0;
        SceneManager.LoadScene("Level 1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("start");
    }
}
