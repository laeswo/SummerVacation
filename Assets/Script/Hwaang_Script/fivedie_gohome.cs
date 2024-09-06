using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fivedie_gohome : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if(SceneScript.instance.index > 0)
                SceneScript.instance.count++;
            SceneScript.instance.Load();
        }
    }
}
