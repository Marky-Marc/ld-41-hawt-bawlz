using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Level_01 : B_Base {

    [SerializeField]
    private GameObject _golfBall;
    [SerializeField]
    private GameObject _hud;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        StartCoroutine(UpdateUI());
	}
    IEnumerator UpdateUI()
    {
        if (SC_Game.Instance.PlayActive)
        {
            var hudController = _hud.GetComponent<SC_HUD>();
            var currentBallHealth = _golfBall.GetComponent<B_GolfBall>().CurrentHealth;
            hudController.UpdateBallHealth(currentBallHealth);
            hudController.UpdateCurrentScore(currentBallHealth, _scoreMultiplier);
        }
        yield return null;
    }
}
