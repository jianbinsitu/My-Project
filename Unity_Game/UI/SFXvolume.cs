using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SFXvolume : MonoBehaviour {
    public float sfx;
    public static SFXvolume test;

    void Awake()
    {
        test = this;
        sfx = 1f;
    }

	public void doSfx(float value){
        sfx = value;
	}

    public float reSfx()
    {
        return sfx;
    }
}
