using UnityEngine;

// 원소 한 종류의 데이터: 적정 온도와 그 원소로 만든 포션 이름.
[CreateAssetMenu(menuName = "Potion Shift/Element")]
public class ElementData : ScriptableObject
{
    public Element element;              // 어떤 원소인지
    public Temperature properTemperature; // 적정 온도 단계 (6-1 온도 판정 표)
    public string potionName;            // 이 원소로 만든 포션 이름 (6-6 초기 포션 목록)
}