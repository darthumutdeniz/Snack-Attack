using UnityEngine;
using System.Collections;

public class AttackGenerator : MonoBehaviour
{
    [SerializeField] AttackPatternSO attackPatternSO;
    GameObject attackObject;
    Obsticle obsticle;
    Coroutine spawnCorurine;
    bool hasGenerated = false;
    void Start()
    {
    }
    IEnumerator AttackSpawn()
    {
        for(int i = 0; i < attackPatternSO.GetNumberOfAttacks(); i++)
        {
            Vector2 spawnPoint = new Vector2(0 , 0);
            SetAttackObject();
            Instantiate(attackObject, spawnPoint, Quaternion.Euler(0,0, attackPatternSO.GetOriantation()));
            attackPatternSO.GetAttackObject().GetComponent<Obsticle>().attackPattern = null;
            yield return new WaitForSeconds(attackPatternSO.GetDelayBetweenAttacks());
        }
    }

    void SetAttackObject()
    {
        attackObject = attackPatternSO.GetAttackObject();
        obsticle = attackObject.GetComponent<Obsticle>();
        obsticle.attackPattern = attackPatternSO;
    }

    public void SpawnObsticles()
    {
        //SetAttackObject();
        spawnCorurine = StartCoroutine(AttackSpawn());
        hasGenerated = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" || hasGenerated) {return;}
        SpawnObsticles();
    }

    public void StopAttacking()
    {
        if (spawnCorurine == null) {return;}
        StopCoroutine(spawnCorurine); 
        hasGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

}
