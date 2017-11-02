using UnityEngine;

namespace Assets.Scripts
{
    public class GolfPlayerController : MonoBehaviour
    {
        public GameObject Ball;
        public Transform Spawn;
        public float BlowStrenght = 5;
        private int _blows = 0;


        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update ()
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

            if (Input.GetKeyDown(KeyCode.Keypad0))
                ResetBall();
        }

        public void BlowBall(Vector3 direction, float force)
        {
            //Check if ball is stoll rolling
            Ball.GetComponent<Rigidbody>().AddForce(direction * force);
            _blows++;
        }

        public void ResetBall()
        {
            Ball.transform.position = Spawn.position;
            Ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
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
