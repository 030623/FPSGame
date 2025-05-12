using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    // 定义要检测的目标标签
    public string targetTag;

    // 声明一个SphereCollider变量
    SphereCollider sphereCollider;

    // 定义检测范围，默认为10f
    public float range = 10f;

    // 用于标记是否检测到目标对象
    public bool isInRange = false;

    // 在游戏开始时执行
    private void Start()
    {
        // 获取当前游戏对象上的SphereCollider组件
        sphereCollider = GetComponent<SphereCollider>();

        // 设置SphereCollider的半径为range的值
        sphereCollider.radius = range;

        // 将SphereCollider设置为触发器，以便在进入或离开时触发事件而不产生碰撞
        sphereCollider.isTrigger = true;
    }

    // 当有其他Collider进入当前SphereCollider的触发区域时调用
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入的Collider是否具有指定的标签
        if (other.CompareTag(targetTag))
        {
            // 如果有，则将isInRange设置为true，表示检测到目标对象
            isInRange = true;
        }
    }

    // 当有其他Collider离开当前SphereCollider的触发区域时调用
    private void OnTriggerExit(Collider other)
    {
        // 检查离开的Collider是否具有指定的标签
        if (other.CompareTag(targetTag))
        {
            // 如果有，则将isInRange设置为false，表示不再检测到目标对象
            isInRange = false;
        }
    }
}
