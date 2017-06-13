using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TurretLevel
{
    public int cost;
    public GameObject prefab;
}

public class Turretdata : MonoBehaviour {
    public List<TurretLevel> levels;
    private TurretLevel currentLevel;

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    void Update () {
	
	}

    public TurretLevel CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelprefab = levels[currentLevelIndex].prefab;

            for(int i = 0; i < levels.Count; i++)
            {
                if(levelprefab != null)
                {
                    if(i == currentLevelIndex)
                    {
                        levels[i].prefab.SetActive(true);
                    }
                    else
                    {
                        levels[i].prefab.SetActive(false);
                    }
                }
            }
        }
    }

    public TurretLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void increaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}
