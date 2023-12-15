using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAI : MonoBehaviour
{
    public float speed = .1f;
    public float damage;
    public float lifeTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime = lifeTime - Time.deltaTime;
        
        if (lifeTime < 0 )
        {
            Destroy(gameObject );
        }

    }
}
