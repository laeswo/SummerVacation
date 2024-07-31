using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Cam : MonoBehaviour
{
    public GameObject obj;
    public float Speed;
    private Vector3 targetPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;


    [SerializeField]
    float height;
    float width;

    private void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void Update()
    {
        targetPosition.Set(obj.transform.position.x+4, this.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition,Speed*Time.deltaTime);

        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
