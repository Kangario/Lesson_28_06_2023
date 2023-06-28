using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float timer;
    public float respawnTime;
    public Transform respawnPoint;
    public GameObject GG;
    bool isDead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GG.GetComponent<Stats>().hp <= 0)
        {
            timer-=Time.deltaTime;
            if (timer <= 0)
            {
                GG.GetComponent<Stats>().hp = 100;
                GG.transform.position = respawnPoint.position;
                GG.SetActive(true);
            }
        }else
        {
            timer = respawnTime;
        }
    }
}
