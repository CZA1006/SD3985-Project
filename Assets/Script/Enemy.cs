using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform target;
    [SerializeField] private float maxHp;
    public float hp;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength;//MARKER Ч���������
    private float hurtCounter;//MARKER �൱�ڼ�����

    private void Start()
    {
        hp = maxHp;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FollowPlayer();

        hurtCounter -= Time.deltaTime;
        if (hurtCounter <= 0)
            sp.material.SetFloat("_FlashAmount", 0);
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void TakenDamage(float _amount)
    {
        hp -= _amount;
        HurtShader();
        if (hp <= 0)
            Destroy(gameObject);
    }

    private void HurtShader()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }

}
