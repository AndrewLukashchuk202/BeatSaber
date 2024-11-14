using UnityEngine;

public class GolemController : MonoBehaviour
{
    private Animator _animator;
    public GameObject _rockAttachSocket;
    public GameObject _rockPrefab;

    public float throwForce;
    public float throwUpwardForce;
    public float _throwCooldown;


    private bool _canThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        var _vert = Input.GetAxis("Vertical");
        var _throw = Input.GetButtonDown("Jump");
        _animator.SetFloat("Speed", _vert);
        _animator.SetBool("Swipe", _throw);

        if (_throw && _canThrow)
        {
            ThrowRock();
        }
    }

    void ThrowRock()
    {
        // The throw is handled by an AnimationEvent during the animation.
        // It is attached to the throw animation using an instance of AnimationEvent and IAnimEventExecute
        Invoke(nameof(ResetThrow), _throwCooldown);
    }

    private void ResetThrow()
    {
        _canThrow = true;
    }
}
