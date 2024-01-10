using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float playerDamage = 10f;
    [SerializeField] float areaATK = 1f;
    List<Transform> targets = new List<Transform>();
    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(AttackMelee());
        }
    }

    IEnumerator AttackMelee()
    {
        GetEnemiesRange();
        yield return new WaitForSeconds(1f);
        foreach (Transform target in targets)
        {
            if (target != null)
                target.GetComponent<LifeSystem>().TakeDamage(playerDamage);
        }
    }

    void GetEnemiesRange()
    {
        targets.Clear();

        foreach (Collider colisor in Physics.OverlapSphere(transform.position + transform.forward, areaATK))
        {
            if (colisor.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Bateu no inimigo!");
                targets.Add(colisor.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, areaATK);
    }
}
