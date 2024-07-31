using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   

    public GameObject gameobj;
    public GameObject gameobj2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(gameobj);

            Destroy(gameobj2);
        }

        if (collision.CompareTag("wall")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Debug.Log("³¡");
        }
    }
}
