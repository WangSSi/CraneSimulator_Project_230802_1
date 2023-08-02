using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Right_Joystick : MonoBehaviour
{
    public Transform topJystick; //우츨 조이스틱의 Transform

    [SerializeField]
    private float forwardTilt = 0;  //조이스틱 회전값 전/후방
    [SerializeField]
    private float sideTilt = 0;  //조이스틱 회전값 좌/우
    [SerializeField]
    float forwardTilt_ver = 0;   //조이스틱 회전값 전/후방 의 절댓값
    [SerializeField]
    float SideTilt_ver = 0;  //조이스틱 회전값 좌/우 의 절댓값


    private void Start()
    {
        MainHookCableSpawn.Right_Joystick_Front = false; //조이스틱 전방 이벤트 실행 트리거 역할
        MainHookCableSpawn.Right_Joystick_Back = false; //조이스틱 후방 이벤트 실행 트리거 역할
        Crane_Operating_manager.Right_Joystick_Right = false; //조이스틱 우측 이벤트 실행 트리거 역할
        Crane_Operating_manager.Right_Joystick_Left = false; //조이스틱 좌측 이벤트 실행 트리거 역할
    }
    private void Update()
    {
        forwardTilt = topJystick.rotation.eulerAngles.x;
        sideTilt = topJystick.rotation.eulerAngles.z;

        forwardTilt_ver = Math.Abs(Math.Abs(forwardTilt - 180) - 180);
        SideTilt_ver = Math.Abs(sideTilt - 180);
        if (forwardTilt_ver > SideTilt_ver)  //조이스틱 전/후방 기울어진 각도가 더 클때 실행
        {
            if (forwardTilt > 10 && forwardTilt < 74) //front 방향으로 조이스틱 각도가 10~74도 기울어 졌을경우
            {
                MainHookCableSpawn.Right_Joystick_Front = true; //조이스틱 전방 이벤트 실행 true
                MainHookCableSpawn.Right_Joystick_Back = false;
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
            else if (forwardTilt < 350 && forwardTilt > 290) //back 방향으로 조이스틱 각도가 10~74도 기울어 졌을경우
            {

                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = true; //조이스틱 후방 이벤트 실행 true
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
            else //10도 이상 기울어지지 않았다면 이벤트 미 실행
            {
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
        }
        if (forwardTilt_ver < SideTilt_ver)  //조이스틱 좌/우 기울어진 각도가 더 클때 실행
        {

            if (sideTilt < 170 && sideTilt > 110) //right 방향으로 조이스틱 각도가 10~74도 기울어 졌을경우
            {
                Crane_Operating_manager.Right_Joystick_Right = true;  //조이스틱 우측 이벤트 실행 true
                Crane_Operating_manager.Right_Joystick_Left = false;
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
            }
            else if (sideTilt > 190 && sideTilt < 250) //left 방향으로 조이스틱 각도가 10~74도 기울어 졌을경우
            {
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = true;  //조이스틱 좌측 이벤트 실행 true
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
            }
            else  //10도 이상 기울어지지 않았다면 이벤트 미 실행
            {
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
        }
        
    }

    private void OnTriggerStay(Collider other) // 테스트를 위한: 플레이어의 손 역할 오브젝트가 닿았을때 손을 바라보며 transform 값은 (0,1,0) 기준으로 적용
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}

