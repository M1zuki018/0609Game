using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class TakinokoAnimation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] TurnInterval turnInterval;
    [SerializeField] IdleDuration idleDuration;
    [SerializeField] BoxCollider2D moveBounds;

    Animator animator;
    Rigidbody2D rb;
    Coroutine coroutine;

    bool isGoal, isMovingCenter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveBounds = GameObject.Find("MoveBounds").GetComponent<BoxCollider2D>();

        coroutine = StartCoroutine(Move());
    }

    private void Update()
    {
        var bounds = moveBounds.bounds;
        //îÕàÕäOÇ…çsÇ©Ç»Ç¢èàóù
        if (!bounds.Contains(transform.position))
        {
            if (!isGoal && !isMovingCenter)
            {
                AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("Walk") || info.IsName("Idle"))
                {
                    StopCoroutine(coroutine);

                    var min = bounds.min;
                    var max = bounds.max;

                    rb.velocity = Quaternion.Euler(0, 0, Random.Range(-30, 30)) * (moveBounds.bounds.center - transform.position).normalized * speed;

                    isMovingCenter = true;
                }
            }
        }
        else
        {
            if (isMovingCenter)
            {
                coroutine = StartCoroutine(Move());
            }
            isMovingCenter = false;
        }
    }

    public void StartDrag()
    {
        animator.SetTrigger("StartDrag");
        rb.velocity = Vector2.zero;
        StopCoroutine(coroutine);
    }

    public void StartDrop()
    {
        animator.SetTrigger("StartDrop");
        rb.velocity = Vector2.zero;
        coroutine = StartCoroutine(Move());
    }

    public void SetMoveCondition(int state)
    {
        animator.SetInteger("MoveCondition", state);
        if (state == 0)
        {
            //Debug.Log("í‚é~");
            rb.velocity = Vector2.zero;
        }
        else if (state == 1)
        {
            //Debug.Log("à⁄ìÆ");
            var a = Quaternion.Euler(0, 0, Random.Range(-360, 360)) * (moveBounds.bounds.center - transform.position).normalized * speed;
            rb.velocity = a * speed;
        }
    }

    public void GoalLeft()
    {
        Goal(-speed);
    }

    public void GoalRight()
    {
        Goal(speed);
    }

    private void Goal(float speedX)
    {
        StopCoroutine(coroutine);
        animator.Play("Walk");
        rb.velocity = new Vector2(speedX, 0);
        Destroy(gameObject, 1);
        isGoal = true;
    }


    IEnumerator Move()
    {
        SetMoveCondition(1);
        var walkSeconds = Random.Range(turnInterval.min, turnInterval.max);
        yield return new WaitForSeconds(walkSeconds);

        SetMoveCondition(0);
        var waitSeconds = Random.Range(idleDuration.min, idleDuration.max);
        yield return new WaitForSeconds(waitSeconds);

        coroutine = StartCoroutine(Move());
    }
}

[Serializable]
class TurnInterval
{
    public float min, max;
}

[Serializable]
class IdleDuration
{
    public float min, max;
}
