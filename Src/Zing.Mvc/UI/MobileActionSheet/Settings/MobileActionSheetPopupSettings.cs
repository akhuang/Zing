namespace Kendo.Mvc.UI
{
    using System;
    using System.Collections.Generic;
    using Kendo.Mvc.Extensions;

    public class MobileActionSheetPopupSettings : JsonObject
    {
        public MobileActionSheetPopupSettings()
        {
            //>> Initialization
        
        //<< Initialization
        }

        //>> Fields
        
        public string Height { get; set; }
        
        public string Width { get; set; }
        
        //<< Fields

        public MobilePopupDirection? Direction { get; set; }

        protected override void Serialize(IDictionary<string, object> json)
        {
            //>> Serialization
        
            if (Height.HasValue())
            {
                json["height"] = Height;
            }
            
            if (Width.HasValue())
            {
                json["width"] = Width;
            }
            
        //<< Serialization

            if (Direction.HasValue)
            {
                json["direction"] = Direction;
            }
        }
    }
}
