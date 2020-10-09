using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour
{
                public float Value = 1f;
                public uint Damage = 1;

    [Space(10)] public GameObject CrushEffectPrefab;
                public Transform CrushEffectPlace;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bomb bomb))
        {
            return;
        }

        Instantiate(CrushEffectPrefab, CrushEffectPlace.position, Quaternion.identity);
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            //Player
            GameManager.Instance.IncBossValue(Value);
        }
        else
        {
            //Aircraft
            GameManager.Instance.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
