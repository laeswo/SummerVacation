using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{
    public float time = 1;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            StartCoroutine(EDestroy());
        }
    }

    IEnumerator EDestroy()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        this.gameObject.SetActive(false);
        yield break;
    }
}
