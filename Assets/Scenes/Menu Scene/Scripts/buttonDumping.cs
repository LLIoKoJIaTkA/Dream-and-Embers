using UnityEngine;

public class buttonDumping : MonoBehaviour
{
    [SerializeField]    private Animator _anim;

    private void Start() 
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("enter1");
        _anim.SetInteger("state", (int)1);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        Debug.Log("enter2");
        _anim.SetInteger("state", (int)2);
    }
    
}
