using UnityEngine;

public enum EnumAnimatorParameterType
{
    Float,
    Integer,
    Boolean,
    Trigger
}

public class OnAnimationEnd : StateMachineBehaviour
{
    //Notes:  I do no like this approach. It screams of having multiple types. Not sure how to convert this into a generic with unity editor support.


    [SerializeField]
    public string ParameterName;
    [SerializeField]
    public float ParameterValueFloat;
    [SerializeField]
    public int ParameterValueInteger;
    [SerializeField]
    public bool ParameterValueBoolean;
    [SerializeField]
    public EnumAnimatorParameterType ParameterType;

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (ParameterType)
        {
            case EnumAnimatorParameterType.Float:
                animator.SetFloat(ParameterName, ParameterValueFloat);
                break;
            case EnumAnimatorParameterType.Integer:
                animator.SetInteger(ParameterName, ParameterValueInteger);
                break;
            case EnumAnimatorParameterType.Boolean:
                animator.SetBool(ParameterName, ParameterValueBoolean);
                break;
            case EnumAnimatorParameterType.Trigger:
                animator.SetTrigger(ParameterName);
                break;
        }        
    }
}
