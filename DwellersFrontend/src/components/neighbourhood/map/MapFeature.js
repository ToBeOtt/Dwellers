import { useEffect, useRef } from 'react';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';

function MapFeature({ data, map, customIcon }) {
  const geojsonLayerRef = useRef(null);

  useEffect(() => {
    if (!map || !data) return;

    // Define a style function to customize the feature's appearance
    const style = function (feature) {
      switch (feature.properties.type) {

      }
    };

    // Create a GeoJSON layer with the provided data and custom style
    geojsonLayerRef.current = L.geoJSON(data, {
      style: style, // Use the custom style function
      pointToLayer: function (feature, latlng) {
        // Create a custom marker with the provided custom icon
        return L.marker(latlng, { icon: customIcon });
      },
    }).addTo(map);

    // Clean up the layer when the component unmounts
    return () => {
      if (geojsonLayerRef.current) {
        geojsonLayerRef.current.remove();
      }
    };
  }, [data, map, customIcon]);

  return null; // Render nothing, as Leaflet will handle the rendering of the GeoJSON layer
}

export default MapFeature;
