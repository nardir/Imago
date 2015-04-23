// Code generated by Microsoft (R) AutoRest Code Generator 0.9.6.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace APIApp.Client.Models
{
    public partial class PictureDTO
    {
        private int? _pictureKey;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? PictureKey
        {
            get { return this._pictureKey; }
            set { this._pictureKey = value; }
        }
        
        private string _pictureUri;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PictureUri
        {
            get { return this._pictureUri; }
            set { this._pictureUri = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the PictureDTO class.
        /// </summary>
        public PictureDTO()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken pictureKeyValue = inputObject["PictureKey"];
                if (pictureKeyValue != null && pictureKeyValue.Type != JTokenType.Null)
                {
                    this.PictureKey = ((int)pictureKeyValue);
                }
                JToken pictureUriValue = inputObject["PictureUri"];
                if (pictureUriValue != null && pictureUriValue.Type != JTokenType.Null)
                {
                    this.PictureUri = ((string)pictureUriValue);
                }
            }
        }
    }
}
