/** @type {import('tailwindcss').Config} */

const colors = require('tailwindcss/colors');

const customColors = {
  'n': '#E49A3C', // Neutral color-scheme when not using household or neighbourhood
  'hover-n': '#FC991A',
  'hh': '#0F7B6A', // household
  'hover-hh': '#134840',
  'nbh': '#E17961', // neighbourhood
  'hover-nbh': '#BF4E34',
  'contentText': '#403535',
  'dweller-pink': '#B77580',
  'dweller-text': '#DAD5D5',
};

module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      fontFamily: {
        'logoText': ['"Anton"', 'sans-serif'],
        'titleFont': ['"Roboto Slab"', 'serif'],
        'contentFont': ['"Fira Sans"', 'sans-serif'],
    },
    colors: {      
      ...colors,
      ...customColors,
    },
  },

  variants: {},
  plugins: [],
}}


