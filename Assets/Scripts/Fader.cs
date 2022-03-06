using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// A class to handle fading an object in and out
//
// SCRIPT USAGE:
// 1. Call any of the functions in this script using Fader.[FunctionName] 
// 2. If game object being faded is a fade cover, parent the game object to the camera at an appropriate depth above everything else
// 3. Call FadeIn() or FadeOut() via other scripts to fade the object in or out (you can also call Fade() directly for the most control)
// NOTE: FadeIn() and FadeOut() are coroutines, so they need to be called via StartCoroutine

public static class Fader
{

    #region Animate Alpha Methods
    // Don't specify anything...this function will use the fade out time value from the public instance variable and fade out from 1 to 0
    public static IEnumerator FadeOut(SpriteRenderer sprite)
    {
        return Fade(sprite, 2.0f, 1.0f, 0.0f);
    }

    // Specify a duration but not a value to fade out from
    public static IEnumerator FadeOut(SpriteRenderer sprite, float duration)
    {
        return Fade(sprite, duration, 1.0f, 0.0f);
    }

    //public static IEnumerator FadeOut(tk2dTextMesh textMesh, float duration)
    //{
    //    return Fade(textMesh, duration, 1.0f, 0.0f);
    //}

    // Specify a duration and a value to fade out from
    public static IEnumerator FadeOut(SpriteRenderer sprite, float duration, float from)
    {
        return Fade(sprite, duration, from, 0.0f);
    }

    //public static IEnumerator FadeOut(tk2dTextMesh textMesh, float duration, float from)
    //{
    //    return Fade(textMesh, duration, from, 0.0f);
    //}

    // Don't specify anything..this function will use the fade in time value from the public instance variable and fade in from 0 to 1
    public static IEnumerator FadeIn(SpriteRenderer sprite)
    {
        return Fade(sprite, 2.0f, 0.0f, 1.0f);
    }

    // Specify a duration but not a value to fade in from
    public static IEnumerator FadeIn(SpriteRenderer sprite, float duration)
    {
        return Fade(sprite, duration, 0.0f, 1.0f);
    }

    //public static IEnumerator FadeIn(tk2dTextMesh textMesh, float duration)
    //{
    //    return Fade(textMesh, duration, 0.0f, 1.0f);
    //}

    // Specify a duration and a value to fade in from
    public static IEnumerator FadeIn(SpriteRenderer sprite, float duration, float from)
    {
        return Fade(sprite, duration, from, 1.0f);
    }

    //public static IEnumerator FadeIn(tk2dTextMesh textMesh, float duration, float from)
    //{
    //    return Fade(textMesh, duration, from, 1.0f);
    //}

    // Main Fade function for SpriteRenderers
    public static IEnumerator Fade(SpriteRenderer sprite, float duration, float from, float to)
    {
        float currentTime = 0.0f; // start timer at 0
        float currentAlpha = from; // fade from currentAlpha

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);

        while (currentAlpha != to)
        {
            currentTime += Time.deltaTime / duration; // step time
            currentAlpha = Mathf.Lerp(from, to, currentTime); // interpolate alpha
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, currentAlpha); // set new alpha

            yield return 0;
        }
    }

    // Main Fade function for text meshes
    //public static IEnumerator Fade(tk2dTextMesh textMesh, float duration, float from, float to)
    //{
    //    float currentTime = 0.0f; // start timer at 0
    //    float currentAlpha = from; // fade from currentAlpha

    //    textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

    //    while (currentAlpha != to)
    //    {
    //        currentTime += Time.deltaTime / duration; // step time
    //        currentAlpha = Mathf.Lerp(from, to, currentTime); // interpolate alpha
    //        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, currentAlpha); // set new alpha

    //        yield return 0;
    //    }
    //}

    public static IEnumerator Fade(Image img, float duration, float from, float to)
    {
        float currentTime = 0.0f; // start timer at 0
        float currentAlpha = from; // fade from currentAlpha

        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

        while (currentAlpha != to)
        {
            currentTime += Time.deltaTime / duration; // step time
            currentAlpha = Mathf.Lerp(from, to, currentTime); // interpolate alpha
            img.color = new Color(img.color.r, img.color.g, img.color.b, currentAlpha); // set new alpha

            yield return 0;
        }
    }
    #endregion

    #region Animate Color Methods
    //public static IEnumerator ColorTo(this SpriteRenderer sprite, Color to, float duration, Easing easeType)
    //{

    //    float elapsed = 0;
    //    Color start = sprite.color;

    //    while (elapsed < duration)
    //    {
    //        elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
    //        sprite.color = Color.Lerp(start, to, easeType(elapsed / duration));
    //        yield return 0;
    //    }
    //    sprite.color = to;
    //}
    #endregion
}
