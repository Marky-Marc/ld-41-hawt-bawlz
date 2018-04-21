using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour {
 
    [SerializeField]
    private float _movementSpeed;
    private Animator _playerAnimator;
    private GameObject _player;

    private Vector3 _mouseInWorld
    {
        get
        {
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0);
        }
    }

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerAnimator = _player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(HandleUserInput());
        StartCoroutine(UpdatePlayerLook());
        StartCoroutine(SetWeaponCrosshairPosition());
	}
    IEnumerator SetWeaponCrosshairPosition()
    {
        var crosshair = GameObject.Find("WeaponCrosshair").GetComponent<SpriteRenderer>();
        crosshair.transform.position = _mouseInWorld;
        yield return null;
    }
    IEnumerator UpdatePlayerLook()
    {
        var pointToLook = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _player.transform.LookAt(pointToLook, Vector3.forward);
        _player.transform.eulerAngles = new Vector3(0, 0, -_player.transform.eulerAngles.z);

        yield return null;
    }
    IEnumerator HandleUserInput()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        float verticalInputValue = Input.GetAxis("Vertical");
        bool firing = Input.GetButton("Fire1");

        _playerAnimator.SetBool("PlayerMoving", Mathf.Abs(horizontalInputValue) != 0.0f || Mathf.Abs(verticalInputValue) != 0.0f);

        if (verticalInputValue > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _mouseInWorld, _movementSpeed * Time.deltaTime);
        }

        Debug.Log($"Horizontal Input Value: {horizontalInputValue} Vertical Input Value: {verticalInputValue} Firing: {firing}");

        yield return null;
    }
}
