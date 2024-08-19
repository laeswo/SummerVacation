using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropCeiling : MonoBehaviour
{
    public float dropSpeed = 3;
    public float dropDelay = 0.5f;

    private void Start()
    {
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        int numChild = this.transform.childCount;

        for (int i = 0; i < numChild; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = Vector2.down * dropSpeed;

            yield return new WaitForSeconds(dropDelay);
        }

        yield break;
    }
}
