using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    private Weaponinfo weaponInfo;
    private Vector3 startPostition;
    private void Start()
    {
        startPostition = transform.position;    
    }
    private void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }
    public void UpdateWeaponInfo(Weaponinfo weaponinfo)
    {
        this.weaponInfo = weaponinfo;
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>(); 
        Indestructible indestructible = other.gameObject.GetComponent<Indestructible>();

        if(!other.isTrigger && (enemyHealth || indestructible))
        {
            enemyHealth?.TakeDamage(weaponInfo.weaponDamage);
            Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void DetectFireDistance()
    {
        if (Vector3.Distance(transform.position,startPostition) >weaponInfo.weaponRange)
        {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
