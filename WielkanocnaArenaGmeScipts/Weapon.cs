using UnityEngine;
using EZCameraShake;

[RequireComponent(typeof(Collider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject punchEffect = null;
    [SerializeField] Transform punchPoint = null;
    [SerializeField] float dmg = 10f;
    [SerializeField] float startTimeBtwPunch = 1f;
    float timeBtwPunch = 0f;

    private void Start()
    {
        timeBtwPunch = startTimeBtwPunch;
    }
    private void Update()
    {
        timeBtwPunch -= Time.deltaTime;
    }

    public void SetDmg(float dmg) { this.dmg = dmg; }
    private void OnTriggerEnter(Collider other) {TakeDamageToPlayer(other);}
    private void OnTriggerStay(Collider other) {TakeDamageToPlayer(other);}

     void TakeDamageToPlayer(Collider other)
    {
        if (timeBtwPunch <= 0 && other.CompareTag("Player"))
        {
            IDamageable dPlayer = other.gameObject.GetComponent<IDamageable>();
            if (dPlayer != null) { dPlayer.TakeDamage(dmg); }

            Effect();
            timeBtwPunch = startTimeBtwPunch;

            return;
        }
    }

    void Effect()
    {
        CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .5f);
        GameObject e = Instantiate(punchEffect, punchPoint.position, Quaternion.identity);
        float time = punchEffect.GetComponent<ParticleSystem>().main.duration;
        Destroy(e, time);
    }
}
