using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB_RustyPistolBullet : MonoBehaviour {

    [SerializeField]
    private Projectile _projectileStats;
    private Rigidbody2D _projectileBody;
    private Ray2D _projectileDirection;
    private Vector2 _maxDistance;
    private int _currentRicochetCount;

    // Use this for initialization
    private void Awake()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _projectileDirection = new Ray2D(this.transform.position ,mousePosition - this.transform.position);
        //_projectileDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        _maxDistance = _projectileDirection.GetPoint(_projectileStats.Range);
    }
    void Start () {
        _projectileBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var nextPosition = Vector2.MoveTowards(transform.position, _maxDistance, _projectileStats.Velocity * Time.deltaTime);
        _projectileBody.MovePosition(nextPosition);

        if(this.transform.position == (Vector3)_maxDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Destroy(this.gameObject);
        if (collision.gameObject.name == "GolfBall")
        {
            var golfBall = collision.gameObject.GetComponent<B_GolfBall>();
            golfBall.TakeDamage(_projectileStats.Damage);
            Destroy(this.gameObject);
        }
        else
        {
            ++_currentRicochetCount;
        }

        if (_currentRicochetCount >= _projectileStats.RicochetCount)
        {
            Destroy(this.gameObject);
        }
    }
}