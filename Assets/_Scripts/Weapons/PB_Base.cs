using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PB_Base : MonoBehaviour
{
    [SerializeField]
    protected Projectile _projectileStats;
    protected Rigidbody2D _projectileBody;
    protected Ray2D _projectileDirection;
    protected Vector2 _maxDistance;
    protected int _currentRicochetCount;

    protected virtual void Awake()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _projectileDirection = new Ray2D(this.transform.position, mousePosition - this.transform.position);
        _maxDistance = _projectileDirection.GetPoint(_projectileStats.Range);
    }

    protected virtual void Start()
    {
        _projectileBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        var nextPosition = Vector2.MoveTowards(transform.position, _maxDistance, _projectileStats.Velocity * Time.deltaTime);
        _projectileBody.MovePosition(nextPosition);

        if (this.transform.position == (Vector3)_maxDistance)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            return;
        }
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
