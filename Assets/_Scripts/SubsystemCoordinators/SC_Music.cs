using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SC_Music : MonoBehaviour {

    [SerializeField]
    private AudioMixerSnapshot _ambient;
    [SerializeField]
    private AudioMixerSnapshot _action;
    [SerializeField]
    private AudioMixerSnapshot _score;
    [SerializeField]
    private List<AudioClip> _ballHits;
    [SerializeField]
    private AudioSource _ballHitSource;

    private float _transitionIn;
    private float _transitionOut;
    private float _quarterNote = 0.1f; 
	// Use this for initialization
	void Start () {
        _transitionIn = _quarterNote;
        _transitionOut = _quarterNote * 32;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponPickup"))
        {
            _action.TransitionTo(_transitionIn);
        }
    }

    public void PlayerScored()
    {
        _score.TransitionTo(_transitionIn);
    }
}
