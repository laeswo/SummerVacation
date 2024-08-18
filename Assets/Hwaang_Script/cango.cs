using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cango : MonoBehaviour
{
    public int cango1 = 0;
    public Text text;
    public GameObject player;
    private bool go = false;
    public string scenename;
    public int apple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cango1);
        if (text == null)
        {
            
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
       

        if (go && player.transform.position == transform.position)
        {
            SceneManager.LoadScene(scenename);
        }
        
    }
}
