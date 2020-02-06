using System;
using System.IO;
using Xbim.Ifc;
using Xbim.ModelGeometry.Scene;

namespace WebUI_274
{
    class Program
    {
        static void Main(string[] args)
        {
            const string modelFile = @"App_Data\4walls1floorSite.ifc";

            using (var model = IfcStore.Open(modelFile))
            {
                var context = new Xbim3DModelContext(model);

                var wexbimFilename = Path.ChangeExtension(modelFile, "wexbim");
                using(var wexbimFile = File.Create(wexbimFilename))
                {
                    using(var wexbimWriter = new BinaryWriter(wexbimFile))
                    {
                        model.SaveAsWexBim(wexbimWriter);
                        wexbimWriter.Close();
                    }
                    wexbimFile.Close();
                }
            }
        }
    }
}
