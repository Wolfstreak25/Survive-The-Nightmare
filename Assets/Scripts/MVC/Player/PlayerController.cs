using UnityEngine;
using UnityEngine.UI;
public class PlayerController
{
    private DamagableType Type;
    public PlayerModel Model{get; private set;}
    public PlayerView View{get; private set;}
    private Rigidbody rb;
    private Button FireButton;
    private int countBullet;
    private bool isFiring = false;
    private float RayLength = 100f;
    private Vector3 movement; 
    public Animator animator{get;private set;}
    private void OnDisable() 
    {
           EventManagement.Instance.OnEnemyDeath -= AmmoDrop;
    }
    public PlayerController(PlayerModel Playermodel, PlayerView _view)
    {
        this.Model = Playermodel;
        View = GameObject.Instantiate<PlayerView>(_view);
        rb = View.GetComponent<Rigidbody>();
        this.View.SetController(this);
        this.Model.SetController(this);
        animator = View.GetComponent<Animator>();
        Model.Ammo = 100;
        EventManagement.Instance.OnEnemyDeath += AmmoDrop;
        PlayerFollow.Instance.GetCamera(View.transform);
    }

   public async void Fire()
    {
        if(!isFiring && Model.Ammo > 0)
        {
            isFiring = true;
            BulletService.Instance.SpawnBullet(View.bulletSpawner.transform , Model.Type);
            Model.Ammo --;
            countBullet++;
            EventManagement.Instance.PlayerShoot(this);
            await System.Threading.Tasks.Task.Delay(100);
            isFiring = false;
        }
    }
    public void Move(float h, float v)
    {
            movement.Set (h, 0f, v);
            movement = movement.normalized * Model.Speed * Time.deltaTime;
            rb.MovePosition (View.transform.position + movement);
    }
    public void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast (camRay, out floorHit, RayLength))
        {
            Vector3 playerToMouse = floorHit.point - View.transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);
            rb.MoveRotation (newRotatation);
        }
    }
    public void GetDamage(float damage, DamagableType type)
    {
        if(Model.Type == type)
            return;
        Model.Health -= damage;
        if(Model.Health <= 0)
        {
            View.DestroyObj();
            EventManagement.Instance.PlayerDeath();
        }
    }
    public void AmmoDrop()
    {
        Model.Ammo += 5;
    }
}
