using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTile : MonoBehaviour, ITrigger
{
    public float time = 0;
    public float speed = 1;
    public Vector2 destPos = Vector2.zero;

    IEnumerator EMoveToTile()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        while (true)
        {
            Vector2 newPos = Vector2.MoveTowards(this.transform.position, destPos, speed * Time.deltaTime);
            this.transform.position = newPos;
            yield return null;
            if(newPos == destPos) yield break;
        }
    }

    public void StartCor()
    {
        StartCoroutine(EMoveToTile());
    }
}
