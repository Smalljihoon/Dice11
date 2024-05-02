using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerDice : Dice
{
    protected override void Start()
    {
        // 조커 다이스의 능력은 같은 눈금이라면 조합을 통해 피격 다이스와 동일하게 바뀌는 능력이므로 FusionManager에서 처리함
        // 총알은 오브젝트 풀링
        category = Dice_category.Joker;
        bulletColor = new Color(Random.value, Random.value, Random.value);                        // 총알 색상을 눈금 색과 맞춤
    }
    
    // 이 외는 Dice와 동일
}
