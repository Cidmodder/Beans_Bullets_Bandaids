using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class captureAi : MonoBehaviour
{

    public int numberEnemies;
    public int numberAllies;
    public float updateTime;


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<unitAI>().setControl(this.gameObject);
        if (other.gameObject.transform.tag == "enemy")
        {
            numberEnemies++;
        }

        if (other.gameObject.transform.tag == "ally")
        {
            numberAllies++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<unitAI>().removeControl();

        if (other.gameObject.transform.tag == "enemy")
        {
            numberEnemies--;
        }

        if (other.gameObject.transform.tag == "ally")
        {
            numberAllies--;
        }
    }

    public void removeAlly()
    {
        numberAllies--;
    }

    public void removeEnemy()
    {
        numberEnemies--;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numberAllies > numberEnemies || numberEnemies > numberAllies)
        {

            updateTime -= Time.deltaTime;

            if (updateTime <= 0)
            {
                updateTime = 1;

                if (numberAllies > numberEnemies)
                {
                    this.transform.parent.GetComponent<poi_Controller>().updateControl(numberAllies - numberEnemies);
                }

                if (numberEnemies > numberAllies)
                {
                    this.transform.parent.GetComponent<poi_Controller>().updateControl(numberAllies - numberEnemies);
                }

            }


        }
    }
}

