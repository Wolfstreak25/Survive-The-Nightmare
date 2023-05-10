using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletService : Singleton<BulletService>
{
    [SerializeField] private BulletList bulletObjectList;
    private Transform spawn;
    private BulletPool bulletPool;
    public BulletView bulletView;
    private void Start()
    {
        bulletPool = this.gameObject.GetComponent<BulletPool>();
    }
    private void Update() {
        spawn = this.transform;
    }
    public void SpawnBullet(Transform bulletTransform,DamagableType shooter)
    {
        BulletController bullet = bulletPool.GetBullet(bulletObjectList.bullets[0], bulletTransform);
        bullet.ActivateObject(bulletTransform, shooter);
    }
}
