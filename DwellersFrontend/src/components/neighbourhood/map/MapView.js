import React, { useEffect, useState } from 'react';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import MapLocation from './MapLocation';
import customIconUrl from './house.svg';

export default function MapView() {
  const mockLocations = [
    {
      name: 'Location 1',
      latitude: 58.361,
      longitude: 12.32,
    },
    {
      name: 'Location 2',
      latitude: 58.362,
      longitude: 12.34,
    },
  ];

  const [map, setMap] = useState(null);

  useEffect(() => {
    const newMap = L.map('map').setView([58.363, 12.33], 16);
    setMap(newMap);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution:
        '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
    }).addTo(newMap);

    // Clean up the map when the component unmounts
    return () => {
      newMap.remove();
    };
  }, []);

  // Create a custom icon using the provided SVG
  const customIcon = L.icon({
    iconUrl: customIconUrl,
    iconSize: [38, 95],
    iconAnchor: [22, 94],
    popupAnchor: [-3, -76],
  });

  return (
    <div id="map" className="h-[40vh] w-[40vh] border-1 border-black px-4">
      {/* Render MapLocation components for each location */}
      {mockLocations.map((location, index) => (
        <MapLocation key={index} location={location} map={map} customIcon={customIcon} />
      ))}
    </div>
  );
}