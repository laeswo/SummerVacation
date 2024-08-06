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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cango1<=3)
        {
            text.text = cango1 + "/3";
        }
        else
        {
            go = true;
        }

        if (go && player.transform.position == transform.position)
        {
            SceneManager.LoadScene("stage2");
        }
        
    }
}
