using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spike : MonoBehaviour
{
    public GameObject startpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Transform>().position = startpoint.GetComponent<Transform>().position;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            SceneScript.instance.count++;
            if (SceneScript.instance.count >= 5) SceneScript.instance.Load();
        }
    }
}
