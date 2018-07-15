using Android.Graphics;
using System.Collections.Concurrent;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;

namespace Xamarin.Forms.GoogleMaps.Android.Factories
{

    public class CachingNativeBitmapDescriptorFactory : NativeBitmapDescriptorFactory
    {
        ConcurrentDictionary<int, AndroidBitmapDescriptor> _cache = new ConcurrentDictionary<int, AndroidBitmapDescriptor>();
        NativeBitmapDescriptorFactory _defaultFactory = new NativeBitmapDescriptorFactory();
        
        public override AndroidBitmapDescriptor ToNativeDescriptor(BitmapDescriptor descriptor)
        {
            if(descriptor.Id.HasValue)
            {
                var cacheEntry = _cache.GetOrAdd(descriptor.Id.Value, _ => _defaultFactory.ToNativeDescriptor(descriptor));
                return cacheEntry;
            }

            return _defaultFactory.ToNativeDescriptor(descriptor);
        }
        
    }
}