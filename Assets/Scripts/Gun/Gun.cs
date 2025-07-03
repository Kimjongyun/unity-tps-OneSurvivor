using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }

    public State state { get; private set; }
    public Transform fireTransform;

    public ParticleSystem muzzleFlashEffect; // 총구 화염 효과
    public ParticleSystem shellEjectEffect; // 탄피 배출 효과
    private AudioSource gunAudioPlayer; // 총 소리 재생기

    public GunData gunData; // 총의 현재 데이터
    public int ammoRemain;
    public int magAmmo;
    public int lastFireTime;

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        ammoRemain = gunData.startAmmoRemain;
        magAmmo = gunData.magCapacity;

        state = State.Ready;
        lastFireTime = 0;
    }

    public void Fire()
    {

    }

    private void Shot()
    {
        
    }
}
