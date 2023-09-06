using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;
    public float timer;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, enemy.transform.position);

        if(distance < 20)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }


        
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }
}
