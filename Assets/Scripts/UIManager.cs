using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text ScoreText;
    public List<Image> Health = new List<Image>();

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void UpdateHealth(int health)
    {
        for (int i = 0; i < Health.Count; i++)
        {
            if (i > health)
            {
                Health[i].gameObject.SetActive(false);
            }
        }
    }
}
