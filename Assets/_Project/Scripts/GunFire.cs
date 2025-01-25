using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public float velocity;
    public GameObject bulletPrefab;
    public Transform barrel;
    public AudioSource audioSource;
    public ParticleSystem ps;

    public void Fire() {
        GameObject spawnedBullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().linearVelocity = velocity * barrel.forward;
        audioSource.Play();
        Animator anim;
        if (TryGetComponent<Animator>(out anim))
        {
            anim.SetTrigger("Fire");
        }
        if(ps != null)
        {
            ps.Play();
        }
        Destroy(spawnedBullet, 2f);
    }
}
/*public class GunFire : MonoBehaviour
{
    public InputActionAsset Input;

    public float velocity;
    public GameObject bulletPrefab;
    public Transform barrel;
    public AudioSource audioSource;
    public ParticleSystem ps;

    private void OnEnable()
    {
        Input.Enable();
        Input.FindAction("Activate").performed += HandlePerformed;
    }
    private void OnDisable()
    {
        Input.FindAction("Activate").performed -= HandlePerformed;
    }

    private void HandlePerformed(InputAction.CallbackContext context)
    {
        Fire();
    }

    public void Fire() {
        GameObject spawnedBullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().linearVelocity = velocity * barrel.forward;
        audioSource.Play();
        Animator anim;
        if (TryGetComponent<Animator>(out anim))
        {
            anim.SetTrigger("Fire");
        }
        if(ps != null)
        {
            ps.Play();
        }
        Destroy(spawnedBullet, 2f);
    }
}
*/