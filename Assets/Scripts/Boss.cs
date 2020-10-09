using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [HideInInspector] public UnityAction BossDefeated;

                public int Health = 5;
                public float Time = 0.7f;
    [Space(10)] public GameObject BombPrefab;
                public Transform SpawnZone;
                public Animator bossAnimator;


    private List<GameObject> bombs = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < Health; i++)
        {
            var newPosition = Vector3.zero;
            if (bombs.Count % 8 != 0)
            {
                var indent = Vector3.right * bombs.Last().transform.localScale.x * 2;
                newPosition = bombs.Last().transform.position + indent;
            }
            else
            {
                newPosition = SpawnZone.transform.position - Vector3.right * 3f;
            }
            bombs.Add(Instantiate(BombPrefab, newPosition, Quaternion.identity));
            bombs.Last().GetComponent<Rigidbody2D>().isKinematic = true;
        }

        StartCoroutine(Spawn(Time));
    }

    private IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);
        if (bombs.Count > 0)
        {
            var bomb = bombs[0];
            bombs.Remove(bomb);
            bomb.GetComponent<Rigidbody2D>().isKinematic = false;
            StartCoroutine(Spawn(time));
        }
        else
        {
            bossAnimator.SetTrigger("Defeated");
            BossDefeated?.Invoke();
            Destroy(gameObject, 2f);
        }
    }
}
