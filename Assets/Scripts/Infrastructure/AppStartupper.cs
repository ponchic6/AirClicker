using System.Collections.Generic;
using System.Linq;
using Factories;
using MVC.Model;
using StaticData;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilites;
using Zenject;

namespace Infrastructure
{
    public class AppStartupper : MonoBehaviour
    {
        private IUIFactory _uiFactory;
        private IAircraftStorage _aircraftStorage;
        private IAircraftDetailsStorage _aircraftDetailsStorage;
        private AircraftModelsList _aircraftModelsList;

        [Inject]
        public void Constructor(IUIFactory iuiFactory, IAircraftStorage aircraftStorage,
            IAircraftDetailsStorage aircraftDetailsStorage, AircraftModelsList aircraftModelsList)
        {
            _aircraftModelsList = aircraftModelsList;
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _aircraftStorage = aircraftStorage;
            _uiFactory = iuiFactory;
        }

        private void Start()
        {
            SceneManager.LoadScene("MainScene");

            foreach (AircraftModelSo aircraftModelSo in _aircraftModelsList.AircraftModels)
            {
                foreach (AircraftSerializableItem aircraftSerializableItem in aircraftModelSo.DetailsDictionary
                             .AircraftSerializableItem)
                {
                    if (!HasDictionaryDetailWithId(aircraftSerializableItem))
                    {
                        _aircraftDetailsStorage.DetailsCountDictionary[new DetailModel(aircraftSerializableItem.DetailModel.ID)]
                            = new ReactiveProperty<float>();
                    }
                }

                Dictionary<DetailModel, int> dictionaryReciep = new Dictionary<DetailModel, int>();
                
                foreach (AircraftSerializableItem item in aircraftModelSo.DetailsDictionary.AircraftSerializableItem)
                {
                    DetailModel detailModel = _aircraftDetailsStorage.DetailsCountDictionary.FirstOrDefault(pair =>
                        pair.Key.Id == item.DetailModel.ID).Key;
                    dictionaryReciep[detailModel] = item.Count;
                }

                AircraftModel aircraftModel = new AircraftModel(dictionaryReciep, aircraftModelSo.Id, aircraftModelSo.Sprite);
                _aircraftStorage.AircraftCountDictionary[aircraftModel] = new ReactiveProperty<float>();
            } 
            
            _uiFactory.CreateMainClickerCanvas();
        }

        private bool HasDictionaryDetailWithId(AircraftSerializableItem aircraftSerializableItem)
        {
            return _aircraftDetailsStorage.DetailsCountDictionary.Keys.Any(detail => detail.Id == aircraftSerializableItem.DetailModel.ID);
        }
    }
}
