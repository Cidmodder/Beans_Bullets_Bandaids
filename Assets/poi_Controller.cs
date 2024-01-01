using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int control; //-100 for enemy +100 for ally

    public List<Vector3> destinations;
    public List<Vector3> previous;
    public int connections;
    public int maxConnections;
    public int currentConnection = 0;
    public enum poi { factory, node, poi}; //types of points of interest (poi)
    public poi type;
    public int poiID;
    private GameObject toDelete;

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

    public void addPrevious(Vector3 last)
    {
        previous.Add(last);

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

    public void deleteChild(int id)
    {
        Destroy(gameObject.transform.GetChild(id - 1).gameObject);
        destinations.Clear();
    }

    public void deleteNode()
    {
        Ray backwardRay = new Ray(transform.position, previous[0] - transform.position);
        RaycastHit previousNode;


        if (destinations.Count == 0) 
        {
           
            if (Physics.Raycast(backwardRay, out previousNode, 100))
            {
                toDelete = previousNode.transform.gameObject;
                toDelete.GetComponent<poi_Controller>().deleteChild(poiID);
                Destroy(gameObject);
            }
        }

        if (destinations.Count == 1)
        {
            if (Physics.Raycast(backwardRay, out previousNode, 100))
            {
                toDelete = previousNode.transform.gameObject;
                toDelete.GetComponent<poi_Controller>().deleteChild(poiID);
            }

            Ray forwardRay = new Ray(transform.position, destinations[0] - transform.position);
            RaycastHit nextNode;

            if (Physics.Raycast(forwardRay, out nextNode, 100))
            {
                if (nextNode.transform.tag == "poi")
                {
                    Destroy(gameObject);
                }
                
                toDelete = nextNode.transform.gameObject;
                toDelete.GetComponent<poi_Controller>().deleteNode();
            }

            Destroy(gameObject);


        }

    }

    public void setID(int id)
    {
        poiID = id;
    }

    //positive increment for ally negative for enemy
    public void updateControl(int increment)
    {
        if (control < 100 && control > -100)
        {
            control += increment;
        }

        if (control < 0)
        {
            transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, Mathf.Abs(control / 100f));
        }

        if (control > 0)
        {
            transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.blue, Mathf.Abs(control / 100f));
        }
    }


    // Update is called once per frame
    void Update()
    {


    }
}
