using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float attackDamage;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("We have Hitted the Enemy!");
            other.gameObject.GetComponent<Enemy>().TakenDamage(attackDamage);

            #region ����Ч�� �������ƶ����ӽ�ɫ���ĵ㡸��ǰλ�á������λ�÷���Ŀ��㡹�ƶ�
            Vector2 difference = other.transform.position - transform.position;
            other.transform.position = new Vector2(other.transform.position.x + difference.x / 2,
                                                   other.transform.position.y + difference.y / 2);
            #endregion
        }
    }
}
