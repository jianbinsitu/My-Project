using UnityEngine;
using System.Collections;

public class TurretPlacement : MonoBehaviour {
    private GameUI gameManager;
    public GameObject turretPrefab;
    private GameObject turret;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManagerUI").GetComponent<GameUI>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    bool PlaceAva()
    {
        int cost = turretPrefab.GetComponent<Turretdata>().levels[0].cost;
        return turret == null && gameManager.resources >= cost;
    }

    bool UpgradeAva()
    {
        if (turret != null)
        {
            Turretdata turretData = turret.GetComponent<Turretdata>();
            TurretLevel nextLevel = turretData.getNextLevel();

            if (nextLevel != null)
            {
                return gameManager.resources >= nextLevel.cost;
            }
        }
        return false;
    }

    void OnMouseUp()
    {
        if (PlaceAva())
        {
            turret = (GameObject)Instantiate(turretPrefab);
            turret.transform.position = new Vector2(transform.position.x, transform.position.y + 0.7f);
            gameManager.resources -= turret.GetComponent<Turretdata>().CurrentLevel.cost;
        }
        else if (UpgradeAva())
        {
            turret.GetComponent<Turretdata>().increaseLevel();
            gameManager.resources -= turret.GetComponent<Turretdata>().CurrentLevel.cost;
        }
    }
}
