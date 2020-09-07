using UnityEngine;
using System.Collections;

// 이 스크립트를 사용하기 위해서는 아래 컴포넌트가 필요합니다.
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Student : MonoBehaviour
{
    private Animator animator;       // 애니메이터

    void Start()
    {
        // 변수 초기화
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 캐릭터 이동
        Vector3 moveDir = Vector3.zero;
        bool aniPlayed = false;

        // 방향키에 따라 이동
        if (Input.GetKey(KeyCode.UpArrow))
        {
            aniPlayed = true;
            animator.Play("Student");
            moveDir += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            aniPlayed = true;
            animator.Play("Student");
            moveDir += Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (aniPlayed == false)
                animator.Play("Student");
            moveDir += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (aniPlayed == false)
                animator.Play("Student");
            moveDir += Vector3.right;
        }

        // 플레이어 좌표 변경
        transform.position += (moveDir * Time.deltaTime * 64);
    }
}