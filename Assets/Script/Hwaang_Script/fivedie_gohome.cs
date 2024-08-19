using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fivedie_gohome : MonoBehaviour
{
    private int go = 0;

    public String scene;

    // Update is called once per frame
    void Update()
    {
        if (go >= 5)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            go += 1;
        }
    }
}
