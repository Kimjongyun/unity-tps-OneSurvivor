
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

        // Horizontal input
        Vector3 forward = transform.forward * playerInput.moveZ;
        Vector3 right = transform.right * playerInput.moveX;

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal & vertical movement
        Vector3 moveDir = (forward + right).normalized;
        Vector3 finalMove = (moveDir * moveSpeed) + (playerVelocity.y * Vector3.up);

        playerController.Move(finalMove * Time.deltaTime);
        playerAnimator.SetFloat("moveSpeed", playerInput.moveZ);
    }

    private void Rotate()
    {

    }
}