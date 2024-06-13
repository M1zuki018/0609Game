using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TakinokoAnimation : MonoBehaviour
{
    public float speed;
    public TurnInterval turnInterval;
    public IdleDuration idleDuration;
    [SerializeField] BoxCollider2D moveBounds;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Animator animator;
    Coroutine coroutine;

    public bool isGoal, isMovingCenter, walkingRandom;
    [SerializeField] Vector3 moveVector;

    private void Start()
    {
        moveBounds = GameObject.Find("MoveBounds").GetComponent<BoxCollider2D>();

        coroutine = StartCoroutine(Move());
        walkingRandom = true;
    }

    private void Update()
    {
        //transform.Translate(moveDir * Time.deltaTime);
        rb.velocity = moveVector;

        if (!isGoal)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if ((info.IsName("Walk") || info.IsName("Idle")) && !isMovingCenter)
            {
                walkingRandom = true;

            }
            else
            {
                walkingRandom = false;
            }


            var bounds = moveBounds.bounds;
            //”ÍˆÍŠO‚És‚©‚È‚¢ˆ—
            if (!bounds.Contains(transform.position))
            {
                if ((walkingRandom || moveVector.magnitude == 0) && !info.IsName("Drag") && !info.IsName("Idle") && !info.IsName("Drop"))
                {
                    var min = bounds.min;
                    var max = bounds.max;

                    moveVector = Quaternion.Euler(0, 0, Random.Range(-30, 30)) * (moveBounds.bounds.center - transform.position).normalized * speed;

                    isMovingCenter = true;
                }
            }
            else
            {
                isMovingCenter = false;
            }
        }
    }

    public void StartDrag()
    {
        StopCoroutine(coroutine);
        animator.SetTrigger("StartDrag");
        moveVector = Vector2.zero;
    }

    public void StartDrop()
    {
        coroutine = StartCoroutine(Move());
        animator.SetTrigger("StartDrop");
        //moveVector = Vector2.zero;
    }

    public void SetMoveCondition(int state)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if ((info.IsName("Walk") || info.IsName("Idle")) && !isGoal)
        {
            animator.SetInteger("MoveCondition", state);
            if (state == 0)
            {
                //Debug.Log("’âŽ~");
                moveVector = Vector2.zero;
            }
            else if (state == 1)
            {
                //Debug.Log("ˆÚ“®");
                moveVector = Quaternion.Euler(0, 0, Random.Range(-360, 360)) * (moveBounds.bounds.center - transform.position).normalized * speed;
            }
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
        isGoal = true;
        isMovingCenter = false;
        walkingRandom = false;
        moveVector = new Vector2(speedX, 0);
        animator.SetInteger("MoveCondition", 1);

        Destroy(gameObject, 2);
    }


    IEnumerator Move()
    {
        while (walkingRandom && !isMovingCenter)
        {
            SetMoveCondition(1);
            var walkSeconds = Random.Range(turnInterval.min, turnInterval.max);
            yield return new WaitForSeconds(walkSeconds);


            SetMoveCondition(0);
            var waitSeconds = Random.Range(idleDuration.min, idleDuration.max);
            yield return new WaitForSeconds(waitSeconds);
        }


        yield return new WaitUntil(() => walkingRandom);
        coroutine = StartCoroutine(Move());
    }
}

[Serializable]
public class TurnInterval
{
    public float min, max;
}

[Serializable]
public class IdleDuration
{
    public float min, max;
}
