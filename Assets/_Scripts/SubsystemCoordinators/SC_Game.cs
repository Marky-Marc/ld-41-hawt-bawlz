using System.Collections;
using System.Collections.Generic;
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
}
