using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private Weaponinfo Weaponinfo;

    public void Attack()
    {
        Debug.Log("Bow Attack");
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
    public Weaponinfo GetWeaponinfo()
    {
        return Weaponinfo;
    }
}
