// 가마솥이 만들고 병에 담기는 액체 한 덩어리.
public class Liquid
{
    public Element element;      // 결과 원소 (기본 또는 복합)
    public int amount;           // 단위 수
    public Quality quality;      // 온도 판정: 양호/저하
    public bool hasSideEffect;   // 온도 판정: 부작용 유무
}