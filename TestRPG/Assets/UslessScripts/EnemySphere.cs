using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphere : Enemy
{
    public override void Move()
    {
        base.Move();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage + 1);
    }
}
