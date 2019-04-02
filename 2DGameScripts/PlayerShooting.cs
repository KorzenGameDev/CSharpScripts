using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject prefabBullet;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private Animator animator;
    [SerializeField] private AmmoMenager ammo;

    [SerializeField] private bool check = false;

    [SerializeField] private bool isShoot = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        ammo = FindObjectOfType<AmmoMenager>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isShoot)
        {
            if(ammo.Ammo())
                StartCoroutine(Shoot());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            isShoot = false;
        }
    }

    // Coroutine odpowiedzialna za animacje strzelani i tworzenie obiektu w punkje firePoint
    IEnumerator Shoot()
    {
        isShoot = true;

        // wlaczenie animaccji strzelania
        if(animator!=null)
            animator.SetBool("IsShoot", isShoot);

        // tworzenie pocisku z prefabu
        if(prefabBullet!=null && firePoint!=null)
            Instantiate(prefabBullet, firePoint.transform.position, firePoint.transform.rotation);

        //czekanie
        yield return new WaitForSeconds(0.05f);
        // sprawdzanie czy wartosc isShoot sie nie zmieniła przez ten czas jesli tak to sie dosowuje
        if (isShoot)
            animator.SetBool("IsShoot", !isShoot);
        else
            animator.SetBool("IsShoot", isShoot);
    }
}
