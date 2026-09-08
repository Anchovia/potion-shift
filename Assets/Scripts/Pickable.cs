using UnityEngine;

// 좌클릭으로 집을 수 있는 물건. Rigidbody가 있는 오브젝트에 붙인다.
public class Pickable : MonoBehaviour, IPickable
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnPickedUp(Transform holdPoint)
    {
        rb.isKinematic = true;                 // 물리 계산 중단 (안 떨어지게)
        transform.SetParent(holdPoint);        // 손 위치의 자식으로
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void OnDropped()
    {
        transform.SetParent(null);             // 부모 해제, 월드로 복귀
        rb.isKinematic = false;                // 물리 재개 (떨어짐)
    }
}