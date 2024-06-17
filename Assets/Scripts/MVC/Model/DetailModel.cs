using System;

namespace MVC.Model
{
    public class DetailModel : IDetailModel
    {
        public string Id { get; }

        public DetailModel(string id)
        {
            Id = id;
        }
    }
}