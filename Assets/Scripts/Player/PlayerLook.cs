using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    // 시점 설정 (Inspector에서 조정)
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float sensitivity = 0.1f;

    // 내부 상태
    private InputAction lookAction;
    private float pitch;   // 카메라 상하 각도 누적값

    // 생성 직후 한 번, 참조 준비
    void Awake()
    {
        lookAction = actions.FindAction("Look");
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

    // 게임 시작 시 커서를 화면 가운데에 잠금
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 이번 프레임 마우스 이동량 (픽셀)
        Vector2 delta = lookAction.ReadValue<Vector2>();

        // 좌우: 몸 전체를 Y축으로 회전
        transform.Rotate(Vector3.up * delta.x * sensitivity);

        // 상하: 카메라만 X축으로 회전, 뒤집히지 않게 제한
        pitch -= delta.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
