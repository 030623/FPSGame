using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    // ���˵Ľ���ֵ����ʼΪ100
    public float health = 100;

    public float maxHealth = 100;

    // ���ڼ����������֮������RangeChecker���
    public RangeChecker rangeChecker;

    // ���˵Ķ������
    Animator animator;

    // ���˵ĵ����������
    NavMeshAgent nav;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    // �����ƶ���·��������
    public Transform[] waypoints;

    // ��ǰĿ��·���������
    int currentWaypointIndex = 0;

    // ���˵��ƶ��ٶ�
    public float speed = 5;

    public float damage = 10;

    public float bulletSpeed = 1000;

    public float lookAtRotateOffset = 0;

    // ��ʼ������������Ϸ��ʼʱ����
    private void Start()
    {
        // ��ȡAnimator���
        animator = GetComponent<Animator>();
        // ��ȡNavMeshAgent���
        nav = GetComponent<NavMeshAgent>();
        // ���õ���������ٶ�
        nav.speed = speed;

        nav.isStopped = false;

        health = maxHealth;
    }

    // ���·�������ÿһ֡����
    private void Update()
    {
        // ����RangeChecker���Ľ�����ö��������״̬
        animator.SetBool("IsShoot", rangeChecker.isInRange);
        nav.isStopped = rangeChecker.isInRange;
        if (!rangeChecker.isInRange)
        {
            // ���·������������·����
            if (waypoints.Length > 0)
            {
                // ������˵��ﵱǰĿ��·���㣨����С��0.5f��
                if (nav.remainingDistance <= nav.stoppingDistance)
                {
                    // �ƶ�����һ��·���㣬��������Ѿ��������һ��·���㣬��ѭ���ص���һ��·����
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }
                // ���õ��������Ŀ�ĵ�ΪĿ��·����
                nav.SetDestination(waypoints[currentWaypointIndex].position);
            }
            animator.SetBool("IsRun", (nav.speed > 1f)? true : false);
        }
        else
        {
            LookAtTarget(Player.instance.transform);
        }
    }
    public void Fire()
    {
        Player.instance.TakeDamage(damage);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
    }
    // �����ܵ��˺�ʱ���õķ���
    public void TakeDamage(float damage)
    {
        // ���ٵ��˵Ľ���ֵ
        health -= damage;
        // �������ֵС�ڵ���0����������
        if (health <= 0)
        {
            Die();
        }
    }

    // ��������ʱ���õķ���
    void Die()
    {
        // ���ٵ��˵���Ϸ����
        Destroy(gameObject);
    }

    // �����˱��ӵ�����ʱ���õķ���
    public void OnBulletHit(float damage)
    {
        // ����TakeDamage���������˺�
        TakeDamage(damage);
    }

    public void LookAtTarget(Transform target)
    {
        //ֻ�ı��Լ���Y�ᳯ��
        transform.LookAt(target);
        transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y+ lookAtRotateOffset, 0);
    }
}
