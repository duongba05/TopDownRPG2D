using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Weaponinfo weaponinfo;
    public Weaponinfo GetWeaponinfo() { return weaponinfo; }    
}
