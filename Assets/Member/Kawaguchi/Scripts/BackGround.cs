using UnityEngine;
public class Background : MonoBehaviour, IPose
{
    [SerializeField]
    float scrollSpeed = -1;
    Vector3 cameraRectMin;

    bool _isPose;

    void Start()
    {
        //�J�����͈̔͂��擾
        cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z + 10));
    }
    void Update()
    {
        if (!_isPose)
        {
            Move();
        }
    }
    void Move()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);   //X�������ɃX�N���[��
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