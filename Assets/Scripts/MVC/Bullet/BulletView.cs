using System.Collections;
using UnityEngine;
public class BulletView : MonoBehaviour
{
    [SerializeField] private ParticleSystem Explosion;
    private BulletController bulletController;
    public LayerMask PlayerMask;
    
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    private void OnCollisionEnter(Collision other) {
        
        StartCoroutine(DestroyBullet());
        bulletController.bulletContact(other.transform);
    }
    public IEnumerator DestroyBullet()
    {
        Explosion.Play();
        this.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        BulletPool.Instance.ReturnItem(this.bulletController);
        gameObject.SetActive(false);
    }
}
