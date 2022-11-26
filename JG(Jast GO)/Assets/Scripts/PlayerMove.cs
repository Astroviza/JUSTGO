using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed; //скорость персонажа
    Rigidbody rb; //ссылка на Rigidbody
    Animator anim; //Добавляем ссылку на аниматор
    Vector3 direction; //Направление движения
    [SerializeField] float jumpSpeed; //высота прыжка
    bool isGrounded; //переменная, которая будет указывать на земле мы или нет
    Vector3 startPosition;

    bool slide = false;

    void Start()
    {
        startPosition=transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
 

    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);   

        if  ( transform.position.y < -10)
        {
            transform.position = startPosition;
        }

        if (direction.magnitude > 0)
        {
            anim.SetBool("Run", true);
        }
        else anim.SetBool("Run", false);

        if(isGrounded)
        {
        if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }
        if(slide)
        {
            rb.AddForce(direction * 0.05f, ForceMode.VelocityChange);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
            anim.SetBool("Jump", false); //Отключаем анимацию прыжка
        }

        if (other.gameObject.CompareTag("slide"))
        {
            //то 
            slide = true;
        }
        else slide = false;
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
        anim.SetBool("Jump", true); //Включаем анимацию прыжка
    }
private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("plates"))
    {
        Destroy(other.gameObject);
    }
    if (other.CompareTag("CheckPoint"))
    {
        startPosition = transform.position;
    }
}
}