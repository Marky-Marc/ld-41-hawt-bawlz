using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(BeginTimedExit());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator BeginTimedExit()
    {
        yield return new WaitForSecondsRealtime(0.0f);
        yield return SC_Game.Instance.Scenes.TransitionToScene("S_MainMenu");
    }
}
