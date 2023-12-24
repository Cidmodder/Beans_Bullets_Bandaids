using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewHandler : MonoBehaviour
{

    public GameObject unit;
    
    // Start is called before the first frame update
    void Start()
    {
        unit = transform.parent.gameObject;
    }

     void OnTriggerEnter(Collider other)
    {


        if (unit.transform.tag == "enemy" && other.transform.tag == "ally")
        {
            unit.GetComponent<unitAI>().setTarget(other.gameObject);
        }

        if (unit.transform.tag == "ally" && other.transform.tag == "enemy")
        {
            unit.GetComponent<unitAI>().setTarget(other.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
