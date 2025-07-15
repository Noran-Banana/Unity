using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update

    public float Move_Speed = 0.01f;
    public float checkDistance = 0.55f;

    bool isJumping = false;

    int jumpCount = 2;    


    Rigidbody2D rb;

    //유니티 에디터의 프레임을 우리가 임의로 지정한 프레임으로 설정해주는 변수
    //public int frameRate = 60;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //유니티 에디터의 프레임을 우리가 임의로 지정한 프레임으로 설정
        //Application.targetFrameRate = frameRate;
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * Vector3.right * Move_Speed;
            Debug.Log("오른쪽");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * Vector3.left * Move_Speed;
            Debug.Log("왼쪽");
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, LayerMask.GetMask("Ground"));
        
        if (hit.collider == null)
        {
            //isJumping = false; //RayCast에 인식된 Ground가 있다면 null

            ResetTwo(); //점프 가능 횟수를 2번으로 바꿔주는 함수
            // ResetThree(); //점프 가능 횟수를 3번으로 바꿔주는 함수

        }

        Debug.DrawRay(transform.position, Vector2.down *checkDistance, Color.red);
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >= 1)
        {
            Jump();
        }

    }

    public void Jump()
    {
        if (isJumping is false) isJumping = true;

        rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
        jumpCount -= 1;

    }

    public void ResetTwo()
    {
        jumpCount = 2;
    }

    public void ResetThree()
    {
        jumpCount = 3;
    }
}
