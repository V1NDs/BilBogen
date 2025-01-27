using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SearchPlate : MonoBehaviour
{
    public GameObject plateInput;
    public GameObject modelText;
    public CarStore carStore = new();

    public void Start()
    {
        string filePath = Application.persistentDataPath + "/cars.json";
        string cars = System.IO.File.ReadAllText(filePath);

        carStore = JsonUtility.FromJson<CarStore>(cars);
    }

    public void Search()
    {
        var carPlate = plateInput.GetComponent<TMP_InputField>().text;

        Debug.Log(carPlate);

        for (int i = 0; i < carStore.vehicles.Count; i++)
        {
            if (carStore.vehicles[i].licensePlate == carPlate.ToUpper())
            {
                Debug.Log(carStore.vehicles[i].model);
                modelText.GetComponent<TMP_Text>().text = carStore.vehicles[i].brand + " " + carStore.vehicles[i].model;

                break;
            }
        }
    }
}

[Serializable]
public class CarStore
{
    public List<CarInformation> vehicles = new();
}

[Serializable]
public class CarInformation
{
    public string licensePlate;
    public string brand;
    public string model;
    public string variant;
    public string vin;
    public int year;
    public string registered;
}
