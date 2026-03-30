using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class shows how the player who is in first person interacts with the football on the pitch.

public class hitBallForPlayer : MonoBehaviour
{


	[Header("Shot Power Information")]
	public float shootspeed;
	public float curveShotPowerUp;
	public float powerShotSpeedForward;
	public float powerShotSpeedDown;
	public float lobSpeedUp;
	public float lobSpeedForward;
	public float curveMin;
	public float curveMax;
	public float lobTorqueUp;
	public float dribbleSpeed;
	[Header("Shot Key Code Info")]
	public KeyCode lobShotKeyCode;
	public KeyCode normalShotKeyCode;
	public KeyCode curveShotKeyCode;
	public KeyCode powerShotKeyCode;
	[Header("References")]
	public GameObject player;
	public GameObject ball;
	public Camera playercamera;
	public Rigidbody rb;
	[Header("Audio")]
	public AudioSource footballSound;
	public AudioSource bounceSound;
	public AudioSource dribbleSound;
	[Header("Bool")]
	public bool isKicked = false;
	public bool addCurve = false;
	public bool addDip = false;
	private Vector3 originalPos;
	public AudioSource whistleSound;
	public AudioSource goalSound;
	public AudioSource owngoalSound;

	// Use this for initialization
	void Start()
	{
		
		rb = ball.GetComponent<Rigidbody>();
		player = this.gameObject;
		originalPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        whistleSound.Play();

    }





	void OnTriggerStay(Collider other)
	{




		if (Input.GetKeyDown(normalShotKeyCode) && other.gameObject.tag == "Ball")
		{



			rb.AddForce(playercamera.transform.forward * shootspeed * Time.deltaTime, ForceMode.Impulse);
			footballSound.Play();
			isKicked = true;
			addDip = true;

		}

		if (Input.GetKeyDown(curveShotKeyCode) && other.gameObject.tag == "Ball")
		{



			rb.AddForce(playercamera.transform.forward * shootspeed * Time.deltaTime, ForceMode.Impulse);
			rb.AddForce(playercamera.transform.up * curveShotPowerUp * Time.deltaTime, ForceMode.Impulse);
			footballSound.Play();
			addDip = true;
			addCurve = true;

		}


		if (Input.GetKeyDown(powerShotKeyCode) && other.gameObject.tag == "Ball")
		{



			rb.AddForce(-player.transform.up * powerShotSpeedDown * Time.deltaTime, ForceMode.Impulse);
			rb.AddForce(playercamera.transform.forward * powerShotSpeedForward * Time.deltaTime, ForceMode.Impulse);

			footballSound.Play();
			addDip = true;

		}
		if (Input.GetKeyDown(lobShotKeyCode) && other.gameObject.tag == "Ball")
		{



			rb.AddForce(player.transform.up * lobSpeedUp * Time.deltaTime, ForceMode.Impulse);
			rb.AddForce(playercamera.transform.forward * lobSpeedForward * Time.deltaTime, ForceMode.Impulse);
			rb.AddTorque(-player.transform.right * lobTorqueUp * Time.deltaTime, ForceMode.Impulse);
			footballSound.Play();
			addDip = true;
		}
		if (ball.transform.position.x > 13.129 && ball.transform.position.x < 19.58 && ball.transform.position.y < 2.2 && ball.transform.position.z < -42.1)
		{
			GetComponent<BallScript>().goals++;
			goalSound.Play();
			ball.transform.position = originalPos;


		}
		else if (ball.transform.position.x > 62.1 || ball.transform.position.x < -30)
		{

			ball.transform.position = originalPos;

		}
		else if (ball.transform.position.z > 40.6)
		{
			ball.transform.position = originalPos;
			owngoalSound.Play();
		}
		else if (ball.transform.position.z < -42.1)
		{
			ball.transform.position = originalPos;
		}


	}	


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			Application.Quit();



		}

		if (isKicked == true)
		{   // Curve force added each frame

			StartCoroutine(iskickedStopTimer());





		}

		if (addDip == true)
		{

			StartCoroutine(DipAdd());

		}

		if (addCurve == true)
		{

			StartCoroutine(CurveAdd());
		}


	}

	void OnCollisionEnter(Collision col)
	{


			//if (col.gameObject.tag == "Ground") {

			//	bounceSound.Play();

			//}

		if (col.gameObject.tag == "Ball")
		{


			dribbleSound.Play();
			rb.AddForce(player.transform.forward * 0 + player.GetComponent<Rigidbody>().velocity * dribbleSpeed, ForceMode.Impulse);
			player.GetComponent<Rigidbody>().AddForce(-player.transform.forward * 100f, ForceMode.Impulse);

		}



	}

		IEnumerator iskickedStopTimer()
		{
			rb.AddForce(-playercamera.transform.right * Random.Range(0.3f, 0.7f), ForceMode.Impulse);
			rb.AddForce(playercamera.transform.right * Random.Range(0.6f, 1f), ForceMode.Impulse);
			rb.AddForce(-playercamera.transform.right * Random.Range(0.4f, 0.8f), ForceMode.Impulse);
			rb.AddForce(player.transform.up * 0.5f, ForceMode.Impulse);
			rb.AddForce(playercamera.transform.right * Random.Range(0.4f, 0.6f), ForceMode.Impulse);
			rb.freezeRotation = true;
			yield return new WaitForSeconds(1.5f);
			rb.freezeRotation = false;
			isKicked = false;
		}

		IEnumerator DipAdd()
		{
			rb.AddForce(-player.transform.up * 0.1f, ForceMode.Impulse);
			yield return new WaitForSeconds(1.5f);
			addDip = false;
		}

		IEnumerator CurveAdd()
		{

			rb.AddForce(-player.transform.right * Random.Range(curveMin, curveMax) * Time.deltaTime, ForceMode.Impulse);
			yield return new WaitForSeconds(1.5f);
			addCurve = false;

		}





	
}


