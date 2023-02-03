using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    private float startpos;
    private float lenght;
    public GameObject cam;
    public float parallaxEffect;


    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
