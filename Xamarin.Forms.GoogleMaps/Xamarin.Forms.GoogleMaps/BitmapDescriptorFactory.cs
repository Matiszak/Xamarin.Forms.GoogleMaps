using System;
using System.IO;

namespace Xamarin.Forms.GoogleMaps
{
    public static class BitmapDescriptorFactory
    {
        public static BitmapDescriptor DefaultMarker(Color color, int? id = null)
        {
            return BitmapDescriptor.DefaultMarker(color, id ?? color.GetHashCode());
        }

        public static BitmapDescriptor FromBundle(string bundleName, int? id = null)
        {
            return BitmapDescriptor.FromBundle(bundleName, id ?? bundleName.GetHashCode());
        }

        public static BitmapDescriptor FromStream(Stream stream, int? id = null)
        {
            return BitmapDescriptor.FromStream(stream, id);
        }

        public static BitmapDescriptor FromView(View view, int? id = null)
        {
            return BitmapDescriptor.FromView(view, id ?? view.Id.GetHashCode());
        }

        //public static BitmapDescriptor FromPath(string absolutePath)
        //{
        //    return BitmapDescriptor.FromPath(absolutePath);
        //}
    }
}

