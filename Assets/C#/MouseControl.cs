using UnityEngine;

public class MouseControl : MonoBehaviour
{
	private float _xRot;
	private float _yRot;

	private float _xCurrRot;
	private float _yCurrRot;

	[SerializeField]
	private Camera _fpcCamera;

	[SerializeField]
	private GameObject _fpcObject;

	private float _mouseSensetive;

	private float _xRotVelocity;
	private float _yRotVelocity;

	[SerializeField]
	private float _smoothDampTime;

	void Start()
	{
		_mouseSensetive = ProjectManager<GameInfoDto>.LoadFromFile().MouseSensetive;

		_smoothDampTime = 0.1f;
	}

	void Update()
	{
		MouseMove();
	}

	private void MouseMove()
	{
		_xRot += Input.GetAxis("Mouse Y") * _mouseSensetive;
		_yRot += Input.GetAxis("Mouse X") * _mouseSensetive;

		_xRot = Mathf.Clamp(_xRot, -90, 90);

		_xCurrRot = Mathf.SmoothDamp(_xCurrRot, _xRot, ref _xRotVelocity, _smoothDampTime);
		_yCurrRot = Mathf.SmoothDamp(_yCurrRot, _yRot, ref _yRotVelocity, _smoothDampTime);

		_fpcCamera.transform.rotation = Quaternion.Euler(-_xCurrRot, _yCurrRot, 0f);

		_fpcObject.transform.rotation = Quaternion.Euler(0f, _yCurrRot, 0f);

	}
}
