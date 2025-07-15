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

    //����Ƽ �������� �������� �츮�� ���Ƿ� ������ ���������� �������ִ� ����
    //public int frameRate = 60;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //����Ƽ �������� �������� �츮�� ���Ƿ� ������ ���������� ����
        //Application.targetFrameRate = frameRate;
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * Vector3.right * Move_Speed;
            Debug.Log("������");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * Vector3.left * Move_Speed;
            Debug.Log("����");
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, LayerMask.GetMask("Ground"));
        
        if (hit.collider == null)
        {
            //isJumping = false; //RayCast�� �νĵ� Ground�� �ִٸ� null

            ResetTwo(); //���� ���� Ƚ���� 2������ �ٲ��ִ� �Լ�
            // ResetThree(); //���� ���� Ƚ���� 3������ �ٲ��ִ� �Լ�

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
