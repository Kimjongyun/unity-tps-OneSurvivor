
using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    private PlayerInput playerInput;
    private CharacterController playerController;
    private Animator playerAnimator;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerController = FindAnyObjectByType<CharacterController>();
        playerAnimator = FindAnyObjectByType<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        groundedPlayer = playerController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal Move
        Vector3 forward = transform.forward * playerInput.moveZ;
        Vector3 right = transform.right * playerInput.moveX;

        Vector3 moveDir = (forward + right).normalized;

        // 수평 이동 (x, z)
        Vector3 horizontalMove = moveDir * moveSpeed;

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        Vector3 verticalMove = Vector3.up * playerVelocity.y;

        // Combine horizontal & vertical movement

        playerController.Move((horizontalMove + verticalMove) * Time.deltaTime);
        playerAnimator.SetFloat("moveSpeed", playerInput.moveZ);
    }
}