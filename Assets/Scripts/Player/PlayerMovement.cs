
using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 9f; // 앞뒤 움직임의 속도
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
        groundedPlayer = playerController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = new Vector3(playerInput.moveX, 0, playerInput.moveZ);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal & vertical movement
        Vector3 finalMove = (move * moveSpeed) + (playerVelocity.y * Vector3.up);

        playerController.Move(finalMove * Time.deltaTime);
        playerAnimator.SetFloat("moveSpeed", playerInput.moveZ);
    }
}