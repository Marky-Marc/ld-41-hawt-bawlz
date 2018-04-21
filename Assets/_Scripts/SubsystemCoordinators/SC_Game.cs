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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
