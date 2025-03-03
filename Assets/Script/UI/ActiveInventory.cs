using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNum = 0;
    private PlayerControls playerControls;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSLot((int)ctx.ReadValue<float>());

        ToggleActiveHighlight(0); 
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void ToggleActiveSLot(int numValue)
    {
        ToggleActiveHighlight(numValue -1);
    }
    private void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndexNum = indexNum;
        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);

        ChangeActiveWeapon();
    }
    private void ChangeActiveWeapon()
    {
        if(ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
        }
        if (!transform.GetChild(activeSlotIndexNum).GetComponentInChildren<InventorySlot>().GetWeaponinfo()==null)
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }
        GameObject weaponToSpawn = transform.GetChild(activeSlotIndexNum).
        GetComponentInChildren<InventorySlot>().GetWeaponinfo().weaponPrefab; 

        GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform.position,Quaternion.identity);
        
        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        newWeapon.transform.parent = ActiveWeapon.Instance.transform;

        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }
}
