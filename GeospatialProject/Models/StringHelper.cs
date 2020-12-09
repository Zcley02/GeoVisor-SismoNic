using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeospatialProject.Models
{
    public class StringHelper
    {
        public static string ChangeStringByShape(string type, string coordinates)
        {
            string NewShape = "";
            
            if(coordinates != null)
            {
                var CurrentShape = coordinates.Split(',');

                if (type == "rectangle")
                {
                    var First = CurrentShape[0].Substring(7);
                    var Index1 = CurrentShape[1].LastIndexOf(')');
                    var Second = CurrentShape[1].Substring(0, Index1);
                    var Third = CurrentShape[4].Substring(7);
                    var Index2 = CurrentShape[5].LastIndexOf(')');
                    var Fourth = CurrentShape[5].Substring(0, Index2);
                    NewShape = Second + ", " + First + ", " + Fourth + ", " + Third + ", 4326";
                }
                else if (type == "polygon")
                {
                    //Using for to iterate and create a string 
                }
                else if(type == "marker")
                {
                    var First = CurrentShape[0].Substring(7);
                    var Index1 = CurrentShape[1].LastIndexOf(')');
                    var Second = CurrentShape[1].Substring(0, Index1);
                    NewShape = Second + ", " + First;
                }

                return NewShape;
            }
            else
            {
                return null;
            }
        }
    }
}