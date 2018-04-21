using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB_RustyPistolBullet : MonoBehaviour {

    [SerializeField]
    private Projectile _projectileStats;
    private Rigidbody2D _projectileBody;
    private Vector2 _projectileDirection;
    // Use this for initialization
    private void Awake()
    {
        _projectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Start () {
        _projectileBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //_projectileBody.velocity = projectileDirection * _projectileStats.Velocity * Time.deltaTime;
        var nextPosition = Vector2.MoveTowards(transform.position, _projectileDirection, _projectileStats.Velocity * Time.deltaTime);
        _projectileBody.MovePosition(nextPosition);
    }
}
