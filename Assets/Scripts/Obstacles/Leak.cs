using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Leak : Obsticle
{
    protected override void SetPosition()
    {
        transform.position = attackPattern.GetSpawnPoint().position;
        myrigidbody2D.linearVelocityY = moveSpeed;
    }

}
