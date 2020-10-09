using UnityEngine;

public class GameManager : MonoBehaviour
{
                public static GameManager Instance;
                public BombSpawner BombSpawner;
    [Space(10)] public float BossValue = 10f;
                public int Score;
                public int Health = 3;

                private float bossValue = 0;


    private void Awake()
    {
        Instance = this;
    }

    public void IncBossValue(float value)
    {
        if (value > 0)
        {
            bossValue += value;
        }
        UpdateBossValue(bossValue);
    }

    public void TakeDamage(uint value)
    {
        Health -= (int)value;
        UIManager.Instance.UpdateHealth(Health);

        if (Health <= 0)
        {
            //You lose
        }
    }

    private void UpdateBossValue(float value)
    {
        if (value >= BossValue)
        {
            SpawnBoss();
            bossValue = 0;
            BossValue += 5;
        }

        Score++;
        UIManager.Instance.UpdateScoreText(Score);
    }

    private void SpawnBoss()
    {
        BombSpawner.SpawnBoss();
    }
}
