using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float agroRadius = 15f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float attackInterval = 1f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private GameObject target;
    private bool isAgro = false;
    private bool isAttacking = false;
    private float attakTimer = 0f;
    
   
    void Start()
    {
        target = GameObject.Find("Idle");
    }

    
    void Update()
    {
        float distanceToTarrget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToTarrget <= agroRadius)
        {
            isAgro = true;
        }
        else
        {
            isAgro = false;
            isAttacking = false;
        }
        if (isAgro) { 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            if (!isAttacking)
            {
                attakTimer += Time.deltaTime;
                if (attakTimer >= attackInterval)
                {
                    Attack();
                    attakTimer = 0f;
                }
            }
        }
    }

    private void Attack()
    {
        target.GetComponent<Stats>().TakeDamage(damage);
        isAttacking = true;
    }

}
