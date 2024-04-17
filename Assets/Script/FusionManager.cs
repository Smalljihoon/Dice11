using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionManager : MonoBehaviour
{
    Vector3 offset;
    public string SlotTag = "Slot";
    public LayerMask layer;


    //[SerializeField] Camera camera;

    private void Start()
    {
        //camera = GetComponent<Camera>();
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition;

            MousePosition = Input.mousePosition;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hitt = Physics2D.Raycast(MousePosition, Vector2.zero);
            Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 0.3f);
            if (hitt.collider != null)
            {
                    var FirstTarget = hitt.collider.GetComponent<Dice>();
                    //var target = FirstTarget.category;
                    hitt.transform.GetComponent<SpriteRenderer>().color = Color.gray;

                offset = transform.position - MouseWorldPosition();
            }
            if (Input.GetMouseButton(0))
            {
                transform.position = MouseWorldPosition() + offset;
            }
            if (Input.GetMouseButtonUp(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);

                if (hit.transform != null)
                {
                    Transform hitOB = hit.transform;
                    if (hitOB.childCount > 0)
                    {
                        Dice hitdice = hitOB.GetChild(0).GetComponent<Dice>();

                        //if (hitdice.category == )
                        //{
                        //    Debug.Log("а╤гу");
                        //}
                        //else
                        //{
                        //    transform.localPosition = Vector3.zero;
                        //}
                    }
                    else
                    {
                        if (hit.transform.tag == SlotTag)
                        {
                            this.transform.parent = hit.transform;
                            transform.localPosition = Vector3.zero;
                        }
                    }
                }
                else
                {
                    transform.localPosition = Vector3.zero;
                }


                Physics.SyncTransforms();
            }
        }
    }
}

//Vector3 offset;
//public string SlotTag = "Slot";

//public LayerMask layer;
//Vector3 MouseWorldPosition()
//{
//    var mouseScreenPos = Input.mousePosition;
//    mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
//    return Camera.main.ScreenToWorldPoint(mouseScreenPos);
//}
//private void OnMouseDown()
//{
//    offset = transform.position - MouseWorldPosition();
//    transform.GetComponent<BoxCollider2D>().enabled = false;
//}

//private void OnMouseDrag()
//{
//    transform.position = MouseWorldPosition() + offset;
//}

//private void OnMouseUp()
//{
//    //var rayOrigin = Camera.main.transform.position;
//    //var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
//    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity,layer);
//    GameObject hitOB = hit.transform.gameObject;
//    Dice hitdice = hitOB.GetComponent<Dice>();

//    if (hitdice != null)
//    {
//        if (hit.transform.tag == SlotTag)
//        {
//            if (hitdice.category == this.category)
//            {
//                transform.position = hit.transform.position;
//                this.transform.parent = hit.transform;

//            }
//        }
//    }
//    transform.GetComponent<BoxCollider2D>().enabled = true;
//}