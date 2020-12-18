using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yugioh.Core.Logic.Flyweight
{
    public class ImageFactory
    {
        private static List<Image> images = new List<Image>();
        public static string GetImage(string image)
        {
            var foundImage = images.Where(p => p.ImageName == image).FirstOrDefault();

            if(foundImage == null)
            {
                foundImage = new Image();
                foundImage.ImageName = image;
                foundImage.ImageBytes = Convert.ToBase64String(File.ReadAllBytes(image));
                images.Add(foundImage);
            }

            return foundImage.ImageBytes;
        }
    }
}
