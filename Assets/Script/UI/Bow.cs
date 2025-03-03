using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private Weaponinfo Weaponinfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        GameObject newArrow = Instantiate(arrowPrefab,arrowSpawnPoint.position,ActiveWeapon.Instance.transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateWeaponInfo(Weaponinfo);
    }
    public Weaponinfo GetWeaponinfo()
    {
        return Weaponinfo;
    }
}
