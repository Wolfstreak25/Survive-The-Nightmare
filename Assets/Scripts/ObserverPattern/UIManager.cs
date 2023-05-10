using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

    public class UIManager : Singleton<UIManager>
    {
        [Header("Acheivement Panel")]
        [SerializeField] private GameObject AcheivementPanel;
        [SerializeField] private TextMeshProUGUI Achievement;
        [SerializeField] private TextMeshProUGUI WaveStatus;
        [Header("Update Panel")]
        [SerializeField] private GameObject UpdatePanel;
        [SerializeField] private TextMeshProUGUI Ammo;
        [SerializeField] private TextMeshProUGUI Score;
        [SerializeField] private TextMeshProUGUI Kills;
        [Header("Game Status Panel")]
        [SerializeField] private GameObject GameStatusPanel;
        [SerializeField] private TextMeshProUGUI GameStatus;
        //[SerializeField] private int TotalBulletCount = 10;
        private int KillCount = 0;
        private int score = 0;
        private void Start()
        {
            EventManagement.Instance.OnPlayerShoot += BulletCount;
            EventManagement.Instance.OnEnemyDeath += EnemyDeath;
            EventManagement.Instance.OnPlayerDeath += PlayerDeath;
            EventManagement.Instance.OnWaveComplete += WaveComplete;
        }
        private void OnDisable()
        {
            EventManagement.Instance.OnPlayerShoot -= BulletCount;
            EventManagement.Instance.OnEnemyDeath -= EnemyDeath;
            EventManagement.Instance.OnPlayerDeath -= PlayerDeath;
            EventManagement.Instance.OnWaveComplete -= WaveComplete;
        }
        public void BulletCount(PlayerController controller)
        {
            if(controller.Model.Ammo > 0)
            {
                Ammo.text = $"Ammo [{controller.Model.Ammo}]";
            }
            else
            {
                Ammo.text = $"Empty";
            }
        }
        public void EnemyDeath()
        {
            KillCount++;
            score += 50;
            Score.text = $"Score: {score}";
            Kills.text = $"Kill: {KillCount}";
        }
        public void PlayerDeath()
        {
            Time.timeScale = 0;
            GameStatusPanel.SetActive(true);
            GameStatus.text = "Game Over";
        }
        public async void WaveComplete(int wave)
        {
            AcheivementPanel.SetActive(true);
            WaveStatus.gameObject.SetActive(true);
            WaveStatus.text = wave + " Wave Complete";
            await Task.Delay(2000);
            WaveStatus.gameObject.SetActive(false);
            AcheivementPanel.SetActive(false);
            if(wave == 6)
            {
                GameStatusPanel.SetActive(true);
                GameStatus.text = "Level Complete";
            }
        }
        public IEnumerator ShowAchievement(string achievement)
        {
            AcheivementPanel.SetActive(true);
            WaveStatus.gameObject.SetActive(true);
            Achievement.text = achievement;
            yield return new  WaitForSeconds(2f);
            WaveStatus.gameObject.SetActive(false);
            AcheivementPanel.SetActive(false);
        }
        
    }

