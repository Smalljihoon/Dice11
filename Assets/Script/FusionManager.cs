using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FusionManager : MonoBehaviour
{
    Vector3 offset;
    public LayerMask layer;

    private Dice selectDice = null;
    Transform hittOB = null;
    Dice gotdice;

    [SerializeField] GameObject[] dice;


    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void Update()
    {
        // 마우스 좌클릭 했을때
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitt = Physics2D.Raycast(MouseWorldPosition(), Camera.main.transform.forward, Mathf.Infinity, layer);

            if (hitt.transform != null)
            {
                if (hitt.transform.childCount > 0)
                {
                    hittOB = hitt.transform;
                    selectDice = hitt.transform.GetChild(0).GetComponent<Dice>();
                    offset = selectDice.transform.position - MouseWorldPosition();
                }
            }
        }

        // 좌클릭 했을때의 슬롯에 주사위가 있으면
        if (selectDice != null)
        {
            if (Input.GetMouseButton(0))
            {
                selectDice.transform.position = MouseWorldPosition() + offset;
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

                        if (hitdice.category == selectDice.category)
                        {
                            if (hitdice.eyes == selectDice.eyes)
                            {
                                if (hitdice.Equals(selectDice))
                                {
                                    selectDice.transform.localPosition = Vector3.zero;
                                }
                                else
                                {
                                    int remain = hitdice.eyes;
                                    remain++;
                                    Debug.Log("조합");
                                    Destroy(hitOB.GetChild(0).gameObject);
                                    Destroy(hittOB.GetChild(0).gameObject);

                                    var temp = dice[Random.Range(0, dice.Length)];
                                    var diceGO = Instantiate(temp, hitOB);
                                    var newDice = diceGO.GetComponent<Dice>();
                                    newDice.eyes = remain;
                                    newDice.SetDiceEye();
                                    
                                    Debug.Log(newDice.eyes);


                                }
                            }
                        }
                        else
                        {
                            selectDice.transform.localPosition = Vector3.zero;
                        }
                    }
                    else
                    {
                        selectDice.transform.localPosition = Vector3.zero;
                    }
                }
                else
                {
                    selectDice.transform.localPosition = Vector3.zero;
                }
                selectDice = null;
            }
        }
    }
}
