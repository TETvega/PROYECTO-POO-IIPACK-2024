/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      backgroundImage: {
      "hero-pattern": "url('https://i.postimg.cc/gJyQf2X9/hero-pattern.jpg')",
      "notfound-pattern": "url('https://images01.nicepage.com/c461c07a441a5d220e8feb1a/671378236ca85744a3b2d40a/dd.png')",
    },
    colors:
    {
        siidni: {
          gold: "#e8a06d",
          goldLight : "#ea995e",
          brown: "#443e38",
          blue: "#002D72", // Azul marino oscuro
          blueLight: "#0048A5", // Azul claro
          blueDark: "#001A4F", // Azul más oscuro
          yellow: "#FFD700", // Amarillo dorado
          yellowLight: "#FFE033", // Amarillo claro
          yellowDark: "#CCAC00", // Amarillo más oscuro
        },
      }
    },
  },
  plugins: [
  //  require('@tailwindcss/typography'),
  ],
}

