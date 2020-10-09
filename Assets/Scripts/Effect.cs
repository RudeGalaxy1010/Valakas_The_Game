using System.Collections;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float LifeTime = 1f;

    private void Start()
    {
        StartCoroutine(Timer(LifeTime));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
