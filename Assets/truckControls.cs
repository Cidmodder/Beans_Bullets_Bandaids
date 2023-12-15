using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class truckControls : MonoBehaviour
{
    public Vector3 waypoint;
    public Vector3 nextWaypoint;
    public float speed = 1f;
    public int beans = 0;
    public int bullets = 0;
    public int bandaids = 0;

    
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "endpoint")
        {
            Debug.Log("get next waypoint");
            nextWaypoint = other.GetComponent<poi_Controller>().getDestination();
        }

        if (other.gameObject.tag == "poi")
        {
            Debug.Log("add supplies");
            
            if (beans > 0)
            {
                other.GetComponent<poi_Controller>().addBeans(beans);
            }
            
            if (bullets > 0)
            {
                other.GetComponent<poi_Controller>().addBullets(bullets);
            }
            
            if (bandaids > 0)
            {
                other.GetComponent<poi_Controller>().addBandaids(bandaids);
            }
            

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nextWaypoint != null)
        {
            transform.LookAt(nextWaypoint);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


    }
}
