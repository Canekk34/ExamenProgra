using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Globalization;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class WeatherAPI : MonoBehaviour
{
    [SerializeField] private WeatherData data;
     private static readonly float latitud=35.6895f;
     private static readonly float longitud = 139.69171f;
     private static readonly string apiKey = "ee78750c94d1388b52443f4a2f0563ee";

    private string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitud}&lon={longitud}&appid={apiKey}";

    private string json;

    [SerializeField] private Light directionalLight;
    [SerializeField] private Color colorToChange;
    [SerializeField] private float colorChangeSpeed = 10;
    [SerializeField] private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;
    private Bloom bloom;

    private void Start()
    {
        StartCoroutine(WeatherUpdate());
        postProcessVolume.profile.TryGetSettings(out colorGrading);
        postProcessVolume.profile.TryGetSettings(out bloom);
        
    }

    IEnumerator WeatherUpdate()
    {
       while (true)
        {
            UnityWebRequest request = new UnityWebRequest(weatherUrl);
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                json = request.downloadHandler.text;
                decodJason();
                getColor();
               
                StartCoroutine(changelightColor());
                StartCoroutine(changecolorBloom());
                changincolograding();
                
            }

           

            yield return new WaitForSecondsRealtime(600f);
        }
    }

    private IEnumerator changelightColor()
    {
       

        yield return new WaitUntil(() => changinlightColor() ==colorToChange); 

    }

    private IEnumerator changecolorBloom()
    {
        yield return new WaitUntil(() => changingBloom() ==colorToChange);
    }

    private Color changinlightColor()
    {
        directionalLight.color = Color.Lerp(directionalLight.color, colorToChange, colorChangeSpeed * Time.deltaTime);
        return directionalLight.color;
    }

    private Color changingBloom()
    {

        bloom.color.value= Color.Lerp(directionalLight.color, colorToChange, colorChangeSpeed * Time.deltaTime);
        return bloom.color;
    }

    private void changincolograding()
    {
        colorGrading.colorFilter.value= colorToChange;
    }
 

   



    private void getColor()
    {
        switch (data.actualTemp)
        {
            case var temp when data.actualTemp <= 280:
                {
                    colorToChange = Color.blue;
                    break;
                }
            case var temp when data.actualTemp > 200 && data.actualTemp < 300:
                {
                    colorToChange = Color.cyan;
                    break;
                }
            case var temp when data.actualTemp > 300 && data.actualTemp < 320:
                {
                    colorToChange = Color.yellow;
                    break;
                }
            case var temp when data.actualTemp < 350:
                {
                    colorToChange = Color.red;
                    break;
                }
        }

    }

    private void decodJason()
    {
        var weatherJson = JSON.Parse(json);

        data.country = weatherJson["sys"]["country"].Value;
        data.city = weatherJson["name"].Value;
        data.actualTemp = float.Parse(weatherJson["main"]["temp"].Value);
        data.description = weatherJson["weather"][0]["description"].Value;
        data.windSpeed = float.Parse(weatherJson["wind"]["speed"].Value);
    }
}
