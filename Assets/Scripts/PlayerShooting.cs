using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private AudioSource shotAudio;
    [SerializeField] private Animator armsAnimator;
    [SerializeField] private ParticleSystem muzzleFlash;

    private void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }

        shotAudio.Play();
        armsAnimator.SetTrigger("Shoot");
        muzzleFlash.Play();
    }
}
