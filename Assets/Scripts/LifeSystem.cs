using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public float currentLife = 100;
    public float maxLife = 100;

    private void Update()
    {
        if(currentLife <= 0)
        {
            Die();
        }
    }

    public void Cure(float curePoints)
    {
        currentLife += curePoints;
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
    }

    public void Die()
    {
        Debug.Log("Die");
        Destroy(gameObject);
    }
}
