using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    // 상호작용 설정 (Inspector에서 조정)
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform holdPoint;             // 손 위치
    [SerializeField] private float interactDistance = 2.5f;   // 손이 닿는 거리 (미터)

    // 입력 액션
    private InputAction interactAction;   // E: 시설 사용
    private InputAction useAction;        // 좌클릭: 물건 다루기
    private InputAction dropAction;       // G: 내려놓기

    // 내부 상태
    private IInteractable current;   // 지금 바라보고 있는 시설, 없으면 null
    private IPickable held;          // 지금 들고 있는 물건, 없으면 null

    // 생성 직후 한 번, 참조 준비
    void Awake()
    {
        interactAction = actions.FindAction("Interact");
        useAction = actions.FindAction("Use");
        dropAction = actions.FindAction("Drop");
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
        // 카메라 정면으로 레이를 쏴서 바라보는 물체 찾기
        GameObject hitObject = null;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactDistance))
        {
            hitObject = hit.collider.gameObject;
        }
        current = hitObject != null ? hitObject.GetComponent<IInteractable>() : null;

        // E: 시설이 있으면 사용
        if (current != null && interactAction.WasPressedThisFrame())
        {
            current.Interact();
        }

        // 좌클릭: 빈손이면 집기, 들고 있으면 바라보는 기구에 넣기
        if (useAction.WasPressedThisFrame() && hitObject != null)
        {
            if (held == null)
            {
                IPickable pickable = hitObject.GetComponent<IPickable>();
                if (pickable != null)
                {
                    held = pickable;
                    held.OnPickedUp(holdPoint);
                }
            }
            else
            {
                IReceiver receiver = hitObject.GetComponent<IReceiver>();
                if (receiver != null && receiver.TryReceive(held.GetGameObject()))
                {
                    held = null;   // 기구가 받았으면 손 비우기
                }
            }
        }

        // G: 들고 있으면 놓기
        if (held != null && dropAction.WasPressedThisFrame())
        {
            held.OnDropped();
            held = null;
        }
    }
}