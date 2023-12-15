using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{

    public int health;
    public int morale;
    public int damage;
    public float fireRate = 2f;
    public float lastFired = 0f;

    public int beans; //amount currently stored
    public int bandaids;
    public int bullets;

    public GameObject target;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastFired >= 0)
        {
            lastFired = lastFired - Time.deltaTime;
        }

        if (Vector3.Distance(target.transform.position, this.transform.position) < 5f && lastFired <= 0)
        {
            GameObject fire = Instantiate(bullet, transform.position, Quaternion.identity);
            bullets--;
            fire.transform.LookAt(target.transform.position);
            lastFired = fireRate;
        }
    }
}
