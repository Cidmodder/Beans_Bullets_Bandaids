using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class point_Snapper : MonoBehaviour
{
    public GameObject view;
    private Renderer render;
    
    
    // Start is called before the first frame update
    void Start()
    {
        view = Camera.main.gameObject;
        render = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {

        view.GetComponent<path_Drawing>().handleMouseEnter(transform.position);
        render.material.color = Color.green;
        
    }

    private void OnMouseExit()
    {
       view.GetComponent<path_Drawing>().handleMouseExit(transform.position);
       render.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
