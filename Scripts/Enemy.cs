using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    // 敌人的健康值，初始为100
    public float health = 100;

    public float maxHealth = 100;

    // 用于检测敌人与玩家之间距离的RangeChecker组件
    public RangeChecker rangeChecker;

    // 敌人的动画组件
    Animator animator;

    // 敌人的导航代理组件
    NavMeshAgent nav;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    // 敌人移动的路径点数组
    public Transform[] waypoints;

    // 当前目标路径点的索引
    int currentWaypointIndex = 0;

    // 敌人的移动速度
    public float speed = 5;

    public float damage = 10;

    public float bulletSpeed = 1000;

    public float lookAtRotateOffset = 0;

    // 初始化方法，在游戏开始时调用
    private void Start()
    {
        // 获取Animator组件
        animator = GetComponent<Animator>();
        // 获取NavMeshAgent组件
        nav = GetComponent<NavMeshAgent>();
        // 设置导航代理的速度
        nav.speed = speed;

        nav.isStopped = false;

        health = maxHealth;
    }

    // 更新方法，在每一帧调用
    private void Update()
    {
        // 根据RangeChecker检测的结果设置动画的射击状态
        animator.SetBool("IsShoot", rangeChecker.isInRange);
        nav.isStopped = rangeChecker.isInRange;
        if (!rangeChecker.isInRange)
        {
            // 如果路径点数组中有路径点
            if (waypoints.Length > 0)
            {
                // 如果敌人到达当前目标路径点（距离小于0.5f）
                if (nav.remainingDistance <= nav.stoppingDistance)
                {
                    // 移动到下一个路径点，或者如果已经到达最后一个路径点，则循环回到第一个路径点
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }
                // 设置导航代理的目的地为目标路径点
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
    // 敌人受到伤害时调用的方法
    public void TakeDamage(float damage)
    {
        // 减少敌人的健康值
        health -= damage;
        // 如果健康值小于等于0，敌人死亡
        if (health <= 0)
        {
            Die();
        }
    }

    // 敌人死亡时调用的方法
    void Die()
    {
        // 销毁敌人的游戏对象
        Destroy(gameObject);
    }

    // 当敌人被子弹击中时调用的方法
    public void OnBulletHit(float damage)
    {
        // 调用TakeDamage方法处理伤害
        TakeDamage(damage);
    }

    public void LookAtTarget(Transform target)
    {
        //只改变自己的Y轴朝向
        transform.LookAt(target);
        transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y+ lookAtRotateOffset, 0);
    }
}
