using UnityEngine;

// ElementData 10개를 모아 원소로 조회하는 데이터베이스.
[CreateAssetMenu(menuName = "Potion Shift/Element Database")]
public class ElementDatabase : ScriptableObject
{
    public ElementData[] elements;

    // 해당 원소의 데이터. 없으면 null.
    public ElementData Get(Element element)
    {
        foreach (ElementData data in elements)
        {
            if (data.element == element) return data;
        }
        return null;
    }
}