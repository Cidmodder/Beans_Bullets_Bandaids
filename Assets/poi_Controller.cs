using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class poi_Controller : MonoBehaviour
{
    public int productionRate; //how fast it makes the good in units per minute
    public GameObject truck; //object that delivers cargo
    private GameObject spawnedTruck;
    public enum produce { beans, bullets, bandaids}; //beans. bullets or bandaids
    public produce Produce;
    public int stored;
    public int beans; //amount currently stored
    public int bandaids;
    public int bullets;

    public List<Vector3> destinations;
    public int connections;
    public int maxConnections;
    public int currentConnection = 0;
    public enum poi { factory, node, poi}; //types of points of interest (poi)
    public poi type;


    // Start is called before the first frame update
    void Start()
    {
        //set behaviors of the types of poi
        
        if (type == poi.factory) { 
            if (Produce == produce.beans)
            {
                productionRate = 100;
                StartCoroutine(Timer(5));
            }

            if (Produce == produce.bullets)
            {
                productionRate = 150;
                StartCoroutine(Timer(5));
            }

            if (Produce == produce.bandaids)
            {
                productionRate = 25;
                StartCoroutine(Timer(5));
            }
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
        
            if (destinations.Count > 0 && stored >= 100) 
            {
                if (currentConnection >= destinations.Count) { currentConnection = 0; }  
                spawnedTruck = Instantiate(truck, transform.position, transform.rotation);
            if (type == poi.factory && Produce == produce.beans)
            {
                spawnedTruck.GetComponent<truckControls>().beans = 100;
                stored = stored - 100;
            }

            if (type == poi.factory && Produce == produce.bullets)
            {
                spawnedTruck.GetComponent<truckControls>().bullets = 100;
                stored = stored - 100;
            }

            if (type == poi.factory && Produce == produce.bandaids)
            {
                spawnedTruck.GetComponent<truckControls>().bandaids = 100;
                stored = stored - 100;
            }


                 spawnedTruck.GetComponent<truckControls>().nextWaypoint = destinations[currentConnection];
                currentConnection++;
                

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

    public void addBeans(int supply)
    {
        beans = beans + supply;
    }

    public void addBullets(int supply)
    {
        bullets = bullets + supply;
    }

    public void addBandaids(int supply)
    {
        bandaids = bandaids + supply;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
