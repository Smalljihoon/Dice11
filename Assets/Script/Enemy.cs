using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float speed;
    [SerializeField] bool isTurn;

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    private RaycastHit rayHit;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector2.up, new Color(1, 0, 0));

    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void Raycast()
    {
        if (isTurn)
            this.transform.Rotate(90, 0, 0);

        Vector3 point = transform.position + (Vector3.up * boxCollider.size.y);

    }

}
