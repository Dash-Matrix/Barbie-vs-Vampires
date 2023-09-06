using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;
    public float explosionRadius;
    public float targetHeightOffset = 1.0f;

    private GameObject[] enemies;
    private GameObject nearestEnemy;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FindAndTargetNearestEnemy();
    }

    void FindAndTargetNearestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            nearestEnemy = FindNearestEnemy();
            if (nearestEnemy != null)
            {
                TargetNearestEnemy(nearestEnemy);
            }
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject nearest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }

    void TargetNearestEnemy(GameObject targetEnemy)
    {
        Vector3 enemyPosition = targetEnemy.transform.position + Vector3.up * targetHeightOffset;
        Vector3 direction = enemyPosition - transform.position;

        rb.velocity = direction.normalized * force;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Delete the enemy
            Destroy(gameObject); // Delete the bullet
            WaveSpawner.EnemiesAlive--;
        }

        if (collision.gameObject.CompareTag("ground"))
        {

            Destroy(gameObject); // Delete the bullet

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
