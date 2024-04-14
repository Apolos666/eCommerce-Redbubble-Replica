/** @type {import('tailwindcss').Config} */

module.exports = {
  content: [
    // Example content paths...
    './public/**/*.html',
    './src/**/*.{js,jsx,ts,tsx,vue}',
  ],
  darkMode: 'darkMode', // or 'media' or 'class'
  theme: {
    extend: {
      colors: {
        'lavender': '#AFA3F2',
      },
      outlineOffset: {
        'minus8': '-8px',
      },
      width: {
        '85Percent': '85%',
        '15Percent': '15%',
      }
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}

