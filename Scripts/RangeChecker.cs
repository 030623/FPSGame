using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    // ����Ҫ����Ŀ���ǩ
    public string targetTag;

    // ����һ��SphereCollider����
    SphereCollider sphereCollider;

    // �����ⷶΧ��Ĭ��Ϊ10f
    public float range = 10f;

    // ���ڱ���Ƿ��⵽Ŀ�����
    public bool isInRange = false;

    // ����Ϸ��ʼʱִ��
    private void Start()
    {
        // ��ȡ��ǰ��Ϸ�����ϵ�SphereCollider���
        sphereCollider = GetComponent<SphereCollider>();

        // ����SphereCollider�İ뾶Ϊrange��ֵ
        sphereCollider.radius = range;

        // ��SphereCollider����Ϊ���������Ա��ڽ�����뿪ʱ�����¼�����������ײ
        sphereCollider.isTrigger = true;
    }

    // ��������Collider���뵱ǰSphereCollider�Ĵ�������ʱ����
    private void OnTriggerEnter(Collider other)
    {
        // �������Collider�Ƿ����ָ���ı�ǩ
        if (other.CompareTag(targetTag))
        {
            // ����У���isInRange����Ϊtrue����ʾ��⵽Ŀ�����
            isInRange = true;
        }
    }

    // ��������Collider�뿪��ǰSphereCollider�Ĵ�������ʱ����
    private void OnTriggerExit(Collider other)
    {
        // ����뿪��Collider�Ƿ����ָ���ı�ǩ
        if (other.CompareTag(targetTag))
        {
            // ����У���isInRange����Ϊfalse����ʾ���ټ�⵽Ŀ�����
            isInRange = false;
        }
    }
}
