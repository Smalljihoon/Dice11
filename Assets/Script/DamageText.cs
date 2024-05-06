using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] float movePosition;          // 텍스트 이동 목표 위치
    [SerializeField] float alphaSpeed;             // 투명도 변환속도
    [SerializeField] float destroyTime;           // 텍스트 파괴까지 걸리는 시간

    TextMeshPro text;   // 데미지 수치
    Color alpha;
    public int damage;          // Enemy에서 받은 데미지 받아옴

    float time = 0;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        alpha = text.color;
        Invoke("DestroyObject", destroyTime);
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.localPosition = new Vector3(0, Mathf.Lerp(0, movePosition, time), 0); // Lerp ( 처음위치, 목표위치, 속도?)
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
