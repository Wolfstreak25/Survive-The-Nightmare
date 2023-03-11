using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject AcheivementPanel;
        [SerializeField] private GameObject UpdatePanel;
        [SerializeField] private TextMeshProUGUI Ammo;
        [SerializeField] private TextMeshProUGUI Score;
        [SerializeField] private TextMeshProUGUI Kills;
        [SerializeField] private TextMeshProUGUI WaveStatus;
        [SerializeField] private TextMeshProUGUI Achievement;
        [SerializeField] private GameObject GameStatusPanel;
        [SerializeField] private TextMeshProUGUI GameStatus;
        [SerializeField] private int TotalBulletCount = 10;
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
            if(controller.Model.Ammo >0)
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
        public async void WaveComplete(int wave)
        {
            AcheivementPanel.SetActive(true);
            WaveStatus.text = wave + " Wave Complete";
            await Task.Delay(10);
            AcheivementPanel.SetActive(false);
            if(wave == 6)
            {
                GameStatusPanel.SetActive(true);
                GameStatus.text = "Level Complete";
            }

        }
        public void PlayerDeath()
        {
            GameStatusPanel.SetActive(true);
            GameStatus.text = "Game Over";
        }
        public IEnumerator ShowAchievement(string achievement)
        {
            AcheivementPanel.SetActive(true);
            Achievement.enabled = true;
            Achievement.text = achievement;
            
            yield return new  WaitForSeconds(2f);
            Achievement.enabled = false;
            AcheivementPanel.SetActive(false);
        }
        
    }

