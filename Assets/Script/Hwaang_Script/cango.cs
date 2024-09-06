using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cango : MonoBehaviour
{
    public int cango1 = 0;
    public Text text;
    private bool go = false;
    public int apple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text == null)
        {
            go = true;
        }
        else
        {
            if (cango1<apple)
            {
                text.text = cango1 + "/"+apple;
            }
            else if(cango1>=apple)
            {
                text.text = cango1 + "/" + apple;
                go = true;
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (go && collision.CompareTag("Player"))
        {
            SceneScript.instance.index++;
            SceneScript.instance.Load();
        }
    }
}
