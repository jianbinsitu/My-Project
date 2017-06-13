using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameUI : MonoBehaviour {
    public Text ResourceLabel;
    private int resource;
    public bool GameOver = false;
    private int wave;
    public bool youWin = false;
    public Text WaveLabel;
    public Text conquerLabel;
    private int conquer;
    public Text ScoreLabel;
    private int numberkill;
    private int dmg;
    private int extra;
    int[] arr;
    int index;

    public int ex
    {
        get
        {
            return extra;
        }

        set
        {
            extra = value;
        }
    }

    public int getdmg
    {
        get
        {
            return dmg;
        }

        set
        {
            dmg = value;
        }
    }

    public int numbD
    {
        get
        {
            return numberkill;
        }

        set
        {
            numberkill = value;
        }
    }

    public int resources
    {
        get { return resource; }
        set
        {
            resource = value;
            ResourceLabel.GetComponent<Text>().text = resource.ToString();
        }
    }

    public int conquerpercent
    {
        get
        {
            return conquer;
        }
        set
        {
            conquer = value;
            conquerLabel.GetComponent<Text>().text = conquer.ToString();
        }
    }

    public int Waves
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            WaveLabel.GetComponent<Text>().text = wave.ToString();
        }
    }


    void Start ()
    {
        arr = new int[16];
        Array.Clear(arr, 0, arr.Length);
        resources = 400;
        Waves = 1;
        numbD = 0;
        conquerpercent = 0;
        getdmg = 0;
        ex = 0;
    }
	void Update ()
    {
        index = Waves;
        ScoreManager.sManager.setScore(numbD);
        ScoreLabel.text = ScoreManager.sManager.getScore().ToString();
        if(conquerpercent == 100)
        {
            GameOver = true;
            SceneManager.LoadScene("gameover");
        }

        if (Waves > 2 && arr[index] == 0)
        {
            ex++;
            arr[index]+=1;
        }
	}
}
