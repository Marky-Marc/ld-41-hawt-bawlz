using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_GolfBall : MonoBehaviour {

    private float _health = 100.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float CurrentHealth
    {
        get
        {
            return _health;
        }
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
        StartCoroutine(SC_Game.Instance.Scenes.TransitionToScene("S_MainMenu"));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hole")
        {
            StartCoroutine(SC_Game.Instance.Scenes.TransitionToScene("S_MainMenu"));
        }
    }
}
