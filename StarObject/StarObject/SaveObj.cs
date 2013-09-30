using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarObject
{
    class SaveObj
    {
       
         SaveObj(String Name, String Description, String ShortDescr, String Race, String DropItem, String Category, String Image, String ImagePosX, String ImagePosY, String Frames, String AnimCycle, String SpaceScan, String Anchors)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\WriteLines.object", true))
            {
                file.WriteLine("{");
                file.WriteLine("  \"objectName\"" + " :" + " \"" + Name + "\",");
                file.WriteLine("  \"description\"" + " :" + " \"" + Description + "\",");
                file.WriteLine("  \"shortdescription\"" + " :" + " \"" + ShortDescr + "\",");
                file.WriteLine("  \"race\"" + " :" + " \"" + Race + "\",");
                file.WriteLine("  \"dropItem\"" + " :" + " \"" + DropItem + "\",");
                file.WriteLine("  \"category\"" + " :" + " \"" + Category + "\",");
                file.WriteLine(" ");
                file.WriteLine("  \"orientations\"" + " :" + " [");
                file.WriteLine("    {");
                file.WriteLine("      \"image\"" + " :" + " \"" + Image + ":{color}.{frame}"+"\",");
                file.WriteLine("      \"imagePosition\"" + " :" + " [" + ImagePosX + ", " + ImagePosY + "],");
                file.WriteLine("      \"frames\"" + " : " + Frames + ",");
                file.WriteLine("      \"animationCycle\"" + " : " + AnimCycle + ",");
                file.WriteLine(" ");
                file.WriteLine("      \"spaceScan\"" + " : " + SpaceScan + ",");
                file.WriteLine("      \"anchors\"" + " : " + "[ \""+ Anchors + "\" ]");
                file.WriteLine(" ");
                file.WriteLine("    }");
                file.WriteLine("  ]");
                file.WriteLine(" }");
            }
           
        }

       



        
    }
}
