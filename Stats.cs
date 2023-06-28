using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float hp = 100;
    [SerializeField] private float regenHp;
    public float maxHp;
    private void Start()
    {
        maxHp= hp;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
    private void Update()
    {
         if (hp <= 0) {
            gameObject.SetActive(false);
        }
        if (hp < maxHp)
        {
            hp += regenHp * Time.deltaTime;
        }

    }
}
