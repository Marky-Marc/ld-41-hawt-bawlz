using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WB_ZombieShotgun : Weapon
{
    public override void Update()
    {
        base.Update();
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
