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
        Debug.Log(transform.GetChild(activeSlotIndexNum).GetComponent<InventorySlot>().GetWeaponinfo().weaponPrefab.name);
    }
}
