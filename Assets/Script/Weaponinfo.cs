using UnityEngine;

[CreateAssetMenu(menuName ="New Weapon")]
public class Weaponinfo : ScriptableObject
{
    public GameObject weaponPrefab;
    public float weaponCooldown;
}
