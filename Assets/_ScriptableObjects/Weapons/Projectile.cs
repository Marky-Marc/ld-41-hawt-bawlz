using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Weapons/Projectile")]
class Projectile : ScriptableObject
{
    public float Damage;
    public float Velocity;
    public float Range;
}
