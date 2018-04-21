using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB_RustyPistolBullet : MonoBehaviour {

    [SerializeField]
    private Projectile _projectileStats;
    private Rigidbody2D _projectileBody;
    private Ray _projectileDirection;
    private Vector2 _maxDistance;
    // Use this for initialization
    private void Awake()
    {
        _projectileDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
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
}