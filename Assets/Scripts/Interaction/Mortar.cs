using UnityEngine;

public class Mortar : MonoBehaviour, IReceiver
{
    private int herbCount;   // 들어 있는 약재 수

    public bool TryReceive(GameObject item)
    {
        herbCount++;
        Destroy(item);   // 지금은 오브젝트를 없애는 것으로 "들어갔다"를 표현
        Debug.Log($"절구에 약재 투입. 현재 {herbCount}개");
        return true;
    }
}