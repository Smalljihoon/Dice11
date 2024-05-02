using UnityEngine;

public class FusionManager : MonoBehaviour
{
    [SerializeField] GameObject[] dice;     // 주사위들

    private Dice selectDice = null;         // 처음 마우스 클릭했을때 선택된 주사위
    Transform hittOB = null;                // 처음 마우스 클릭했을때 감지되는 객체

    public LayerMask layer;                 // 레이를 쐈을 때 슬롯에 박스콜라이더가 있기 때문에 슬롯기준으로 판단할 것 Layer = "Slot"
    Vector3 offset;


    Vector3 MouseWorldPosition()    // 스크린화면이랑 월드좌표랑 매칭시켜주는 함수
    {
        var mouseScreenPos = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void Update()
    {
        // 마우스 좌클릭 했을때
        if (Input.GetMouseButtonDown(0))
        {
            // hitt라는 레이를 마우스 좌클릭 했을 때 쏜다
            RaycastHit2D hitt = Physics2D.Raycast(MouseWorldPosition(), Camera.main.transform.forward, Mathf.Infinity, layer);

            // 레이를 쐈을때 쏜 지점이 슬롯이라면
            if (hitt.transform != null)
            {
                // 슬롯의 자식에 다이스가 달려있으면
                if (hitt.transform.childCount > 0)
                {
                    hittOB = hitt.transform;
                    selectDice = hitt.transform.GetChild(0).GetComponent<Dice>();   // selectDice변수에 -> 레이를 맞은 슬롯의 자식(다이스)의 Dice 컴포넌트를 찾아온다
                    offset = selectDice.transform.position - MouseWorldPosition();  // 마우스와 클릭했을때의 다이스와의 위치 정렬화
                }
            }
        }
        // 좌클릭 했을때의 슬롯에 주사위가 있으면
        if (selectDice != null)
        {
            // 드래그 => 처음 클릭했을때 마우스와 다이스가 맞닿은 지점을 기준화 시켜줌
            if (Input.GetMouseButton(0))
            {
                selectDice.transform.position = MouseWorldPosition() + offset;
            }
            // 마우스 버튼을 뗐을때
            if (Input.GetMouseButtonUp(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // hit라는 레이를 마우스버튼을 뗐을 때 지점에서 쏜다
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);

                // hit레이에 슬롯이었다면
                if (hit.transform != null)
                {
                    Transform hitOB = hit.transform;

                    // 뗐을 때 슬롯의 자식에 다이스가 있다면 
                    if (hitOB.childCount > 0)
                    {
                        // 다이스의 Dice 컴포넌트 가져오고
                        Dice hitdice = hitOB.GetChild(0).GetComponent<Dice>();

                        // 클릭했을 때와 뗐을 때의 다이스 종류를 비교 || 조커 다이스는 어느 다이스와도 융화가정이 일어나기 때문에 처음 클릭 했을 때의 다이스가 조커다이스일 경우도 or로 체크
                        if (selectDice.category == hitdice.category || selectDice.category == Dice_category.Joker)
                        {
                            // 두 다이스가 눈금이 같은지를 비교
                            if (hitdice.eyes == selectDice.eyes)
                            {
                                // 
                                if (hitdice.Equals(selectDice))
                                {
                                    selectDice.transform.localPosition = Vector3.zero;
                                }
                                else
                                {
                                    // 첫 클릭 했을 때 다이스가 조커인가부터 체크
                                    if (selectDice.category == Dice_category.Joker)
                                    {
                                        // 뗐을 때 다이스와 동일한 다이스로 copy의 변수에 새로 생성
                                        var copy = Instantiate(hitdice, hittOB);
                                        // 원래 있던 자리로 복귀
                                        copy.transform.localPosition = Vector3.zero;
                                        // 기존 조커다이스 파괴
                                        Destroy(hittOB.GetChild(0).gameObject);

                                        GameManager.instance.spawner.dices.Add(copy.GetComponent<Dice>());
                                    }
                                    // 두 다이스가 같은 다이스라면
                                    else
                                    {
                                        // 합쳐질 때 눈금을 올리기 위해 임의로 hitdice의 눈금을 올린다
                                        int remain = hitdice.eyes;
                                        remain++;
                                        Debug.Log("조합");    // 조합이 이뤄지는지 체크하기위한 로그
                                        Destroy(hittOB.GetChild(0).gameObject);     // 클릭했었던 다이스 파괴
                                        Destroy(hitOB.GetChild(0).gameObject);      // 떼어 냈을 때 다이스 파괴
                                        // 다이스 랜덤 생성 떼어냈을 때의 위치에서
                                        var temp = dice[Random.Range(0, dice.Length)];
                                        var diceGO = Instantiate(temp, hitOB);
                                        // 다이스 눈금 올려주는 과정
                                        var newDice = diceGO.GetComponent<Dice>();
                                        newDice.eyes = remain;
                                        // SetDiceEye = 다이스 자식에 각 눈금별로 자식을 생성 해뒀기에 눈금에 맞는 자식을 활성화 시켜주는 함수
                                        newDice.SetDiceEye();
                                        GameManager.instance.spawner.dices.Add(newDice);
                                    }
                                }
                            }
                            else // 예외처리
                            {
                                selectDice.transform.localPosition = Vector3.zero;
                            }
                        }
                        else // 예외처리
                        {
                            selectDice.transform.localPosition = Vector3.zero;
                        }
                    }
                    else // 예외처리
                    {
                        selectDice.transform.localPosition = Vector3.zero;
                    }

                    selectDice = null;
                }
            }
        }
    }
}
