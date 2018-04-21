using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_MainMenu : B_Base {

    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private string _startLevel;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void StartGame()
    {
        StartCoroutine(SC_Game.Instance.Scenes.TransitionToScene(_startLevel));
    }
}
