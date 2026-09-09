// 기본 원소 두 종류의 반응 규칙. 기획서 6-3 「복합 원소 조합」.
public static class Reaction
{
    // 두 기본 원소가 반응해 만드는 복합 원소. 순서 무관.
    // 조합이 없으면 false.
    public static bool TryGetResult(Element a, Element b, out Element result)
    {
        // 순서를 통일해서 (Fire, Wind)와 (Wind, Fire)를 같은 경우로 다룬다
        if (a > b)
        {
            (a, b) = (b, a);
        }

        if (a == Element.Fire && b == Element.Water) { result = Element.Change; return true; }
        if (a == Element.Fire && b == Element.Earth) { result = Element.Bind; return true; }
        if (a == Element.Fire && b == Element.Wind) { result = Element.Light; return true; }
        if (a == Element.Water && b == Element.Earth) { result = Element.Life; return true; }
        if (a == Element.Water && b == Element.Wind) { result = Element.Motion; return true; }
        if (a == Element.Earth && b == Element.Wind) { result = Element.Sense; return true; }

        result = a;
        return false;
    }
}