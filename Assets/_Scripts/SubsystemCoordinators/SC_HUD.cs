using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_HUD : MonoBehaviour {

    [SerializeField]
    private Text _ballHealth;
    [SerializeField]
    private Text _currentScore;
    [SerializeField]
    private Button _closeHelp;
    // Use this for initialization
    void Start () {
        if (_closeHelp)
        {
            _closeHelp.onClick.AddListener(CloseHelp);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CloseHelp()
    {
        var helpPanel = GameObject.FindGameObjectWithTag("Help");
        Destroy(helpPanel);
    }

    public void UpdateBallHealth(float currentHealth)
    {
        _ballHealth.text = $"Ball Health: {currentHealth}";
    }
    public void UpdateCurrentScore(float currentHealth, float multiplier)
    {
        _currentScore.text = $"Current Score: {currentHealth * multiplier}";
    }
}
