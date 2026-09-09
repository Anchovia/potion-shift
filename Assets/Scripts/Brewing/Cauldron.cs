using System.Collections.Generic;
using UnityEngine;

// 가마솥. 약초를 받아 온도를 설정해 가동하면 액체를 만든다.
// 기획서 6-1 「가마솥 제작의 진행과 완료」, 「투입·가동·병입 조작」, 6-3 「기본 조합의 반응 비율」.
public class Cauldron : MonoBehaviour, IReceiver, IInteractable
{
    // 장비 사양 (Inspector에서 조정)
    [SerializeField] private ElementDatabase elementDatabase;
    [SerializeField] private int capacity = 64;             // 최대 투입 단위 (6-1 일괄 제조)
    [SerializeField] private float secondsPerUnit = 4f;     // 단위당 제작 초 (6-1)

    // 상태
    private CauldronState state = CauldronState.Idle;
    private Dictionary<Element, int> contents = new Dictionary<Element, int>();   // 투입 내용: 원소별 단위
    private Temperature selectedTemperature = Temperature.Mid;
    private float remainingTime;
    private Liquid result;   // Done 상태에서 담겨 있는 액체

    public CauldronState State => state;
    public Liquid Result => result;

    // ---------- 투입 (좌클릭, IReceiver) ----------

    public bool TryReceive(GameObject item)
    {
        if (state != CauldronState.Idle)
        {
            Debug.Log("가동 중이거나 완성 액체가 남아 있어 투입할 수 없다");
            return false;
        }

        HerbItem herb = item.GetComponent<HerbItem>();
        if (herb == null) return false;

        Element element = herb.data.element;

        // 세 번째 원소 차단 (6-3)
        if (!contents.ContainsKey(element) && contents.Count >= 2)
        {
            Debug.Log("세 종류 이상의 원소는 넣을 수 없다");
            return false;
        }

        // 용량 초과 차단 (6-1)
        if (TotalUnits() >= capacity)
        {
            Debug.Log($"가마솥이 가득 찼다 ({capacity}단위)");
            return false;
        }

        if (!contents.ContainsKey(element)) contents[element] = 0;
        contents[element] += 1;   // 약초 1개 = 원소 1단위 (6-1)

        Destroy(item);
        Debug.Log($"투입: {ContentsText()}");
        return true;
    }

    // ---------- 가동 (E, IInteractable) ----------

    public string GetPrompt()
    {
        return "E · 가마솥";
    }

    // 임시: 패널 UI가 생기기 전까지 E를 누르면 현재 온도로 바로 가동
    public void Interact()
    {
        if (state == CauldronState.Idle)
        {
            TryStartBrew(selectedTemperature);
        }
        else if (state == CauldronState.Done)
        {
            Debug.Log($"완성 액체: {DescribeResult()}");
        }
    }

    // 가동 조건: 단일 원소이거나 두 원소의 양이 같을 때 (6-1)
    public bool CanBrew()
    {
        if (contents.Count == 0) return false;
        if (contents.Count == 1) return true;

        int[] amounts = new int[2];
        contents.Values.CopyTo(amounts, 0);
        return amounts[0] == amounts[1];
    }

    public bool TryStartBrew(Temperature temperature)
    {
        if (state != CauldronState.Idle) return false;
        if (!CanBrew())
        {
            Debug.Log($"가동 불가: {ContentsText()} — 두 원소의 양을 맞춰야 한다");
            return false;
        }

        selectedTemperature = temperature;
        remainingTime = TotalUnits() * secondsPerUnit;   // 시간 = 단위 수 × 단위당 초 (6-1)
        state = CauldronState.Brewing;
        Debug.Log($"가동 시작: {ContentsText()}, 온도 {temperature}, {remainingTime}초");
        return true;
    }

    void Update()
    {
        if (state != CauldronState.Brewing) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            Finish();
        }
    }

    // 가동 완료: 반응 계산과 온도 판정
    private void Finish()
    {
        // 결과 원소와 양 결정 (6-3: 1:1 반응, 합계 유지)
        Element resultElement;
        int resultAmount = TotalUnits();

        if (contents.Count == 1)
        {
            resultElement = GetSingleElement();
        }
        else
        {
            Element[] pair = new Element[2];
            contents.Keys.CopyTo(pair, 0);
            if (!Reaction.TryGetResult(pair[0], pair[1], out resultElement))
            {
                Debug.LogError($"반응 규칙이 없는 조합: {pair[0]} + {pair[1]}");
                resultElement = pair[0];
            }
        }

        // 온도 판정 (6-1 「온도 판정」 표)
        Temperature proper = elementDatabase.Get(resultElement).properTemperature;
        Quality quality = selectedTemperature < proper ? Quality.Poor : Quality.Good;
        bool sideEffect = selectedTemperature > proper;

        result = new Liquid
        {
            element = resultElement,
            amount = resultAmount,
            quality = quality,
            hasSideEffect = sideEffect
        };

        contents.Clear();
        state = CauldronState.Done;
        Debug.Log($"가동 완료: {DescribeResult()}");
    }

    // ---------- 보조 ----------

    private int TotalUnits()
    {
        int total = 0;
        foreach (int amount in contents.Values) total += amount;
        return total;
    }

    private Element GetSingleElement()
    {
        foreach (Element e in contents.Keys) return e;
        return Element.Fire;
    }

    private string ContentsText()
    {
        if (contents.Count == 0) return "비어 있음";
        List<string> parts = new List<string>();
        foreach (KeyValuePair<Element, int> pair in contents)
        {
            parts.Add($"{pair.Key} {pair.Value}");
        }
        return string.Join(" · ", parts);
    }

    private string DescribeResult()
    {
        if (result == null) return "없음";
        string name = elementDatabase.Get(result.element).potionName;
        string q = result.quality == Quality.Good ? "양호" : "저하";
        string s = result.hasSideEffect ? "부작용 있음" : "부작용 없음";
        return $"{name} {result.amount}단위, 품질 {q}, {s}";
    }
}