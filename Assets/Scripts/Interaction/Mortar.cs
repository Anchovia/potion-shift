using UnityEngine;

public class Mortar : MonoBehaviour, IReceiver
{
    private int herbCount;   // 들어 있는 약재 수

    public bool TryReceive(GameObject item)
    {
        HerbItem herb = item.GetComponent<HerbItem>();
        if (herb == null) return false;   // 약초가 아니면 거부

        herbCount++;
        Debug.Log($"절구에 {herb.data.displayName} 투입. 현재 {herbCount}개");
        Destroy(item);
        return true;
    }
}