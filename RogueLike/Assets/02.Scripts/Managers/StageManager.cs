using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    //[��ȣ] �������� �� ���� �̺�Ʈ ȣ���ϸ� ���� ��ȯ�Ϸ��� �մϴ�.
    public event Action OnStageScene;
    public void CallStageStart()
    {
        OnStageScene?.Invoke();
    }
    // ������ ���������� ����

    // ���������� �ʱ�ȭ(����), ����, �̵� ���� ó��

    // ���������� �ʿ��� ���ν��� �ε�/ ����

}
