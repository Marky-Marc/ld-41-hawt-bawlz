using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour {
 
    [SerializeField]
    private float _movementSpeed;
    private Animator _playerAnimator;
    private GameObject _player;
    private Weapon _currentWeapon;
    private SpriteRenderer _weaponCrosshair;
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
        _weaponCrosshair = GameObject.Find("WeaponCrosshair").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        StartCoroutine(HandleUserInput());
        StartCoroutine(UpdatePlayerLook());
        StartCoroutine(SetWeaponCrosshairPosition());
	}
    #region Player Input
    IEnumerator SetWeaponCrosshairPosition()
    {
        _weaponCrosshair.transform.position = _mouseInWorld;
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
        float verticalInputValue = Input.GetAxis("Vertical");
        bool firing = Input.GetButton("Fire1");

        _playerAnimator.SetBool("PlayerMoving", Mathf.Abs(verticalInputValue) != 0.0f);

        if (verticalInputValue > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _mouseInWorld, _movementSpeed * Time.deltaTime);
        }

        if(firing && _currentWeapon != null)
        {
            _currentWeapon.Fire();
        }

        yield return null;
    }
    #endregion
    #region Pickups
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name.ToUpper() == "GOLFBALL")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
        }
        if (collision.gameObject.tag.ToUpper() == "PROJECTILE")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var objectName = collision.gameObject.name.ToUpper();
        switch (objectName)
        {
            case "RUSTYPISTOLPICKUP":
                {
                    this.PickupRustyPistol(collision.gameObject);
                }
                break;
        }
    }
    void PickupRustyPistol(GameObject pickup)
    {
        if(!_currentWeapon || _currentWeapon.name.ToUpper() != "RUSTYPISTOL")
        {
            var rustyPistol = Resources.Load<GameObject>("Prefabs/Weapons/RustyPistol");
            var rustyPistolInstance = Instantiate(rustyPistol, Vector3.zero, _player.transform.rotation, _player.transform);
            rustyPistolInstance.name = "RustyPistol";
            rustyPistolInstance.transform.localPosition = new Vector3(0.31f, 0.31f, 0);
            _currentWeapon = rustyPistolInstance.GetComponent<Weapon>();

            Debug.Log($"Rusty Pistol Position {rustyPistolInstance.transform.position}");
            Debug.Log($"Rusty Pistol Local Position {rustyPistolInstance.transform.localPosition}");

            Destroy(pickup);
        }
    }
    #endregion
}
