using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_ScoreSubmission : B_Base
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private InputField _playerName;
    [SerializeField]
    private Button _submitButton;
    [SerializeField]
    private Button _playAgainButton;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        Cursor.visible = true;
        _submitButton.onClick.AddListener(SubmitScore);
        _playAgainButton.onClick.AddListener(PlayAgain);

        _score.text = $"Your High Score: {SC_Game.Instance.TotalScore}";
    }

    void SubmitScore()
    {
        var safePlayerName = _playerName.text.Replace("*", string.Empty);
        SC_Game.Instance.SubmitHighScore(safePlayerName);
    }
    void PlayAgain()
    {
        SC_Game.Instance.Reset();
        StartCoroutine(SC_Game.Instance.Scenes.TransitionToScene("S_Level_02"));
    }
}
