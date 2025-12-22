using UnityEngine;

// 注意：这个脚本是挂在 Animator 的方块上的，不是挂在主角身上的！
public class ResetBool : StateMachineBehaviour
{
    // 我们在这个变量里存一下要重置的参数名，比如 "Attack"
    public string targetBool; 

    // 这个函数会在“进入状态的一瞬间”自动运行
    // 比如：刚从 Idle 切换到 Attack1 的那一帧
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 立刻把开关关掉！
        // 这样如果你不再按键，Animator 就不会自动往后走了
        animator.ResetTrigger(targetBool);
    }
}