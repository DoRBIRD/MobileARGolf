using UnityEngine;

namespace Assets.Scripts
{
    public class GolfPlayerController : MonoBehaviour
    {
        public GameObject Ball;
        public Transform Spawn;
        public float BlowStrenght = 5;
        private int _blows = 0;

        private bool _ballStillRolling = false;

        private Vector3 _dragAndDropStart;
        private Vector3 _dragAndDropCurrent;
        private Vector3 _dragAndDropEnd;
        private bool _isAiming;

        private Ray _ray;
        private int _layerMask;
        float _maxRayDistance = 100000;
        public float ForceScaling = .25f;
        public float MinSpeedToCountAsRolling = 10;
        public float MaxBlowPower;

        public GameObject AimIndicator;
        public Transform AimIndicatorScale;

        public Transform CameraPosition;

		private bool _cameraAim = false;

        // Use this for initialization
        void Start()
        {

            AimIndicator.SetActive(false);
            _layerMask = LayerMask.GetMask("ControllerRayCast");
        }

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

		public void ToggleInputMode() {
			_cameraAim = !_cameraAim;
		}

        private void DragAndDropAim()
        {

            if (!_isAiming && Input.GetMouseButtonDown(0))
            {
                //print("mb down");
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, _maxRayDistance, _layerMask))
                {
                    _dragAndDropStart = _ray.GetPoint(_maxRayDistance);
                    print("D&D Start Posi: " + _dragAndDropStart);
                }
                _isAiming = true;
                AimIndicator.SetActive(true);
            }
            if (_isAiming)
            {
                
                if (Input.GetMouseButton(0))
                {
                    _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(_ray, _maxRayDistance, _layerMask))
                    {
                        _dragAndDropCurrent = _ray.GetPoint(_maxRayDistance);
                        //print("D&D Posi: " + _dragAndDropCurrent);

                        //indicate the aim direction
                        Vector3 aimVector3 = _dragAndDropCurrent - _dragAndDropStart;
                        //float magnitude = aimVector3.magnitude;
                        //print(magnitude);
                        //AimIndicatorScale.localScale = new Vector3(1,1,magnitude/10);

                        _dragAndDropCurrent.y = 0;
                        AimIndicator.transform.rotation = Quaternion.LookRotation(aimVector3.normalized,Vector3.up);
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    //print("mb up");
                    _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(_ray, _maxRayDistance, _layerMask))
                    {
                        _dragAndDropEnd = _ray.GetPoint(_maxRayDistance);

                        //make it 2D
                        _dragAndDropStart.y = 0;
                        _dragAndDropEnd.y = 0;

                        Vector3 direction = (_dragAndDropEnd - _dragAndDropStart);
                        float force = direction.magnitude;
                        print(force);
                        direction = Vector3.Normalize(direction);
                        BlowBall(direction, force * ForceScaling);

                        print("Direction: " + direction);
                    }
                    _isAiming = false;
                    AimIndicator.SetActive(false);
                }
            }
        }


        void KeyInputManager()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
                BlowBall((Vector3.left + Vector3.back).normalized, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad2))
                BlowBall(Vector3.back, BlowStrenght);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                BlowBall(Vector3.back, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad3))
                BlowBall((Vector3.right + Vector3.back).normalized, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad4))
                BlowBall(Vector3.left, BlowStrenght);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                BlowBall(Vector3.left, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad5))
                BlowBall(Vector3.up, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad6))
                BlowBall(Vector3.right, BlowStrenght);
            if (Input.GetKeyDown(KeyCode.RightArrow))
                BlowBall(Vector3.right, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad7))
                BlowBall((Vector3.left + Vector3.forward).normalized, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad8))
                BlowBall(Vector3.forward, BlowStrenght);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                BlowBall(Vector3.forward, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.Keypad9))
                BlowBall((Vector3.right + Vector3.forward).normalized, BlowStrenght);

            if (Input.GetKeyDown(KeyCode.V))
                AimIndicator.SetActive(!AimIndicator.activeSelf);


            Vector3 aimingVector = transform.position - CameraPosition.position;
            aimingVector.y = 0;

            _dragAndDropCurrent.y = 0;
            AimIndicator.transform.rotation = Quaternion.LookRotation(aimingVector.normalized, Vector3.up);
			if (Input.GetKeyDown(KeyCode.C) || _cameraAim && Input.GetMouseButtonDown(0))
			{
				BlowBall(aimingVector.normalized, BlowStrenght);
			}
        }
        // Update is called once per frame
        void Update()
        {
            _ballStillRolling = GetComponent<Rigidbody>().velocity.magnitude > MinSpeedToCountAsRolling;
            if (!_ballStillRolling)
            {
                KeyInputManager();
				if (_cameraAim) {
					//
				} else {
					DragAndDropAim();
				}
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
                ResetBall();
            /*if (Input.GetKeyDown(KeyCode.Space))
                ResetBall();*/
            if (Input.GetKeyDown(KeyCode.Escape))
                ResetBall();
        }

        public void BlowBall(Vector3 direction, float force)
        {
            //Check if ball is stoll rolling
            Ball.GetComponent<Rigidbody>().AddForce(direction * Mathf.Clamp(force, 0, MaxBlowPower));
            _blows++;
        }

        public void ResetBall()
        {
            Ball.transform.position = Spawn.position;
            Ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        public void ResetGame()
        {
            ResetBall();
            _blows = 0;
        }

        public int GetBlows()
        {
            return _blows;
        }
    }
}
