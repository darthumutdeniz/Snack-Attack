using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("Respawn Cooldown")]
    public float diesec = 5f;
    public bool currentlyDead { get; private set; } = false;
    public Rigidbody2D rb;
    AttackGenerator[] attackGenerators;
    AudioScript audioManager;
    public Vector2 startPos;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        startPos = transform.position;
    }
    public void Die()
    {
        StartCoroutine(Respawner(diesec));
    }
    public IEnumerator Respawner(float time)
    {
        attackGenerators = FindObjectsByType<AttackGenerator>(FindObjectsSortMode.None);
        currentlyDead = true;
        rb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        foreach (AttackGenerator generator in attackGenerators)
        {
            generator.StopAttacking();
        }
        yield return new WaitForSeconds(time);
        transform.position = startPos;
        rb.linearVelocity = Vector2.zero;
        GetComponent<Health>().ResetHealth();
        GetComponent<Health>().IncreaseMaxHealth(0);
        //audioManager.PlaySFX(audioManager.hit);
        rb.simulated = true;
        currentlyDead = false;
        transform.localScale = new Vector3(1, 1, 1);
    }
}