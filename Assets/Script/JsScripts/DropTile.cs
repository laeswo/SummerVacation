using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTile : MonoBehaviour, ITrigger
{
    bool isStart = false;
    public float time = 0;
    IEnumerator EDropTile()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void StartCor()
    {
        if (!isStart)
        {
            StartCoroutine(EDropTile());
            isStart = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCor();
        }
    }
}
