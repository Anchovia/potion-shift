using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    // 상호작용 설정 (Inspector에서 조정)
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float interactDistance = 2.5f;   // 손이 닿는 거리 (미터)

    // 내부 상태
    private InputAction interactAction;
    private IInteractable current;   // 지금 바라보고 있는 상호작용 대상, 없으면 null

    // 생성 직후 한 번, 참조 준비
    void Awake()
    {
        interactAction = actions.FindAction("Interact");
    }

    // 켜질 때, 입력 활성화
    void OnEnable()
    {
        actions.Enable();
    }

    // 꺼질 때, 입력 비활성화
    void OnDisable()
    {
        actions.Disable();
    }

    void Update()
    {
        // 1. 카메라 정면으로 레이를 쏴서 바라보는 물체 찾기
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactDistance))
        {
            current = hit.collider.GetComponent<IInteractable>();
        }
        else
        {
            current = null;
        }

        // 2. 상호작용 대상이 있고 E를 눌렀으면 실행
        if (current != null && interactAction.WasPressedThisFrame())
        {
            current.Interact();
        }
    }
}