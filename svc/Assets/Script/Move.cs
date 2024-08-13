using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5.0f;  // 움직임의 속도
    public float height = 7.0f; // 움직임의 높이

    public GameObject obj;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 currentRotation = obj.transform.rotation.eulerAngles;
            obj.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 180);
          
        }
    }

   
}
