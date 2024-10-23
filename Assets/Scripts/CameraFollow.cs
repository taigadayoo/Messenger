using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform���Z�b�g
    public float smoothSpeed = 0.125f; // �J�����ړ��̃X���[�Y��

    private Vector3 offset; // �J�����̃I�t�Z�b�g

    void Start()
    {
        // �J�����ƃv���C���[�̏����ʒu�̍����i�I�t�Z�b�g�j���L�^
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // �v���C���[��X���W�̂ݒǏ]���AY��Z�͂��̂܂�
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

        // �X���[�Y�ɃJ�������ړ�
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }

}
