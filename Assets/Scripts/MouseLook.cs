using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes    //��������� ������, �������������� ��������� � ���������� �������
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY =2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;     //������������� ����������, ��������� � ����������

    public float sencitivityHor = 9.0f;     //���������� ����������, �������� ������� �� �����������
    public float sencitivityVert = 9.0f;    //���������� ����������, �������� ������� �� ����������

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;    //�������� ���������� ��� ���� �������� �� ���������

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sencitivityHor, 0);
        }       
        
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;   //���������� ���� �������� �� ��������� � ����������� �� ����

            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);     //�������� ���� �������� �� ��������� � �������� ���������

            float rotationY = transform.localEulerAngles.y;            //����������� �������� �� ����������� (�������� ���� �� ���������)

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);    //������� �������� �� ����������� �������� ���������
        }

        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sencitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
