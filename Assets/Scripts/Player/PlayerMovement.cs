using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // 이동 설정 (Inspector에서 조정)
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -9.81f;
    private float verticalVelocity;

    // 입력 액션 (Awake에서 에셋에서 찾아둠)
    [SerializeField] private InputActionAsset actions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    // 이동을 실제로 수행하는 컴포넌트
    private CharacterController controller;

    // 생성 직후 한 번, 참조 준비
    void Awake()
    {
        controller = GetComponent<CharacterController>();

        moveAction = actions.FindAction("Move");
        jumpAction = actions.FindAction("Jump");
        sprintAction = actions.FindAction("Sprint");
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

    // Update is called once per frame
    void Update()
    {
        // 입력 읽기
        Vector2 input = moveAction.ReadValue<Vector2>();
        bool isSprinting = sprintAction.IsPressed();

        // 속도 정하기
        float speed = isSprinting ? sprintSpeed : walkSpeed;

        // 수평 방향 (플레이어가 바라보는 기준)
        Vector3 horizontal = transform.right * input.x + transform.forward * input.y;

        // 수직 처리
        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        // 점프 처리
        if (controller.isGrounded && jumpAction.WasPressedThisFrame())
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        verticalVelocity += gravity * Time.deltaTime;

        // 합쳐서 이동
        Vector3 velocity = horizontal * speed + Vector3.up * verticalVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
}
