using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected Gun _gunStats;
    [SerializeField]
    protected GameObject _bullet;
    protected float _timeSinceLastFire = 0.0f;

    public abstract void Fire();

    // Update is called once per frame
    public virtual void Update()
    {
        _timeSinceLastFire += Time.deltaTime;
    }
}
