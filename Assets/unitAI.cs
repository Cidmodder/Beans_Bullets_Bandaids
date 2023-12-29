using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class unitAI : MonoBehaviour
{

    public int health;
    public int morale;
    public int damage;
    public float speed;
    public float fireRate = 2f;
    public float lastFired = 0f;

    public int beans; //amount currently stored
    public int bandaids;
    public int bullets;

    public GameObject target;
    public GameObject bullet;
    public GameObject objective;

    public Vector3 objectivePosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void setTarget(GameObject tar)
    {
        if (target == null)
        {
            this.target = tar;
        }
    }

    public void setObjective(GameObject obj) { 
        if (objective == null) 
        { 
            this.objective = obj;
            objectivePosition = obj.transform.position + new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
        } 
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void healDamage (int heal)
    {
        health = health + heal;
    }


    // Update is called once per frame
    void Update()
    {
        if (lastFired >= 0)
        {
            lastFired = lastFired - Time.deltaTime;
        }

        if (target && lastFired <= 0)
        {
            transform.LookAt(target.transform.position);
            GameObject fire = Instantiate(bullet, transform.position + this.transform.forward * .75f, Quaternion.identity);
            bullets--;
            fire.transform.LookAt(target.transform.position + new Vector3(Random.Range(-1f,1f),0f, Random.Range(-1f, 1f)));
            lastFired = fireRate;
        }

        if (Vector3.Distance(objective.transform.position, this.transform.position) > 2f && !target )
        {
            transform.LookAt(objective.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, objectivePosition, speed* Time.deltaTime);
        }
    }
}
