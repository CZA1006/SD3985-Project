using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AudioSource attackAudio;

    private void Update()
    {
        attackAudio = GetComponent<AudioSource>();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.2f, 0.2f));
        }
    }

    private void Attack()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        attackAudio.Play();

        //Mouse Direction = mouse Pos - current player pos ���λ�á�Ŀ���λ�á�-��ǰλ�á���������λ�á�
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree ����ת�Ƕ�
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
