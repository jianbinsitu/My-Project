using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject[] DisplayWhenPaused;
    public GameObject[] DisplayWhenResumed;
    public GameObject[] Displayslider;
    // Use this for initialization
    void Start() {
        DisplayWhenPaused = GameObject.FindGameObjectsWithTag("WhenPause");
        foreach (GameObject dp in DisplayWhenPaused)
            dp.SetActive(false);

        DisplayWhenResumed = GameObject.FindGameObjectsWithTag("WhenResume");
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);

        Displayslider = GameObject.FindGameObjectsWithTag("music");
        foreach (GameObject slider in Displayslider)
            slider.SetActive(false);
        

    }

// Update is called once per frame
void Update () {
	
	}

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        //pauseText.SetActive (true);
        foreach (GameObject dp in DisplayWhenPaused)
            dp.SetActive(true);
        foreach (GameObject dp in DisplayWhenResumed)
            dp.SetActive(false);



    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        //pauseText.SetActive (false); 
        foreach (GameObject dp in DisplayWhenPaused)
            dp.SetActive(false);
        foreach (GameObject dp in DisplayWhenResumed)
            dp.SetActive(true);


    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("start");
    }

    public void Volume()
    {
        foreach (GameObject slider in Displayslider)
            slider.SetActive(true);
        foreach (GameObject dp in DisplayWhenPaused)
            dp.SetActive(false);
    }

    public void returnisclick()
    {
        foreach (GameObject dp in DisplayWhenPaused)
            dp.SetActive(true);

        foreach (GameObject slider in Displayslider)
            slider.SetActive(false);

    }
}
