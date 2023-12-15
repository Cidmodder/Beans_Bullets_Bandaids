using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poi_Controller : MonoBehaviour
{
    public int productionRate; //how fast it makes the good in units per minute
    public GameObject truck; //object that delivers cargo
    private GameObject spawnedTruck;
    public string produce; //beans. bullets or bandaids
    public int stored; //amount currently stored
    public List<Vector3> destinations;
    public int connections;
    public enum poi { factory, node, poi}; //types of points of interest (poi)
    public poi type;


    // Start is called before the first frame update
    void Start()
    {
        //set behaviors of the types of poi
        
        if (type == poi.factory) { 
        productionRate = 100;
        produce = "beans";
        StartCoroutine(Timer(5));
         }

        else if (type == poi.node)
        {
            productionRate = 0;
        }
        else
        {
            productionRate = 0;
        }
    }


    IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time);
        stored = stored + productionRate;
        
            if (destinations.Count > 0 && stored >= 100) { 
                spawnedTruck = Instantiate(truck, transform.position, transform.rotation);
                spawnedTruck.GetComponent<truckControls>().supply = 100;
                spawnedTruck.GetComponent<truckControls>().nextWaypoint = destinations[0];
                stored = stored - 100;
            }

        StartCoroutine(Timer(5));
    }

    public void addDestination(Vector3 destination)
    {
        destinations.Add(destination);
        if (connections < 3)
        {
            connections++;
        }


    }

    public Vector3 getDestination()
    {
        return destinations[0];
    }

    public void addSupplies(int supply)
    {
        stored = stored + supply;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
