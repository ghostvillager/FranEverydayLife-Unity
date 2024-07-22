using System.Collections;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        Debug.Log("攻撃開始！");
        animator.SetBool("Atack", true);
        yield return new WaitForSeconds(0.7f);
        Debug.Log("攻撃終了");
        animator.SetBool("Atack", false);
        isAttacking = false;
    }
}
