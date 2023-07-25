using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes    //структура данных, сопостовляющая параметры с наглядными именами
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY =2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;     //общедоступная переменная, доступная в инспекторе

    public float sencitivityHor = 9.0f;     //объявление переменной, задающей поворот по горизонтали
    public float sencitivityVert = 9.0f;    //объявление переменной, задающей поворот по веритикали

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;    //закрытая переменная для угла поворота по вертикали

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
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;   //приращение угла поворота по вертикали в зависимости от мыши

            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);     //фиксация угла поворота по вертикали в заданном диапазоне

            float rotationY = transform.localEulerAngles.y;            //ограничение вращение по горизонтали (фиксация угла по вертикали)

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);    //задание поворота из сохранённых значений поворотаы
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
