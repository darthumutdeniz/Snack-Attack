using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    float health = 50;
    [SerializeField] TextMeshProUGUI healthText;
    Respawn respawnmanager;
    private void Awake()
    {
        health = maxHealth;
        respawnmanager = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawn>();
        healthText.text = health.ToString();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            respawnmanager.Die();
        }
        healthText.text = health.ToString();
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void IncreaseMaxHealth(int increaseCount)
    {
        health += increaseCount * 20;
        healthText.text = health.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "InstaKiller")
        {
            respawnmanager.Die();
        }
    }
}
