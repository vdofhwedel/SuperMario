using UnityEngine;

public class CameraShake : MonoBehaviour
{
   
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	// Start is called before the first frame update
	void Start()
	{

	}

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = new Vector3(
				originalPos.x,
				originalPos.y + Random.insideUnitSphere.y * shakeAmount,
				originalPos.z);

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
			enabled = false;
		}
	}
}
