using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Pattern", fileName = "newCarrotAttack")]
public class AttackPatternSO : ScriptableObject
{
    [SerializeField] GameObject attackObject;
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;
    [SerializeField] float attackDelay;
    [SerializeField] float attackDelayVariation;
    [SerializeField] float attackLifeTime;
    [SerializeField] float delayBetweenAttacks;
    [SerializeField] float numberOfAttacks;
    [SerializeField] float distanceFromPlayer;
    [SerializeField] Transform spawnPoint;
    [Range(-90, 90)] [SerializeField] float oriantationInAngles;

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public GameObject GetAttackObject()
    {
        return attackObject;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetInitialDistanceFromPlayer()
    {
        return distanceFromPlayer;
    }

    public float GetNumberOfAttacks()
    {
        return numberOfAttacks;
    }

    public float GetDelayBetweenAttacks()
    {
        return delayBetweenAttacks;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetAttackObjectDelay()
    {
        return attackDelay;
    }

    public float GetAttackLifeTime()
    {
        return attackLifeTime;
    }

    public float GetOriantation()
    {
        return oriantationInAngles;
    }

}
