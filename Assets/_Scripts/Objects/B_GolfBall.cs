using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_GolfBall : MonoBehaviour {

    private float _health = 100.0f;
    private bool _lowHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Finish Game First
        //StartCoroutine(CheckForLowHealth());
	}

    public float CurrentHealth
    {
        get
        {
            return _health;
        }
    }
    IEnumerator CheckForLowHealth()
    {
        if (_health <= 50.0f && !_lowHealth)
        {
            _lowHealth = true;
            var blood = Resources.Load<GameObject>($"Prefabs/GolfBallBlood");
            Instantiate(blood, this.transform);
        }
        yield return null;
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0.0f)
        {
            this.Die();
        }
    }
    void Die()
    {
        var mp = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_Music>();
        mp.BallDied();
        StartCoroutine(SC_Game.Instance.Scenes.TransitionToScene("S_MainMenu"));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hole")
        {
            var mp = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_Music>();
            mp.PlayerScored();
            SC_Game.Instance.SetBallSunk(true);
        }
    }
}
