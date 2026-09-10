using System;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public AttackPatternSO attackPattern;
    protected float lifeTime;
    protected float moveSpeed;
    protected float damage;
    protected Rigidbody2D myrigidbody2D;
    protected GameObject player;
    protected float waitAtStart;

    protected virtual void Awake()
    {
        SetVariables();
        SetRotation();
        SetPosition();
        DoAtStart();
    }

    protected virtual void DoAtStart(){}

    protected virtual void SetPosition(){}

    protected virtual void SetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, attackPattern.GetOriantation());
    }

    protected virtual void SetVariables()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        myrigidbody2D = GetComponent<Rigidbody2D>();
        lifeTime = attackPattern.GetAttackLifeTime();
        moveSpeed = attackPattern.GetMoveSpeed();
        damage = attackPattern.GetDamage();
        waitAtStart = attackPattern.GetAttackObjectDelay();
    }

    protected virtual void Update()
    {
        CheckLifeTimeHasEnded();
        DoRepeted();
    }

    protected virtual void DoRepeted(){}

    protected virtual void CheckLifeTimeHasEnded()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        else if(other.tag == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
