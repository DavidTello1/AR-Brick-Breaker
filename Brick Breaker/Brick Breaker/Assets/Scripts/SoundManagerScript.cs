using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip ballBounceSound, ballDestroySound, brickBreakSound,
                            gameLoseSound, gameWinSound, powerUpSound, tapSound;
                            //gameTheme;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        ballBounceSound = Resources.Load<AudioClip>("ball_bounce");
        ballDestroySound = Resources.Load<AudioClip>("ball_destroyed");
        brickBreakSound = Resources.Load<AudioClip>("brick_break");
        gameLoseSound = Resources.Load<AudioClip>("game_lose");
        gameWinSound = Resources.Load<AudioClip>("game_win");
        powerUpSound = Resources.Load<AudioClip>("powerup_pick");
        tapSound = Resources.Load<AudioClip>("tap");

       // gameTheme = Resources.Load<AudioClip>("game_theme");

        audioSrc = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySoundFX(string clip)
    {
        switch (clip) {
            case "ball_bounce":
                audioSrc.PlayOneShot(ballBounceSound);
                break;
            case "ball_destroyed":
                audioSrc.PlayOneShot(ballDestroySound);
                break;
            case "brick_break":
                audioSrc.PlayOneShot(brickBreakSound);
                break;
            case "game_lose":
                audioSrc.PlayOneShot(gameLoseSound);
                break;
            case "game_win":
                audioSrc.PlayOneShot(gameWinSound);
                break;
            case "powerup_pick":
                audioSrc.PlayOneShot(powerUpSound);
                break;
            case "tap":
                audioSrc.PlayOneShot(tapSound);
                break;
            default:
                break;
        }
    }
}
