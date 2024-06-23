﻿using MVC.Model;

namespace MVC.Controller
{
    public interface IDetailsIncreaser
    {
        public void DetailButtonClick(DetailModel detailModel, AircraftModel aircraftModel);
        public void TryCreateAircraft(AircraftModel aircraftModel);
    }
}