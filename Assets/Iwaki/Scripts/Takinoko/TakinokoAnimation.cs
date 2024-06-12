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

    [SerializeField] Animator animator;
    Coroutine coroutine;

    [SerializeField] bool isGoal, isMovingCenter, walkingRandom;

    [SerializeField] Vector3 moveDir;

    private void Start()
    {
        moveBounds = GameObject.Find("MoveBounds").GetComponent<BoxCollider2D>();

        coroutine = StartCoroutine(Move());
        walkingRandom = true;
    }

    private void Update()
    {
        transform.Translate(moveDir * Time.deltaTime);

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
                if ((walkingRandom || moveDir.magnitude == 0) && !info.IsName("Drag") && !info.IsName("Idle") && !info.IsName("Drop"))
                {
                    var min = bounds.min;
                    var max = bounds.max;

                    moveDir = Quaternion.Euler(0, 0, Random.Range(-30, 30)) * (moveBounds.bounds.center - transform.position).normalized * speed;

                    isMovingCenter = true;
                }
            }
            else
            {
                if (isMovingCenter)
                {
                    //coroutine = StartCoroutine(Move());
                }
                isMovingCenter = false;
            }
        }
    }

    public void StartDrag()
    {
        animator.SetTrigger("StartDrag");
        moveDir = Vector2.zero;
        //StopCoroutine(coroutine);
    }

    public void StartDrop()
    {
        animator.SetTrigger("StartDrop");
        moveDir = Vector2.zero;
        //coroutine = StartCoroutine(Move());
    }

    public void SetMoveCondition(int state)
    {
        animator.SetInteger("MoveCondition", state);
        if (state == 0)
        {
            //Debug.Log("’âŽ~");
            moveDir = Vector2.zero;
        }
        else if (state == 1)
        {
            //Debug.Log("ˆÚ“®");
            moveDir = Quaternion.Euler(0, 0, Random.Range(-360, 360)) * (moveBounds.bounds.center - transform.position).normalized * speed;
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
        //StopCoroutine(coroutine);
        walkingRandom = false;
        animator.Play("Walk");
        moveDir = new Vector2(speedX, 0);
        Destroy(gameObject, 1);
        isGoal = true;
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
        yield return Move();

        //coroutine = StartCoroutine(Move());
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
