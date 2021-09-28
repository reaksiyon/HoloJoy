using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    protected Joybutton joybutton;

    private bool attack;

    private void Start()
    {
        joybutton = FindObjectOfType<Joybutton>();
    }

    private void Update()
    {
        if (!attack && (joybutton.Pressed || Input.GetButtonDown("Fire1")))
        {
            attack = true;

            Shoot();
        }

        if(attack && !joybutton.Pressed)
        {
            attack = false;
        }
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("attack");
    }
}
