using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string fact;
    public bool istrue;
}

public class RandomResources : MonoBehaviour {
    public Question[] question;
    private static List<Question> unanswer;
    private Question current;
    private float x;
    private float y;
    private float minx = -10;
    private float miny = -6;
    private float maxX = 11;
    private float maxY = 4;
    public GameObject resources;
    private GameUI UI;
    public GameObject[] quest;
    GameObject[] correct;
    GameObject[] wrong;

    [SerializeField]
    private Text QuestionText;

    void Start()
    {
        correct = GameObject.FindGameObjectsWithTag("correct");
        wrong = GameObject.FindGameObjectsWithTag("wrong");
        foreach (GameObject c in correct)
        {
            c.SetActive(false);
        }
        foreach (GameObject w in wrong)
        {
            w.SetActive(false);
        }
        quest = GameObject.FindGameObjectsWithTag("question");
        InvokeRepeating("Spawn", 10f, 5f);
        UI = GameObject.Find("GameManagerUI").GetComponent<GameUI>();
        /*if (unanswer == null || unanswer.Count == 0)
        {
            unanswer = question.ToList<Question>();
        }*/

        quest = GameObject.FindGameObjectsWithTag("question");
        foreach (GameObject q in quest)
        {
            q.SetActive(false);
        }
    }

    void Update()
    {
        x = Random.Range(minx, maxX);
        y = Random.Range(miny, maxY);

        if (unanswer == null || unanswer.Count == 0)
        {
            unanswer = question.ToList<Question>();
        }
    }
    void Spawn()
    {
        resources.SetActive(true);
        Vector2 position = new Vector2(x, y);
        Instantiate(resources, position, Quaternion.identity);
    }

    public void SetCurrentQuestion()
    {
        int randomindex = Random.Range(0, unanswer.Count);
        current = unanswer[randomindex];

        QuestionText.text = current.fact;

        unanswer.RemoveAt(randomindex);
    }

    public void SelectTrue()
    {
        if (current.istrue)
        {
            UI.resources += 100;
            foreach (GameObject q in quest)
            {
                q.SetActive(false);
            }
            foreach (GameObject c in correct)
            {
                c.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject q in quest)
            {
                q.SetActive(false);
            }
            foreach (GameObject w in wrong)
            {
                w.SetActive(true);
            }
        }
    }

    public void SelectFalse()
    {
        if (!current.istrue)
        {
            UI.resources += 100;
            foreach (GameObject q in quest)
            {
                q.SetActive(false);
            }
            foreach (GameObject c in correct)
            {
                c.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject q in quest)
            {
                q.SetActive(false);
            }
            foreach (GameObject w in wrong)
            {
                w.SetActive(true);
            }
        }
    }

    public void correctcontinueselect()
    {
        foreach (GameObject c in correct)
        {
            c.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }

    public void wrongcontinueselect()
    {
        foreach (GameObject w in wrong)
        {
            w.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }
}
