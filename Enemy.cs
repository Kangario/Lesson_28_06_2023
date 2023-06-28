using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float aggroRadius = 10f;  // Радиус агра
    public float moveSpeed = 5f;  // Скорость передвижения врага
    public float attackInterval = 2f;  // Интервал атаки в секундах
    public int attackDamage = 10;  // Урон от атаки

    public Transform target;  // Цель врага (герой)
    private bool isAggro = false;  // Флаг, указывающий на то, что враг в агре
    private bool isAttacking = false;  // Флаг, указывающий на то, что враг атакует
    private float attackTimer = 0f;  // Таймер для интервала атаки
    private void Start()
    {
        
    }

    private void Update()
    {
        // Проверяем расстояние до героя
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Проверяем, находится ли герой в радиусе агра
        if (distanceToTarget <= aggroRadius)
        {
            isAggro = true;
        }
        else
        {
            isAggro = false;
            isAttacking = false;
        }

        // Если враг в агре, бежим в сторону героя и атакуем с заданным интервалом
        if (isAggro)
        {
            // Бежим в сторону героя
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Проверяем интервал атаки
            if (!isAttacking)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackInterval)
                {
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
    }

    private void Attack()
    {
        // Атакуем героя
        target.GetComponent<Stats>().TakeDamage(attackDamage);
        isAttacking = true;
    }
}
