using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public float Speed = 0.15f;
    [Header("How close player can be to the mouse")] public float Indent = 1f;
    [HideInInspector] public float Border = 2.85f;

    private Animator playerAnimator;
    private Rigidbody2D playerRB;
    private Vector2 Direction = Vector2.zero;


    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        StartCoroutine(EyesAnim());
    }

    private void Update()
    {
        Direction = Vector2.zero;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;

            if (delta > Indent)
            {
                Direction = Vector2.right;
            }
            else if (delta < -Indent)
            {
                Direction = Vector2.left;
            }
        }

        var borderedX = Mathf.Clamp((playerRB.position + Direction * Speed).x, -Border, Border);
        var newPosition = playerRB.position + Direction * Speed;
        newPosition = new Vector2(borderedX, newPosition.y);
        playerRB.MovePosition(newPosition);
    }

    private IEnumerator EyesAnim()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        playerAnimator.SetTrigger("CloseEyes");
        StartCoroutine(EyesAnim());
    }
}
