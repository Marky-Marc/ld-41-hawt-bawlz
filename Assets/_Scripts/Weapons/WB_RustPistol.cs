using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WB_RustPistol : Weapon {

    [SerializeField]
    private Gun _gunStats;
    [SerializeField]
    private GameObject _bullet;
    private float _timeSinceLastFire = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _timeSinceLastFire += Time.deltaTime;
	}

    public override void Fire()
    {
        if (_timeSinceLastFire >= _gunStats.FireRate)
        {
            Instantiate(_bullet, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            _timeSinceLastFire = 0.0f;
        }
    }
}
