using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Base : MonoBehaviour {

    [SerializeField]
    protected float _startDuration = 2.0f;
    [SerializeField]
    protected float _scoreMultiplier = 50.0f;

    // Use this for initialization
    protected virtual void Start()
    {
        SC_Game.Instance.StartLevel();
        StartCoroutine(SceneFader.Fade(Color.black, Color.clear, _startDuration));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
