using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Right_Joystick : MonoBehaviour
{
    public Transform topJystick; //���� ���̽�ƽ�� Transform

    [SerializeField]
    private float forwardTilt = 0;  //���̽�ƽ ȸ���� ��/�Ĺ�
    [SerializeField]
    private float sideTilt = 0;  //���̽�ƽ ȸ���� ��/��
    [SerializeField]
    float forwardTilt_ver = 0;   //���̽�ƽ ȸ���� ��/�Ĺ� �� ����
    [SerializeField]
    float SideTilt_ver = 0;  //���̽�ƽ ȸ���� ��/�� �� ����


    private void Start()
    {
        MainHookCableSpawn.Right_Joystick_Front = false; //���̽�ƽ ���� �̺�Ʈ ���� Ʈ���� ����
        MainHookCableSpawn.Right_Joystick_Back = false; //���̽�ƽ �Ĺ� �̺�Ʈ ���� Ʈ���� ����
        Crane_Operating_manager.Right_Joystick_Right = false; //���̽�ƽ ���� �̺�Ʈ ���� Ʈ���� ����
        Crane_Operating_manager.Right_Joystick_Left = false; //���̽�ƽ ���� �̺�Ʈ ���� Ʈ���� ����
    }
    private void Update()
    {
        forwardTilt = topJystick.rotation.eulerAngles.x;
        sideTilt = topJystick.rotation.eulerAngles.z;

        forwardTilt_ver = Math.Abs(Math.Abs(forwardTilt - 180) - 180);
        SideTilt_ver = Math.Abs(sideTilt - 180);
        if (forwardTilt_ver > SideTilt_ver)  //���̽�ƽ ��/�Ĺ� ������ ������ �� Ŭ�� ����
        {
            if (forwardTilt > 10 && forwardTilt < 74) //front �������� ���̽�ƽ ������ 10~74�� ���� �������
            {
                MainHookCableSpawn.Right_Joystick_Front = true; //���̽�ƽ ���� �̺�Ʈ ���� true
                MainHookCableSpawn.Right_Joystick_Back = false;
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
            else if (forwardTilt < 350 && forwardTilt > 290) //back �������� ���̽�ƽ ������ 10~74�� ���� �������
            {

                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = true; //���̽�ƽ �Ĺ� �̺�Ʈ ���� true
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
            else //10�� �̻� �������� �ʾҴٸ� �̺�Ʈ �� ����
            {
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
        }
        if (forwardTilt_ver < SideTilt_ver)  //���̽�ƽ ��/�� ������ ������ �� Ŭ�� ����
        {

            if (sideTilt < 170 && sideTilt > 110) //right �������� ���̽�ƽ ������ 10~74�� ���� �������
            {
                Crane_Operating_manager.Right_Joystick_Right = true;  //���̽�ƽ ���� �̺�Ʈ ���� true
                Crane_Operating_manager.Right_Joystick_Left = false;
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
            }
            else if (sideTilt > 190 && sideTilt < 250) //left �������� ���̽�ƽ ������ 10~74�� ���� �������
            {
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = true;  //���̽�ƽ ���� �̺�Ʈ ���� true
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
            }
            else  //10�� �̻� �������� �ʾҴٸ� �̺�Ʈ �� ����
            {
                MainHookCableSpawn.Right_Joystick_Front = false;
                MainHookCableSpawn.Right_Joystick_Back = false;
                Crane_Operating_manager.Right_Joystick_Right = false;
                Crane_Operating_manager.Right_Joystick_Left = false;
            }
        }
        
    }

    private void OnTriggerStay(Collider other) // �׽�Ʈ�� ����: �÷��̾��� �� ���� ������Ʈ�� ������� ���� �ٶ󺸸� transform ���� (0,1,0) �������� ����
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}

