using System.IO;

namespace Xamarin.Forms.GoogleMaps
{
    public class BitmapDescriptor
    {
        internal int? Id { get; private set; }
        internal BitmapDescriptorType Type { get; private set; }
        internal Color Color { get; private set; }
        internal string BundleName { get; private set; }
        internal Stream Stream { get; private set; }
        internal string AbsolutePath { get; private set; }
        internal View View { get; private set; }

        private BitmapDescriptor()
        {
        }

        internal static BitmapDescriptor DefaultMarker(Color color, int? id = null)
        {
            return new BitmapDescriptor()
            {
                Id = id,
                Type = BitmapDescriptorType.Default,
                Color = color
            };
        }

        internal static BitmapDescriptor FromBundle(string bundleName, int? id = null)
        {
            return new BitmapDescriptor()
            {
                Id = id,
                Type = BitmapDescriptorType.Bundle,
                BundleName = bundleName
            };
        }

        internal static BitmapDescriptor FromStream(Stream stream, int? id = null)
        {
            return new BitmapDescriptor()
            {
                Id = id,
                Type = BitmapDescriptorType.Stream,
                Stream = stream
            };
        }

        internal static BitmapDescriptor FromPath(string absolutePath, int? id = null)
        {
            return new BitmapDescriptor()
            {
                Id = id,
                Type = BitmapDescriptorType.AbsolutePath,
                AbsolutePath = absolutePath
            };
        }

        internal static BitmapDescriptor FromView(View view, int? id = null)
        {
            return new BitmapDescriptor()
            {
                Id = id,
                Type = BitmapDescriptorType.View,
                View = view
            };
        }
    }
}

