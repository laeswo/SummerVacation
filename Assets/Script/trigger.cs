using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject spike;
    public string xy;
    public float speed;
    public float range;
    bool once= false;
    float range2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(once && math.abs(range2) < math.abs(range)){
            range2 += Time.deltaTime * speed;
            if (xy == "x")
            {
                spike.GetComponent<Transform>().position += new Vector3(Time.deltaTime * speed, 0, 0);

            }
            else
            {
                spike.GetComponent<Transform>().position += new Vector3(0,Time.deltaTime * speed, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            once = true;
        }
    }
}
