using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public List<GameObject> BombPrefabs = new List<GameObject>();
    public List<GameObject> BossPrefabs = new List<GameObject>();
    public GameObject SpawnZone;
    public float Time = 1f;

    private float Border;

    private GameObject boss;
    private Coroutine spawnCoroutine;

    private void Start()
    {
        Border = gameObject.transform.localScale.x / 2;
        spawnCoroutine = StartCoroutine(Spawn(BombPrefabs));
    }

    public void SpawnBoss(int index = 0)
    {
        StopCoroutine(spawnCoroutine);
        boss = Instantiate(BossPrefabs[Random.Range(0, BossPrefabs.Count)]);
        boss.GetComponent<Boss>().BossDefeated += BossDefeated;
    }

    private void BossDefeated()
    {
        //TODO: Try this
        boss.GetComponent<Boss>().BossDefeated -= BossDefeated;
        spawnCoroutine = StartCoroutine(Spawn(BombPrefabs));
    }

    private IEnumerator Spawn(List<GameObject> prefabs)
    {
        yield return new WaitForSeconds(Time);
        var prefab = prefabs[Random.Range(0, BombPrefabs.Count)];
        var newBomb = Instantiate(prefab, transform.position, Quaternion.identity);
        newBomb.transform.position += Vector3.right * (Random.Range(-Border * 100, Border * 100) / 100f);
        spawnCoroutine = StartCoroutine(Spawn(prefabs));
    }
}
