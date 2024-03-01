import React from 'react';
import MapFeature from './MapFeature';

export default function MapLocation({ location, map, customIcon }) {
  const { name, latitude, longitude } = location;

  return (
    <MapFeature
      data={{
        type: 'Feature',
        properties: {
          name: name,
        },
        geometry: {
          type: 'Point',
          coordinates: [longitude, latitude],
        },
      }}
      options={{
        style: function (feature) {
          switch (feature.properties.type) {
            case 'park':
              return { color: 'green', fillColor: 'lightgreen' };
            case 'restaurant':
              return { color: 'red', fillColor: 'pink' };
            default:
              return { color: 'blue', fillColor: 'lightblue' };
          }
        },
      }}
      map={map}
      customIcon={customIcon} 
    />
  );
}
