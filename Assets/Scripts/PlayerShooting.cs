using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    //[SerializeField] private UIManager uiManager;
    [SerializeField] private AudioSource shotAudio;
    [SerializeField] private Animator armsAnimator;
    [SerializeField] private ParticleSystem muzzleFlash;

    [SerializeField] private int damage = 25;
    [SerializeField] private float range = 100f;
    [SerializeField] private float spread = 0.01f;
    [SerializeField] private int ammo = 25;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && ammo > 0)
        {
            shotAudio.Play();
            armsAnimator.SetTrigger("Shoot");
            muzzleFlash.Play();
            
            ammo--;
            Vector2 spreadOffset = Random.insideUnitCircle * spread;
            Vector3 direction = playerCamera.transform.forward +
                playerCamera.transform.right * spreadOffset.x +
                playerCamera.transform.up * spreadOffset.y;

            Vector3 origin = playerCamera.transform.position;
            bool hasHit = Physics.Raycast(origin, direction, out RaycastHit hit, range);
            if (hasHit)
            {
                Debug.Log(hit.collider.name);
            }
            float drawDistance = hasHit ? hit.distance : range;
            Debug.DrawRay(origin, direction *  drawDistance, hasHit ? Color.red : Color.green, 3f);
        }
    }
}
