using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    public Transform gunPivot;
    public Transform leftHandMount;
    public Transform rightHandMount;

    private PlayerInput playerInput;
    private Animator playerAnimator;

    private void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
        playerAnimator = FindAnyObjectByType<Animator>();
        // Debug.Log("LeftHandle Position: " + leftHandMount.position);
        // Debug.Log("RightHandle Position: " + rightHandMount.position);
    }

    // 슈터가 활성화될 때 총도 함께 활성화
    private void OnEnable()
    {
        gun.gameObject.SetActive(true);
    }

    // 슈터가 비활성화될 때 총도 함께 비활성화
    private void OnDisable()
    {
        gun.gameObject.SetActive(false);
    }

    private void update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        Debug.Log("IK 실행 중");
        // 총의 기준점 gunPivot을 3D 모델의 오른쪽 팔꿈치 위치로 이동
        gunPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK를 사용해 왼손의 위치와 회전을 총의 왼쪽 손잡이에 맞춤
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMount.rotation);

        // IK를 사용해 오른손의 위치와 회전을 총의 오른쪽 손잡이에 맞춤
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);
    }
}
