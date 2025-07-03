using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    public AudioClip shotClip;
    public AudioClip reloadClip;

    public float damage = 25;

    public int startAmmoRemain = 300;
    public int magCapacity = 12;

    public float timeBetFire = 0.5f;
    public float reloadTime = 1.8f;
}
