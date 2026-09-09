using UnityEngine;

// 약초 한 종류의 데이터. Project 창에서 에셋으로 만들어 값을 채운다.
[CreateAssetMenu(menuName = "Potion Shift/Herb")]
public class HerbData : ScriptableObject
{
    public string displayName;   // 화면 표시 이름 (가칭)
    public Element element;      // 보유 원소
    public Rarity rarity;        // 희귀도 (프로토타입은 Common만)
}