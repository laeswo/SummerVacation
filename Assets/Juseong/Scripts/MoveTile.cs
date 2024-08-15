using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour, ITrigger
{
    public float time = 0;
    public float xSpeed = 0;
    public float ySpeed = 1;

    IEnumerator EMoveTile()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2 (xSpeed, ySpeed);
    }

    public void StartCor()
    {
        StartCoroutine(EMoveTile());
    }
}
