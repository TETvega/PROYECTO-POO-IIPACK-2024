/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      backgroundImage: {
      "hero-pattern": "url('./public/hero-pattern.jpg')",
    },
    colors:
    {
        siidni: {
          gold: "#e8a06d",
          goldLight : "#ea995e",
          black: "#19191c",
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

