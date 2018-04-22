using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using UnityEngine;

public class SC_Game : MonoBehaviour {

    [HideInInspector]
    public SC_HUD HUD => GetComponent<SC_HUD>();
    [HideInInspector]
    public SC_Scenes Scenes => GetComponent<SC_Scenes>();
    [HideInInspector]
    public SC_Player MainPlayer => GetComponent<SC_Player>();

    public static SC_Game Instance;

    #region Game State Properties
    private bool _playActive = true;
    public bool PlayActive => _playActive;
    private bool _ballSunk = false;
    public bool BallSunk => _ballSunk;
    private float _totalScore = 0.0f;
    public float TotalScore => _totalScore;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetPlayActive(bool active) => _playActive = active;
    public void SetBallSunk(bool sunk) => _ballSunk = sunk;
    public void IncrementTotalScore(float score) => _totalScore += score;
    public void StartLevel()
    {
        _playActive = true;
        _ballSunk = false;
    }

    public void SubmitHighScore(string name)
    {
        var url = $"http://dreamlo.com/lb/og5ikfSV-0aAxhRcgAFzsg1MW8_IuowkmjDgs_lZl2qA/add/{name}/{_totalScore}";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.GetResponse();
    }
    public void Reset()
    {
        _totalScore = 0;
    }
}
