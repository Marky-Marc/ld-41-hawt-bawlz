using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Level_03 : B_Base
{

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
    void Update()
    {
        StartCoroutine(CheckBallSunk());
        StartCoroutine(UpdateUI());
    }
    IEnumerator CheckBallSunk()
    {
        if (SC_Game.Instance.BallSunk && SC_Game.Instance.PlayActive)
        {
            var ballSunkParticles = Resources.Load<GameObject>($"Prefabs/BallSunkParticles");
            var flag = GameObject.FindGameObjectWithTag("Flag");
            Instantiate(ballSunkParticles, flag.transform);
            SC_Game.Instance.SetPlayActive(false);
            var currentBallHealth = _golfBall.GetComponent<B_GolfBall>().CurrentHealth;
            SC_Game.Instance.IncrementTotalScore(currentBallHealth * _scoreMultiplier);
            Destroy(_golfBall);

            yield return SC_Game.Instance.Scenes.TransitionToScene("S_ScoreSubmission");

        }
        yield return null;
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
