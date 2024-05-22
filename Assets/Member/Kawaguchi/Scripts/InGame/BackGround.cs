using UnityEngine;
public class BackGround : MonoBehaviour, IPose
{
    [SerializeField]
    float scrollSpeed = -1;
    [SerializeField] float _speedUpLate;
    [SerializeField, Header("�S�[��")] GameObject _goalObj;
    [SerializeField, Header("�S�[���܂ł̋���")] float _goalDistance = 10;
    Vector3 cameraRectMin;

    bool _isPose;

    float _distance = 0;

    void Start()
    {
        //�J�����͈̔͂��擾
        cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (!_isPose)
        {
            Move();

            if (_goalDistance >= _distance && _goalObj != null)
            {
                Instantiate(_goalObj, transform.position, transform.rotation);
            }
            else
            {
                _distance += scrollSpeed * Time.deltaTime * (1 + _speedUpLate * LevelManager.Instance.Level);
            }
        }
    }
    void Move()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime * (1 + _speedUpLate * LevelManager.Instance.Level));   //X�������ɃX�N���[��
        //�J�����̉��[���犮�S�ɏo����A��[�ɏu�Ԉړ�
        if (transform.position.y < (cameraRectMin.y - Camera.main.transform.position.y) * 2)
        {
            transform.position = new Vector2(transform.position.x, (Camera.main.transform.position.y - cameraRectMin.y) * 2);
        }

    }

    public void InPose()
    {
        _isPose = true;
    }

    public void OutPose()
    {
        _isPose = false;
    }
}