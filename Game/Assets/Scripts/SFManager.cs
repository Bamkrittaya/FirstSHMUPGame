using UnityEngine;

public class SFManager : MonoBehaviour
{
    public static AudioClip batDie, witchGood;
    private static AudioSource audioSrc;

    private void Start()
    {
        // Load the audio clips from Resources folder
        batDie = Resources.Load<AudioClip>("batDie");
        witchGood = Resources.Load<AudioClip>("witchGood");

        // Get the AudioSource component attached to this GameObject
        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySF( string clip)
    {
        switch (clip)
        {
            case "batDie":
                audioSrc.PlayOneShot(batDie);
                break;
            case "witchGood":
                audioSrc.PlayOneShot(witchGood);
                break;
        }
    }

}

