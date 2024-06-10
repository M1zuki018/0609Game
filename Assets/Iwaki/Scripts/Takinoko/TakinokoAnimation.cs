using System.Collections;
using UnityEngine;

public class TakinokoAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start()
    {
        StartCoroutine(A());
    }

    public void StartDrag()
    {
        animator.SetTrigger("StartDrag");
    }
    public void StartDrop()
    {
        animator.SetTrigger("StartDrop");
    }

    public void SetMoveCondition(int state)
    {
        animator.SetInteger("MoveCondition", state);
    }

    IEnumerator A()
    {
        yield return new WaitForSeconds(2);
        SetMoveCondition(1);
        yield return new WaitForSeconds(2);
        StartDrag();
        yield return new WaitForSeconds(2);
        StartDrop();
        yield return new WaitForSeconds(2);
        SetMoveCondition(0);
    }
}
