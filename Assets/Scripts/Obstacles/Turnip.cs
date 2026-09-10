using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Turnip : Obsticle
{
    public int oriantation;
    public float speedInitial = 0.1f;
    public float explosionRadius;
    public float explosionSpeed;
    bool isExploding = false;
    [SerializeField] float initialRadius;
    CircleCollider2D blast;

    protected override void DoAtStart()
    {
        blast = GetComponent<CircleCollider2D>();
        blast.radius = initialRadius;
        blast.isTrigger = true;
        StartCoroutine(GetReady());
    }

    protected override void SetPosition()
    {
        Vector2 spawnPoint = new Vector2(player.transform.position.x, player.transform.position.y + speedInitial * waitAtStart + attackPattern.GetInitialDistanceFromPlayer());
        transform.position = spawnPoint;
    }

    // Update is called once per frame
    protected override void DoRepeted()
    {
        if (isExploding)
        {
            if (blast.radius >= explosionRadius)
            {
                isExploding = false;
                Destroy(gameObject);
                return;
            }
            initialRadius += explosionSpeed * Time.deltaTime;
            blast.radius = initialRadius;
        }
    }

    IEnumerator GetReady()
    {
        myrigidbody2D.linearVelocityY = -speedInitial;
        yield return new WaitForSeconds(waitAtStart);
        myrigidbody2D.linearVelocityY = -moveSpeed;

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        if(other.tag == "Weapon")
        {
            Destroy(gameObject);
        }
        if(other.tag == "Obsticles")
        {return;}
        if(other.tag == "Ground")
        {
            Explode();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    void Explode()
    {
        isExploding = true;
        blast.isTrigger = false;
        myrigidbody2D.linearVelocity = Vector2.zero;
    }
}
