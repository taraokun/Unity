using UnityEngine;
using System.Collections;

public class BGMS : MonoBehaviour {

	private static BGMS instance;
	public AudioClip endBgm;
	public AudioClip bulletShotSound;
	public AudioClip burnSound;
	public AudioClip returnSound;
	public AudioSource battleBgm;
	public AudioSource NormalBgm;
	private AudioSource soundAudioSource;

	// Use this for initialization
	void Start () {
		this.soundAudioSource = gameObject.AddComponent<AudioSource> ();
	}
	public void PlayEndBgm (){
		soundAudioSource.PlayOneShot (endBgm);
	}

	public void PlaybulletShotSound(){
		soundAudioSource.PlayOneShot (bulletShotSound);
	}

	public void PlayburnSound(){
		soundAudioSource.PlayOneShot (burnSound);
	}

	public void PlayReturnSound(){
		soundAudioSource.PlayOneShot (returnSound);
	}

	public void PlaybattleBgm(){
		NormalBgm.Pause ();
		battleBgm.Play();
	}

	public void PlayNormalBgm(){
		NormalBgm.Play ();
		battleBgm.Pause();
	}

	public static BGMS Instance {
		get {
			if (instance == null) {
				instance = (BGMS)FindObjectOfType(typeof(BGMS));
				if (instance == null) {
					Debug.LogError("SoundManager Instance Error");
				}
			}
			return instance;
		}
	}
}