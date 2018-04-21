using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Scenes : MonoBehaviour {

    private void Awake()
    {
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator TransitionToScene(string toScene, float duration = 1.0f)
    {
        return TransitionToScene(toScene, Color.clear, Color.black, duration);
    }
    public IEnumerator TransitionToScene(string toScene, Color fromColor, Color toColor, float duration)
    {
        yield return StartCoroutine(SceneFader.Fade(fromColor, toColor, duration));
        yield return SceneManager.LoadSceneAsync(toScene);
    }
}
