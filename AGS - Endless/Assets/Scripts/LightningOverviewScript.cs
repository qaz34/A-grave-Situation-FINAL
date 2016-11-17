using UnityEngine;
using System.Collections;

public class LightningOverviewScript : MonoBehaviour {

	public AudioSource source;
	public AudioClip thunder;

	public GameObject lightningStrikeSource;

	public float countdown;
	public float minDelay;
	public float maxDelay;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		countdown = Random.Range (minDelay, maxDelay);

		//Invoke ThunderLighting function after intial countdown period
		Invoke ("ThunderLightning", countdown);
	}


	void ThunderLightning()
	{
		/*Combined functionality from previous LightningExposure + LightninFlash script
	 * After countown period invoke ThunderLighting script.
	 * Run audio file for thunder x 1
	 * 
	 * Run LightningFlash function
	 * Run LightningExposure function
	 * 
	 * randomise countdown float
	 * 
	 * Invoke ThunderLightning Script again after countdown period
	*/

		Debug.Log ("OVERVIEW has began");

			source.PlayOneShot (thunder, 1.0f);
			Debug.Log ("makeSound is running!");

			
			LightningFlash (); // Call Lightning Flash function
			LightningExposure (); // Call Lightning Exposure fucntion


			Debug.Log ("Overview scripts now running");
			countdown = Random.Range (minDelay, maxDelay);  //Randomised countdown variable called for every iteration.
			Debug.Log ("Countdown til next Cycle" + countdown);
			Invoke ("ThunderLightning", countdown);  //Invoke self after random amount of time.  Function is a infite loop


	}

	void LightningFlash()
	{
		float minTime;
		float lastTime = 0.0f;

		float threshold = 0.4f;

		int strikeNumbers;
		int minStrikes = 1;
		int maxStrikes = 5;

		/*Function to set random amount of flashes, with random amount of time between inidividual flashes
		 * This script keeps going.  There is no end to it.
		 * 
		 *Set random amount of time for min time variable.  This is to use as a check
		 *Set random amountt of lightning flashes
		 *
		 *Check amount of lightning flashes
		 *
		 *IF 1 flash then
		 *ELSE (for anything else) Check that the time since the last strike, is great than the minimum threshold
		 * IF check has been passed
		 * 	Enable lightnign flash
		 * 	Activate a sprite for lightning stirke
		 * 	Activate lightningFlash Cancel fucntion after minimum allowed time
		 * ElSE Invoke the LightningFlash script from the beginning
		 *	
		 */

		Debug.Log ("LIGHTING FLASH - Lightning Flash Script has started!!!");
		minTime = Random.Range (0.06f, 0.2f); //Minimum amount of time between flashes as randomised variable
		strikeNumbers = Random.Range (minStrikes, maxStrikes); //random amount of lightning strikes
		Debug.Log ("LIGHTING FLASH - Amount of Lightning strikes: " + strikeNumbers);

		if (strikeNumbers == 1) {  //  if only 1 lightning strike is chosen then
			lightningStrikeSource.GetComponent<ParticleSystem>().Play (true);  //call the lightning sprite (part of the particle system) as being true
			gameObject.GetComponent<Light> ().enabled = (true);  //activate the lightning light source
			Debug.Log ("LIGHTING FLASH - Lightning has been activated");
			Invoke ("LightningFlashCancel", minTime);  //invoke the cancel function for the lightning after the minimum time variable
			Debug.Log ("LIGHTING FLASH - Lightning has been deactivated after " + minTime);
			return;  //return the current function to it's parent func
		} else
		{
			if ((Time.time - lastTime) > minTime) {  //Else if time clock time-last time is greater than the min time variabole AND
				if (Random.value > threshold) {  //if a random generated number is greater than the threshold var THEN
					lightningStrikeSource.GetComponent<ParticleSystem>().Play (true); //activate the lighting sprite
					gameObject.GetComponent<Light> ().enabled = (true); //activate the lightning light source
					Debug.Log ("LIGHTING FLASH - Lightning has been activated");
					lastTime = Time.time;  //set the variable last time to equal the current time
					Invoke ("LightningFlashCancel", minTime);  //invoke the lighting cancel function after min time variable
					strikeNumbers--;  //minus 1 off the strike numebers currently existing
					Invoke ("LightningFlash", minTime);  //invoke the lighting flash function from the very start

				}
				else Invoke ("LightningFlash", minTime);  //if the threshold test was failed, simply restart the lighting flash function from the start
			}
		}

	}

	void LightningFlashCancel()
	{
		gameObject.GetComponent<Light> ().enabled = (false);
	}

	void LightningExposure ()
	{
		float minTimeExposure = 0.07f;
		float maxTimeExposure = 0.2f;

		float randomTime;


		//When called increase exposure setting for random amount of time
		//Call the ExposureCancel function after random time

		Debug.Log ("LIGHTNING EXPOSURE - Exposure has been ativatedScript started");

		randomTime = Random.Range (minTimeExposure, maxTimeExposure);
		RenderSettings.skybox.SetFloat("_Exposure", 4.0f);
		Invoke ("LightningExposureCancel", randomTime);
	}

	void LightningExposureCancel()
	{
		//Set exposure setting back to game original setting

		RenderSettings.skybox.SetFloat("_Exposure", 0.7f);
		Debug.Log ("LIGHTNING EXPOSURE - Exposure disabled");

	}


}
